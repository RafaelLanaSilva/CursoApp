using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Domain.Interfaces.Services;
using CursoApp.Domain.Models.Dtos.Requests;
using CursoApp.Domain.Models.Dtos.Responses;
using CursoApp.Domain.Models.Entities;
using CursoApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public TurmaService(ITurmaRepository turmRepository, IMatriculaRepository matriculaRepository)
        {
            _turmaRepository = turmRepository;
            _matriculaRepository = matriculaRepository;
        }

        public void Criar(Turma turma)
        {
            _turmaRepository.Add(turma);
        }

        public AlterarTurmaResponseDto Alterar(Guid id, AlterarTurmaRequestDto dto)
        {
            var alterarTurma = _turmaRepository.GetById(id);
            if(alterarTurma == null)
            {
                throw new ArgumentException("Turma não encontrada. Verifique o ID informado.");
            }

            alterarTurma.Nome = dto.Nome;
            alterarTurma.Numero = dto.Numero;
            alterarTurma.AnoLetivo = dto.AnoLetivo;
            alterarTurma.Nivel = dto.Nivel;

            var validator = new TurmaValidator();
            var result = validator.Validate(alterarTurma);

            _turmaRepository.Update(alterarTurma);

            return GetResponse(alterarTurma);
          
        }       

        public void Excluir(Guid id)
        {
            var turma = _turmaRepository.GetById(id);

            if(turma == null)
            {
                throw new ArgumentException("Turma não encontrada. Verifique o ID informado.");
            }

            if (_matriculaRepository.VerificarTurma(turma.Id))
            {
                throw new ArgumentException("A turma não pode ser excluído pois possui matricula(s).");
            }

            _turmaRepository.Delete(turma.Id);
        }

        public Turma? GetById(Guid id)
        {
            var response = _turmaRepository.GetById(id);
            return response;
        }

        public List<Turma> GetTurmas()
        {
            var response = _turmaRepository.GetAll();

            if (response != null)
            {
                return response.ToList();
            }
            else
            {
                throw new ArgumentException("Não existem turmas cadastradas.");
            }
        }

        private AlterarTurmaResponseDto GetResponse(Turma turma)
        {
            var response = new AlterarTurmaResponseDto
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Numero = turma.Numero,
                AnoLetivo = turma.AnoLetivo,
                Nivel = turma.Nivel,
            };

            return response;
        }

    }
}
