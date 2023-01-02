using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.models;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {

        private readonly DataContext _context; 
        public EventoController(DataContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public IEnumerable<Evento>  Get()
        {
           return _context.MyProperty; 
        }

      //   vamos fazer um get esperando um id 
      // faremos isso para ele retornar o evento relacionado 
      // com o id que foi passado 
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.MyProperty.FirstOrDefault(
                evento => evento.EventoId == id
            );
        }

        [HttpPost]
        public string Post()
        {
           return "exemplo de POST"; 
        }

        // aqui passaremos um parametro 
        [HttpPut("{id}")]
        public string Put(int id)
        {
           return $"exemplo de PUT com id {id}"; 
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
           return $"exemplo de DELETE com id {id}"; 
        }


    }
}
