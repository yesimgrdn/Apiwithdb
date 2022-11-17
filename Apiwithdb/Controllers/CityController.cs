using Apiwithdb.Data;
using Apiwithdb.Entities;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apiwithdb.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        MyContext _db;
        Response _response;
        public CityController(MyContext db, Response response)
        {
            _db = db;
            _response = response;
        }
        [HttpGet]
        public List<City> GetCities()
        {
            return _db.Set<City>().ToList();

        }
        [HttpGet("{id:int}")]
        public City GetCity(int id)
        {

            return _db.Set<City>().Find(id);
        }
        [HttpPost]
        public Response Add(City c)
        {
            //program.cs response tanımla
            try
            {
                _db.Set<City>().Add(c);
                _db.SaveChanges();
                _response.Error = false;
                _response.Msg = $"{c.Name} Başarılı şekilde eklendi";

            }
            catch (Exception ex)
            {

                _response.Error = true;
                _response.Msg = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public Response Update(City c)
        {
            //program.cs response tanımla
            try
            {
                _db.Set<City>().Update(c);
                _db.SaveChanges();
                _response.Error = false;
                _response.Msg = $"{c.Name}Başarılı şekilde güncellendi";

            }
            catch (Exception ex)
            {

                _response.Error = true;
                _response.Msg = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public Response Delete(City c)
        {
            //program.cs response tanımla
            try
            {
                _db.Set<City>().Remove(c);
                _db.SaveChanges();
                _response.Error = false;
                _response.Msg = $"{c.Name}Başarılı şekilde silindi";

            }
            catch (Exception ex)
            {

                _response.Error = true;
                _response.Msg = ex.Message;
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public Response DeletebyId(int id)
        {
            //program.cs response tanımla
            var c=GetCity(id);
            return Delete(c);
        }





    }



}

