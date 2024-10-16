using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Bootstrap
{
    public class SwaggerHeaderParams : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "Token",
                In = ParameterLocation.Header,
                Description = "Secret Token",
                Required = true
            });
        }
    }
}
