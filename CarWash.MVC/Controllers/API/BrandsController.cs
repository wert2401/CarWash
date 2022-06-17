using CarWash.Database.Models;
using CarWash.Database.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarWash.MVC.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IRepositoriesHolder repositoriesHolder;

        public BrandsController(IRepositoriesHolder repositoriesHolder)
        {
            this.repositoriesHolder = repositoriesHolder;
        }

        // GET: api/<BrandsController>
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            IEnumerable<Brand> brands = repositoriesHolder.BrandRepository.GetAll();
            return brands;
        }

        // GET api/<BrandsController>/5
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            Brand? brand = repositoriesHolder.BrandRepository.Get(id);
            if (brand == null)
                return new Brand();
            return brand;
        }

        //// POST api/<BrandsController>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<BrandsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/<BrandsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Brand? brandToRemove = repositoriesHolder.BrandRepository.Get(id);
            if (brandToRemove != null)
                repositoriesHolder.BrandRepository.Remove(brandToRemove);
        }
    }
}
