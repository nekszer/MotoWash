using System.IO;
using System.Threading.Tasks;

namespace MotoWash.Services
{
    public interface IStreamSource
    {
        Task<Stream> Get();
    }
}