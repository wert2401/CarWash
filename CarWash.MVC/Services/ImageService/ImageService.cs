namespace CarWash.MVC.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly string customerCarsFolder = "images/customercars";
        private readonly string employeesFolder = "images/employees";
        private readonly string webRootPath;


        public ImageService(IWebHostEnvironment environment)
        {
            webRootPath = environment.WebRootPath;
        }

        public string SaveCustomerCarImg(IFormFile img)
        {
            return SaveImg(img, customerCarsFolder);
        }

        public string SaveEmployeeImg(IFormFile img)
        {
            return SaveImg(img, employeesFolder);
        }

        private string SaveImg(IFormFile img, string folder)
        {
            string filePath;

            string fileName = Guid.NewGuid().ToString() + ".jpg";
            filePath = Path.Combine(webRootPath, folder, fileName);
            img.CopyTo(new FileStream(filePath, FileMode.Create));

            return Path.Combine(folder, fileName);
        }
    }
}
