using Core_Proje_API.DAL.ApiContext;
using Core_Proje_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());//Sonucun başarılı olduğunu dönüyoruz(Return Ok)
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var c = new Context();
            var value = c.Categories.Find(id);
            if(value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var c = new Context();
            var value = c.Categories.Find(id);
            if(value==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();//Herhangi bir içerik olmadan döndür 
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            var c = new Context();
            var value = c.Categories.Find(p.CategoryID);
            value.CategoryName = p.CategoryName;
            c.Update(value);
            c.SaveChanges();
            return Ok(value);

            //var value = c.Find<Category>(p.CategoryID);//Key value yaptık
            /*
             
            if(value==null)
            {
            return NotFound();
            }
            else
            {
                  value.CategoryName = p.CategoryName;
                   c.Update(value);
                    c.Savechange();
                   return NoContent();
            }


              
             */



        }
    }
}
