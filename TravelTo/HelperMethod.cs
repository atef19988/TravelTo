namespace TravelTo
{
    public class HelperMethod
    {
        public static  string UploadFileName(List<IFormFile> files, string PathFile, string Extention)
        {
            string NameFile = "";
            foreach (var file in files)
            {
                NameFile = Guid.NewGuid().ToString() + Extention;
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + PathFile, NameFile);
                using (var streem = System.IO.File.Create(FilePath))
                {
                      file.CopyTo(streem);
                }

            }

            return NameFile;
        }
    }
}
