using Newtonsoft.Json;
using ProjetWebApi.Data.Entities;
using StackExchange.Redis;

namespace ProjetWebApi.Repositories
{
    public class UserRepositoryRedis
    {
        private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer
            .Connect("redis-11955.c339.eu-west-3-1.ec2.redns.redis-cloud.com:11955,password=PN5bWjv3H7ZKeTv9RwIkAJcNPLpMYpix");
        private readonly IDatabase _database;

        public UserRepositoryRedis()
        {
            _database = redis.GetDatabase();
        }

        public void CreateUser(User user)
        {
            long newId = _database.StringIncrement("user:id_counter");

            user.Id = (int)newId;

            var json = JsonConvert.SerializeObject(user);

            _database.StringSet($"user:{user.Id}", json);
        }

        public User GetById(int userId)
        {
            var json = _database.StringGet($"user:{userId}");
            return json.HasValue ? JsonConvert.DeserializeObject<User>(json) : null;
        }

        public void UpdateUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            _database.StringSet($"user:{user.Id}", json);
        }

        public void DeleteUser(int userId)
        {
            _database.KeyDelete($"user:{userId}");
        }
    }
}
