using System;

namespace MotoWash.Services
{
    public class DevelopmentBaseUrl : IBaseUrl
    {
        public string Get()
        {
            return "http://localhost:8080/api";
        }
    }
}