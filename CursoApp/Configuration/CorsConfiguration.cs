﻿namespace CursoApp.Configuration
{
    public class CorsConfiguration
    {
        public static void AddCorsConfiguration(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AgendaPolicy", builder =>
                {
                    builder.WithOrigins(
                                "http://localhost:4200"
                            )
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        public static void UseCorsConfiguration(IApplicationBuilder app)
        {
            app.UseCors("AgendaPolicy");
        }

    }
}
