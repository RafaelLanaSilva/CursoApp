using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Domain.Interfaces.Services;
using CursoApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(ITurmaRepository turmaRepository, IAlunoRepository alunoRepository, IMatriculaRepository matriculaRepository)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
            _matriculaRepository = matriculaRepository;
        }

        public void Criar(Matricula matricula)
        {
            var turma = _turmaRepository.GetById(matricula.TurmaId);

            if (turma == null)
            {
                throw new ArgumentException("Turma não encontrada. Verifique o ID informado.");
            }

            var aluno = _alunoRepository.GetById(matricula.AlunoId);

            if(aluno == null)
            {
                throw new ArgumentException("Aluno não encontrado. Verifique o ID informado.");
            }

            var matriculaExiste = _matriculaRepository.GetById(turma.Id, aluno.Id);

            if(matriculaExiste != null)
            {
                throw new ArgumentException("Este aluno já foi matriculado nesta turma.");
            }

            var quantidadeMatriculas = _matriculaRepository.QuantidadeMatricular(turma.Id);

            if(quantidadeMatriculas >= 5)
            {
                throw new ArgumentException("Esta turma já possui 5 alunos matriculados (máximo permitido).");
            }

            _matriculaRepository.Add(matricula);
        }

        public void Excluir(Guid turmaId, Guid alunoId)
        {
            var matricula = _matriculaRepository.GetById(turmaId, alunoId);

            if(matricula == null)
            {
                throw new ArgumentException("Matrícula não encontrada.verifique os Id's informados.");
            }

            _matriculaRepository.Delete(turmaId, alunoId);
        }

        public List<Matricula> GetMatriculas()
        {
            var response = _matriculaRepository.GetAll();
            if(response != null)
            {
                return response.ToList();
            }
            else
            {
                throw new ArgumentException("Não existem turmas cadastradas.");
            }
        }
    }
}
