using LightForms.Services;

namespace MotoWash.Services
{
    public class ServiceHandler : IServiceHandler
    {
        public const string ServicesNameSpace = "MotoWash.Services";
        string IServiceHandler.ServicesNameSpace
        {
            get => ServicesNameSpace;
            set { }
        }
    }
}