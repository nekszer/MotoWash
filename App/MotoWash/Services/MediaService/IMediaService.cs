using System.IO;
using System.Threading.Tasks;

namespace MotoWash.Services
{
    public interface IMediaService
    {
        Task<Stream> GetMedia(string title, string cancel);
    }
}
