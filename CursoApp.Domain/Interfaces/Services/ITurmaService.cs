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
    public interface ITurmaService
    {
        void Criar(Turma turma);
        AlterarTurmaResponseDto Alterar(Guid id, AlterarTurmaRequestDto dto);
        List<Turma> GetTurmas();
        Turma? GetById(Guid id);
        void Excluir(Guid id);
    }
}
