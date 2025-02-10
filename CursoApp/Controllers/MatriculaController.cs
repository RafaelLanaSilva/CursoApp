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
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaService _matriculaService;

        public MatriculaController(IMatriculaService matriculaService)
        {
            _matriculaService = matriculaService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarMatriculaRequestDto), 201)]
        public IActionResult Cadastro(CriarMatriculaResponseDto dto)
        {
            try
            {
                var matricula = new Matricula()
                {
                    TurmaId = dto.TurmaId.Value,
                    AlunoId = dto.AlunoId.Value
                };

                _matriculaService.Criar(matricula);

                var response = new CriarMatriculaResponseDto()
                {
                    TurmaId = matricula.TurmaId,
                    AlunoId = matricula.AlunoId
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

        [HttpDelete("{turmaId}/{alunoId}")]
        [ProducesResponseType(typeof(ExcluirMatriculaResponseDto), 200)]
        public IActionResult Exclusao(Guid turmaId, Guid alunoId)
        {
            try
            {
                _matriculaService.Excluir(turmaId, alunoId);

                var response = new ExcluirMatriculaResponseDto()
                {
                    TurmaId = turmaId,
                    AlunoId = alunoId
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

        [HttpGet]
        [ProducesResponseType(typeof(ConsultarMatriculaResponseDto), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _matriculaService.GetMatriculas();
                return StatusCode(200, response);
            }
            catch(ApplicationException e)
            {
                return StatusCode(422, new {e.Message });
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

    }
}
