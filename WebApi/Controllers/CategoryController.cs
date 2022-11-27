using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController
    {
        private CategoryService _CategoryService;

        public CategoryController()
        {
            _CategoryService = new CategoryService();
        }


        [HttpGet("GetInfo")]
        public List<Category> GetCategory()
        {
            return _CategoryService.GetInfoCategory();
        }
         


        [HttpPost("Insert")]
        public int InsertCategory(Category Category)
        {
            return _CategoryService.InsertCategory(Category);
        }

        [HttpPut("Update")]
        public int UpdateCategory(Category Category)
        {
            return _CategoryService.UpdateCategory(Category);
        }

        [HttpDelete("Delete")]
        public int DeleteCategory(int id)
        {
            return _CategoryService.DeleteCategory(id);
        }         
      

    }

}