using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;



namespace WebApi.Controllers
{
    public class CiudaddController : ApiController
    {
        // GET api/<controller>
        public List<Ciudadd> Get()
        {
            return CiudadData.Listar();
        }

        // GET api/<controller>/5
        public Ciudadd Get(int id)
        {
            return CiudadData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Ciudadd oCiudadd)
        {
            return CiudadData.Registrar(oCiudadd);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody] Ciudadd oCiudadd)
        {
            return CiudadData.Modificar(oCiudadd);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return CiudadData.Eliminar(id);
        }
    }
}