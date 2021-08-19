using Resume.Domain;
using System.Threading.Tasks;

namespace Resume.Application.Interfaces
{
    public interface IPersonProvider
    {
        public Task<Person> GetAsync();
    }
}