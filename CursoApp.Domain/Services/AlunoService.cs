using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Domain.Interfaces.Services;
using CursoApp.Domain.Models.Dtos.Requests;
using CursoApp.Domain.Models.Dtos.Responses;
using CursoApp.Domain.Models.Entities;
using CursoApp.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CursoApp.Domain.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public AlunoService(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository, IMatriculaRepository matriculaRepository)
        {
            _alunoRepository = alunoRepository;
            _turmaRepository = turmaRepository;
            _matriculaRepository = matriculaRepository;
        }

        public AlterarAlunoResponseDto Alterar(Guid id,AlterarAlunoRequestDto dto)
        {
            var alterarAluno = _alunoRepository.GetById(id);
            if (alterarAluno == null)
                throw new ApplicationException("Aluno não encontrado. Verifique o ID informado.");

            alterarAluno.Nome = dto.Nome;
            alterarAluno.Cpf = dto.Cpf;
            alterarAluno.Email = dto.Email;

            var validator = new AlunoValidator();
            validator.Validate(alterarAluno);

            _alunoRepository.Update(alterarAluno);

            return GetResponse(alterarAluno);
        }

        public void Criar(Aluno aluno, Guid turmaId)
        {
            var turma = _turmaRepository.GetById(turmaId);

            if(turma == null)
            {
                throw new ArgumentException("A turma não foi encontrada. Verifique o ID informado");
            }

            var matriculaExiste = _matriculaRepository.GetById(turma.Id, aluno.Id);

            if (matriculaExiste != null)
            {
                throw new ArgumentException("Este aluno já foi matriculado nesta turma.");
            }

            var quantidadeMatriculas = _matriculaRepository.QuantidadeMatricular(turma.Id);

            if (quantidadeMatriculas >= 5)
            {
                throw new ArgumentException("Esta turma já possui 5 alunos matriculados (máximo permitido).");
            }

            _alunoRepository.Add(aluno);

            var matricula = new Matricula();
            matricula.TurmaId = turmaId;
            matricula.AlunoId = aluno.Id;

            _matriculaRepository.Add(matricula);
        }

        public void Excluir(Guid id)
        {
            var aluno = _alunoRepository.GetById(id);

            if(aluno == null)
            {
                throw new ArgumentException("O aluno não foi encontrado. Verifique o ID informado");
            }

            if (_matriculaRepository.VerificarAluno(aluno.Id))
            {
                throw new ArgumentException("O aluno não pode ser excluído pois está matriculado empelo menos uma turma");
            }

            _alunoRepository.Delete(aluno.Id);
        }

        public List<Aluno> GetAlunos()
        {
            var response = _alunoRepository.GetAll();
            if(response != null)
            {
                return response.ToList();
            }
            else
            {
                throw new ArgumentException("Não existem alunos cadastrados.");
            }
        }

        public Aluno? GetById(Guid id)
        {
            var response = _alunoRepository.GetById(id);
            return response;
        }

        private AlterarAlunoResponseDto GetResponse(Aluno aluno)
        {
            var response = new AlterarAlunoResponseDto
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Email = aluno.Email,
                Cpf = aluno.Cpf,
            };

            return response;
        }
    }
}
