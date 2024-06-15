using LinqToDB;
using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;
using System.Threading;
using UserModel = DataModel.User;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IUserRepository"/>
internal sealed class UserRepository(DatabaseQueryWrapper queryWrapper) : IUserRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;

    public Task<bool> IsUserExistsByLogin(string login, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
            await db.Users.AnyAsync(x => x.Login == login, cancellationToken)
        );
    }

    public Task<long> CreateAsync(User item, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
        {
            return (long)await db.Users.InsertAsync(() => new UserModel
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Login = item.Login,
                Password = item.Password!,
                BirthDay = Convert.ToDateTime(item.Birthday)
            });
        });
    }

    public Task<User> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
           await db.Users
                .Where(x => x.Id == id)
                .Select(x => new User
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Login = x.Login,
                    Birthday = DateOnly.FromDateTime(x.BirthDay), 
                })
                .SingleAsync(cancellationToken)
        );
    }

    public Task<IEnumerable<User>> GetAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAsync(Func<User, bool> predicate, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> RemoveAsync(User item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<long> UpdateAsync(User item, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}