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
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarAlunoResponseDto), 201)]
        public IActionResult Post(CriarAlunoRequestDto dto)
        {
            try
            {
                var aluno = new Aluno()
                {
                    Nome = dto.Nome,
                    Cpf = dto.Cpf,
                    Email = dto.Email,
                    Id = Guid.NewGuid(),
                };

                _alunoService.Criar(aluno, dto.TurmaId.Value);

                var response = new CriarAlunoResponseDto()
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Cpf = aluno.Cpf,
                    Email = aluno.Email,
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
        [ProducesResponseType(typeof(AlterarAlunoResponseDto), 200)]
        public IActionResult Put(Guid id, AlterarAlunoRequestDto dto)
        {
            try
            {
                var response = _alunoService.Alterar(id, dto);

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
        [ProducesResponseType(typeof(List<ConsultarAlunosReponseDto>), 200)]
        public IActionResult Get()
        {
            try
            {
                var response = _alunoService.GetAlunos();

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
        [ProducesResponseType(typeof(ExcluirAlunoResponseDto), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var aluno = _alunoService.GetById(id);
                _alunoService.Excluir(id);

                var response = new ExcluirAlunoResponseDto()
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Cpf = aluno.Cpf,
                    Email = aluno.Email,
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
