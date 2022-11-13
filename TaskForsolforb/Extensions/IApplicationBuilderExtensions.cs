using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace TaskForsolforb.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseSwagger(this IApplicationBuilder app)
        {
            SwaggerBuilderExtensions.UseSwagger(app);


            app.UseSwaggerUI(config =>
            {
                config.DefaultModelsExpandDepth(-1);
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskForSolforb API V1");
                config.RoutePrefix = "swagger";
                config.DocExpansion(DocExpansion.None);
                config.EnableFilter();
                config.OAuthConfigObject = new OAuthConfigObject()
                {
                    AppName = "TaskForSolforb.UI",
                    ClientId = "TaskForSolforb.UI",
                    UsePkceWithAuthorizationCodeGrant = true
                };

            });
        }
    }
}
