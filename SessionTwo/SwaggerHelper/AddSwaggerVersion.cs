using Microsoft.AspNetCore.Mvc;

namespace SessionTwo.SwaggerHelper
{
    public static class AddSwaggerVersion
    {
        public static void AddSwaggerVersionedApiExplorer(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        }

    }

}
