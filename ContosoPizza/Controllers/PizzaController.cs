using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }
        // GET: api/<PizzaController>
        [HttpGet]
        public List<Pizza> GetAll()
        {
            return PizzaService.GetAll();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok( pizza);
        }

        // POST api/<PizzaController>
        [HttpPost(Name ="AddPizza")]
        public ActionResult<List<Pizza>> CreatePizza()
        {
            Pizza pizza = new Pizza() { IsGlutenFree = true, Name = "Corn" };
            PizzaService.Add(pizza);
            return PizzaService.GetAll();
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            PizzaService.Delete(id);
        }
    }
}
