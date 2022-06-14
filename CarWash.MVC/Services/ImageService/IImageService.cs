namespace CarWash.MVC.Services.ImageService
{
    public interface IImageService
    {
        public string SaveCustomerCarImg(IFormFile img);
        public string SaveEmployeeImg(IFormFile img);
    }
}
