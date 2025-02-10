using CursoApp.Domain.Models.Dtos.Requests;
using CursoApp.Domain.Models.Dtos.Responses;
using CursoApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoApp.Domain.Interfaces.Services
{
    public interface IAlunoService
    {
        void Criar(Aluno aluno, Guid turmaId);
        AlterarAlunoResponseDto Alterar(Guid id, AlterarAlunoRequestDto dto);
        List<Aluno> GetAlunos();
        Aluno? GetById(Guid id);
        void Excluir(Guid id);
    }
}
