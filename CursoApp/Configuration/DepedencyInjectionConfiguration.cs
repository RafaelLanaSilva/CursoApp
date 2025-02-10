using CursoApp.Domain.Interfaces.Repositories;
using CursoApp.Domain.Interfaces.Services;
using CursoApp.Domain.Services;
using CursoApp.Infra.Data.Repositories;

namespace CursoApp.Configuration
{
    public class DepedencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            services.AddTransient<IAlunoService, AlunoService>();
            services.AddTransient<ITurmaService, TurmaService>();
            services.AddTransient<IMatriculaService, MatriculaService>();
            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IMatriculaRepository, MatriculaRepository>();
        }
    }
}
