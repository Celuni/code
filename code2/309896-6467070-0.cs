    namespace Library
    {
       public static class ImageToByte
       {
          public static Image Convert(byte[] byteArrayIn)
          {
              using (MemoryStream ms = new MemoryStream(byteArrayIn))
              {
                  Image returnImage = Image.FromStream(ms);
                  return returnImage;
              }
          }
       }
     }
