using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService; 

        private readonly ProEventosContext _context; 
        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosAsync(true); 
                if(eventos == null) return NotFound("Nenhum evento encontrado"); 

                return Ok(eventos); 
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, 
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var eventos = await _eventoService.GetEventoByIdAsync(id, true);
                if (eventos == null) return NotFound("Evento por Id não encontrado");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        // vamos colocar /tema para que sejam 2 rotas diferentes  
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
                if (eventos == null) return NotFound("Eventos por tema não encontrados");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Evento model)
        {
           try
            {
                var eventos = await _eventoService.AddEventos(model);
                if (eventos == null) return BadRequest("Erro ao tentar adicionar o evento");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar adicionar eventos. Erro: {ex.Message}");
            }
        }

        // aqui passaremos um parametro 
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Evento model)
        {
             try
            {
                var eventos = await _eventoService.UpdateEvento(id, model);
                if (eventos == null) return BadRequest("Erro ao atualizar evento");

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
             try
            {
                return await _eventoService.DeleteEvento(id) ?  
                    Ok("Evento deletado")  : 
                BadRequest("Evento não deletado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar deletar os eventos. Erro: {ex.Message}");
            }
        }


    }
}
