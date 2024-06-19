using LinqToDB;
using ProductTracker.Domain.Entity;
using ProductTracker.Domain.Repository;
using ProductTracker.Infrastructure.Db;
using ProductTracker.Infrastructure.Mapper;
using UserModel = DataModel.User;

namespace ProductTracker.Infrastructure.Repository;

/// <inheritdoc cref="IUserRepository"/>
internal sealed class UserRepository(DatabaseQueryWrapper queryWrapper) : IUserRepository
{
    private readonly DatabaseQueryWrapper _queryWrapper = queryWrapper;
    private readonly UserMapper _userMapper = new();

    public Task<bool> IsExistsByLogin(string login, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
            await db.Users.AnyAsync(x => x.Login == login, cancellationToken)
        );
    }

    public Task<User?> GetByLogin(string login, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db => {
            var user = await db.Users
                .FirstOrDefaultAsync(x => x.Login == login, cancellationToken);

            return user != null ? _userMapper.MapUserModelToDomain(user) : null;
        });
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
                BirthDay = item.Birthday.ToDateTime(TimeOnly.MinValue),
            }, token: cancellationToken);
        });
    }

    public Task<User> FindByIdAsync(long id, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
            await Task.FromResult(db.Users
                .Where(x => x.Id == id)
                .AsEnumerable()
                .Select(_userMapper.MapUserModelToDomain)
                .Single())
        );
    }

    public Task<IEnumerable<User>> GetAsync(CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync<IEnumerable<User>>(async db =>
            await Task.FromResult(
                db.Users
                   .Select(_userMapper.MapUserModelToDomain)
                   .ToList()
        ));
    }

    public Task<IEnumerable<User>> GetAsync(Func<User, bool> predicate, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync<IEnumerable<User>>(async db =>
            await Task.FromResult(
                db.Users
                   .Select(_userMapper.MapUserModelToDomain)
                   .Where(predicate)
                   .ToList()
        ));
    }

    public Task<long> RemoveAsync(User item, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
           (long)await db.Users
                   .DeleteAsync(x => x.Id == item.Id, cancellationToken)
        );
    }

    public Task<long> UpdateAsync(User item, CancellationToken cancellationToken)
    {
        return _queryWrapper.ExecuteAsync(async db =>
           (long)await db.Users
                .Where(x => x.Id == item.Id)
                .Set(x => x.FirstName, item.FirstName)
                .Set(x => x.LastName, item.LastName)
                .Set(x => x.Password, item.Password)
                .UpdateAsync(cancellationToken)
        );
    }
}