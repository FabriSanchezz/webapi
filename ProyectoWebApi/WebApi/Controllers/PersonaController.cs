﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Data;
using WebApi.Models;



namespace WebApi.Controllers
{
    public class PersonaController : ApiController
    {
        // GET api/<controller>
        public List<Persona> Get()
        {
            return PersonaData.Listar();
        }

        // GET api/<controller>/5
        public Persona Get(int id)
        {
            return PersonaData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Persona oPersona)
        {
            return PersonaData.Registrar(oPersona);
        }

        // PUT api/<controller>/5
        public bool Put([FromBody]Persona oUsuario)
        {
            return PersonaData.Modificar(oUsuario);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return PersonaData.Eliminar(id);
        }
    }
}