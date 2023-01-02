using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
      public IEnumerable<Evento> _evento  = new Evento[] {
            new Evento() {
               EventoId = 1,
               Tema = "Angular 11 e .NET 5", 
               Local = "Belo Horizonte", 
               Lote = "1º Lote", 
               QtdPessoas = 250, 
               DataEvento = DateTime.Now.AddDays(2).ToString(), 
               ImagemURL = "foto.png"
           }, 
            new Evento() {
               EventoId = 2,
               Tema = "React e Node JS", 
               Local = "Praia Gramde", 
               Lote = "2º Lote", 
               QtdPessoas = 250, 
               DataEvento = DateTime.Now.AddDays(3).ToString(), 
               ImagemURL = "foto1.png"
           }
         }; 

        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento>  Get()
        {
           return _evento; 
        }

      //   vamos fazer um get esperando um id 
      // faremos isso para ele retornar o evento relacionado 
      // com o id que foi passado 
        [HttpGet("{id}")]
        public IEnumerable<Evento>  GetById(int id)
        {
           return _evento.Where(evento => evento.EventoId == id); 
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
