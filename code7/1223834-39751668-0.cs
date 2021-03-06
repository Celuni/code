    PutObjectRequest request = new PutObjectRequest();
                request.WithBucketName(BUCKET_NAME);
                request.WithKey(PrefixFolder + folderPath[i] + addProjectResponse.ProjectName.Replace("_", " ") + "/");
                request.WithTimeout(-1);
                request.WithReadWriteTimeout(60 * 60 * 1000);
                request.WithContentBody("");
                s3Client.PutObject(request);
                S3DirectoryInfo source = new S3DirectoryInfo(s3Client, BUCKET_NAME, PrefixFolder + folderPath[i] + addProjectResponse.OldProjectName.Replace("_", " "));
                S3DirectoryInfo destination = new S3DirectoryInfo(s3Client, BUCKET_NAME, PrefixFolder + folderPath[i] + addProjectResponse.ProjectName.Replace("_", " "));
                source.CopyTo(destination);
    
                DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest()
                {
                    BucketName = BUCKET_NAME,
                    Key = PrefixFolder + folderPath[i] + addProjectResponse.OldProjectName.Replace("_", " ")
                };
                S3Response response = s3Client.DeleteObject(deleteObjectRequest);
