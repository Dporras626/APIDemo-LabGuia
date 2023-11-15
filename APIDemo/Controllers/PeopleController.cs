using APIDemo.Modelos;
using APIDemo.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    //https:localhost:1987/api/People/Get
    //https:localhost:1987/api/People/GetById


    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public List<PersonModel> Get()
        {
            List<PersonModel> response = new List<PersonModel>();
            for (int i = 0; i < 10; i++)
            {
                response.Add(new PersonModel { Id = i + 1, FullName = "Diego Porras", Age = 19 });
            }
            return response;
        }
        [HttpGet]
        public PersonModel GetById(int Id)
        {
            List<PersonModel> people = new List<PersonModel>();
            for (int i = 0; i < 20; i++)
                people.Add(new PersonModel { Id = i + 1, FullName = "Diego Porras", Age = 19 });

            var response = people.Where(x => x.Id == Id).FirstOrDefault();

            return response;
        }
        [HttpPost]
        public PersonModel GetByFiltrer(PersonModel request)
        {
            List<PersonModel> people = new List<PersonModel>();
            for (int i = 0; i < 20; i++)
                people.Add(new PersonModel { Id = i + 1, FullName = "Diego Porras", Age = 19 });

            PersonModel response = people.Where(x => x.Id == request.Id).FirstOrDefault();

            return response;
        }

        [HttpPost]
        public PersonResponse GetByFiltrer2(PersonRequest request)
        {
            List<PersonResponse> people = new List<PersonResponse>();
            for (int i = 0; i < 20; i++)
                people.Add(new PersonResponse { FirstName = "Diego ", LastName = "Porras" });

            PersonResponse response = people.FirstOrDefault();

            return response;
        }

        [HttpPost]
        public ResponseBase Insert()
        {
            ResponseBase response = new ResponseBase();
            response.Code = -1;
            response.Message = "La persona ya existe";   
            return response;
        }
    }
}
