    [HttpGet]
    public IActionResult MMyExportAction() {
        var progresses = _elearnContext.Progress.Where(p => p.UserId == id)
            .Include(p => p.User.UserMetaData)
            .Include(p => p.Quiz)
            .Include(p => p.User.Groups)
            .OrderByDescending(p => p.UpdatedAt)
            .ToList()
            .Select(progress => 
                new new ReportCSVModel() {
                    Quiz = progress.Quiz.Title,
                    Score = (progress.CorrectAnswersCount * progress.PointsPerQuestion).ToString(),
                    Status = progress.Status,
                    CompletedDate = progress.UpdatedAt.ToString(),
                    Location = progress.User.UserMetaData != null ? progress.User.UserMetaData.Location : "",
                    Group = progress.User.Groups.FirstOrDefault() != null ? progress.User.Groups.FirstOrDefault().Name : ""
                }
            );
        List<ReportCSVModel> reportCSVModels = progresses.ToList();
        
        var stream = new MemoryStream();
        var writeFile = new StreamWriter(stream);
        var csv = new CsvWriter(writeFile);
        csv.Configuration.RegisterClassMap<GroupReportCSVMap>();
        
        csv.WriteRecords(reportCSVModels);
               
        return File(stream, "application/octet-stream", "Reports.csv");
    }
