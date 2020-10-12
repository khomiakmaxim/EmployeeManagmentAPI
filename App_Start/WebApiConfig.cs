using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using WebApiContrib.Formatting.Jsonp;

namespace EmployeeService
{
    //public class CustomJsonFormatter : JsonMediaTypeFormatter
    //{
    //    public CustomJsonFormatter()
    //    {
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    //    }

    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    }
    //}

    public static class WebApiConfig
    {        

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //below code is used for enabling cross domain ajax call
            var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            config.Formatters.Insert(0, jsonpFormatter);

            //wiht class CustomJsonFormatter this is alternative solution for changing respond type in browser
            //config.Formatters.Add(new CustomJsonFormatter());

            //config.Formatters.Remove(config.Formatters.XmlFormatter);//will completely remove xml formatters
            //config.Formatters.Remove(config.Formatters.JsonFormatter);
            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;//
            //this is going to properly indent json data in respond
            //now brower will support json respond
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
