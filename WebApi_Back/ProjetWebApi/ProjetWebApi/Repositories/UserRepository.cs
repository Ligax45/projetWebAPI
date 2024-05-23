using Newtonsoft.Json;
using ProjetWebApi.Data.Entities;
using StackExchange.Redis;

namespace ProjetWebApi.Repositories
{
    public class UserRepository
    {
        private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer
            .Connect("redis-10243.c72.eu-west-1-2.ec2.redns.redis-cloud.com:10243,password=2L7I5GMXcx0PjiWPa1dpPlRhFzaPGk8o");
        private readonly IDatabase _database;

        public UserRepository()
        {
            _database = redis.GetDatabase();
        }

        public void CreateUser(Utilisateur user)
        {
            var json = JsonConvert.SerializeObject(user);
            _database.StringSet($"user:{user.id}", json);
        }

        public Utilisateur GetUser(int userId)
        {
            var json = _database.StringGet($"user:{userId}");
            return json.HasValue ? JsonConvert.DeserializeObject<Utilisateur>(json) : null;
        }

        public void UpdateUser(Utilisateur user)
        {
            var json = JsonConvert.SerializeObject(user);
            _database.StringSet($"user:{user.id}", json);
        }

        public void DeleteUser(int userId)
        {
            _database.KeyDelete($"user:{userId}");
        }
    }
}
