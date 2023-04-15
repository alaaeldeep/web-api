using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.StaticFiles.Infrastructure;
using WebApplication1.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private static List<Car> Cars { get; set; } = new()
        {
            new Car { Id = 1,Model="kia",price=20000,ProductionDate=new DateTime(2019,9,9),type="Gas "},
            new Car { Id = 2,Model="toyota",price=150000,ProductionDate=new DateTime(2020,2,20),type="Gas "}
        };

        private readonly ILogger<CarController> logger;

        public CarController(ILogger<CarController> logger )
        {
            this.logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Car>> Getall()

        {
            logger.LogCritical("Get All Cars");
            return Cars;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Car> Getbyid(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            if (car is null)
            {
                return NotFound();
            }
            return car;
        }

        [HttpPost]
        [Route("v1")]
        public ActionResult Add_v1(Car car)
        {
            car.Id = Cars.Count + 1;
            car.type = "Gas";
            Cars.Add(car);
            return CreatedAtAction(nameof(Getbyid), new { id = car.Id }, car);
        }

        [HttpPost]
        [Route("v2")]
        [ValidateCarType]
        public ActionResult Add_v2(Car car)
        {
            car.Id = Cars.Count + 1;
            Cars.Add(car);

            return CreatedAtAction(nameof(Getbyid), new { id = car.Id }, car);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Edit (Car carrequest ,int id) 
        {
            if(carrequest.Id != id)
            {
                return BadRequest(); 
            }

            var car= Cars.FirstOrDefault(c=>c.Id==id);
            if (car is null) {
                return NotFound();
            }
                car.price = carrequest.price;
                car.type = carrequest.type;
                car.ProductionDate=carrequest.ProductionDate;
                car.Model=carrequest.Model;
                return NoContent();
         }

        [HttpDelete]
        [Route("{id}")]

        public ActionResult Delete(int id)
        {
            var car= Cars.FirstOrDefault(c=>c.Id==id);
            if (car is null)
            {
                return NotFound();
            }
                Cars.Remove(car);
                return NoContent();
        }
    }
}
