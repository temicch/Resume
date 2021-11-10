using Resume.Domain;

namespace Resume.Application.Interfaces;

public interface IPersonProvider
{
    public Task<Person?> GetAsync(CancellationToken cancellationToken = default);
}