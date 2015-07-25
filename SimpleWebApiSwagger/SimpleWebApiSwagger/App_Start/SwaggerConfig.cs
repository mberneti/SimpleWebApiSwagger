using System;
using System.Web.Http;
using WebActivatorEx;
using SimpleWebApiSwagger;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SimpleWebApiSwagger
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            // NOTE: If you want to customize the generated swagger or UI, use SwaggerSpecConfig and/or SwaggerUiConfig here ...

            GlobalConfiguration.Configuration 
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "SimpleWebApiSwagger");
                        // set xml comments path
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi();
        }
        static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\bin\SimpleWebApiSwagger.XML", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}