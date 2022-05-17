using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
using Entidad;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class ProductoController : ControllerBase
    {
        private ProductoDAO procesosGeneralesDAO;


        // GET: api/values
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return new Repositorio.ProductoDAO().Listar().value;
        }

        // GET api/values/5
        [HttpGet("{id}")]
       // [Route("BuscarId")]
        public IEnumerable<Producto> BuscarId(int id)
        {
            return new Repositorio.ProductoDAO().BuscarId(id).value;
            //return Content(JsonConvert.SerializeObject(Repositorio.ProductoDAO().BuscarId(id)), "application/json");
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Producto value)
        {
            var repostorio = new Repositorio.ProductoDAO();

            repostorio.Insertar(value);

            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto value)
        {
            value.Codigo = id;
            var repo = new Repositorio.ProductoDAO();
            repo.Actualizar(value);
            return Ok(value);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var repo = new Repositorio.ProductoDAO();
            repo.Eliminar(id);
        }

    }
}
