using System.Threading.Tasks;

namespace MotoWash.Services
{
    public interface IActionSheetService
    {
        Task<string> Show(string title, string cancel, params string[] options);
    }
}