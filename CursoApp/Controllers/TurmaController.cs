using CursoApp.Domain.Interfaces.Services;
using CursoApp.Domain.Models.Dtos.Requests;
using CursoApp.Domain.Models.Dtos.Responses;
using CursoApp.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarTurmaResponseDto), 201)]
        public IActionResult Post(CriarTurmaRequestDto dto)
        {
            try
            {
                var turma = new Turma()
                {
                    Nome= dto.Nome,
                    Numero = dto.Numero,
                    AnoLetivo = dto.AnoLetivo,
                    Nivel = dto.Nivel,
                    Id = Guid.NewGuid()
                };

                _turmaService.Criar(turma);

                var response = new CriarTurmaResponseDto()
                {
                    Nome = turma.Nome,
                    Numero = turma.Numero,
                    AnoLetivo = turma.AnoLetivo,
                    Nivel = turma.Nivel,
                    Id = turma.Id
                };

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AlterarTurmaResponseDto), 200)]
        public IActionResult Put(Guid id, AlterarTurmaRequestDto dto)
        {
            try
            {               
                var response = _turmaService.Alterar(id, dto);               

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarTurmasResponseDto>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _turmaService.GetTurmas();
                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirTurmaResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var turma = _turmaService.GetById(id);
                _turmaService.Excluir(id);

                var response = new ExcluirTurmaResponseDto()
                {
                    Id = turma.Id,
                    Nome = turma.Nome,
                    Numero = turma.Numero,
                    AnoLetivo = turma.AnoLetivo,
                    Nivel = turma.Nivel,
                    DataHoraExclusao = DateTime.Now
                };

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(422, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
