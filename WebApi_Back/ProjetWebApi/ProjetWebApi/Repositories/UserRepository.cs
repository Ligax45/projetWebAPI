using Newtonsoft.Json;
using ProjetWebApi.Data.Entities;
using StackExchange.Redis;

namespace ProjetWebApi.Repositories
{
    public class UserRepository
    {
        private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer
<<<<<<< HEAD
            .Connect("redis-19723.c258.us-east-1-4.ec2.redns.redis-cloud.com:19723,password=3aWyyDQO7gJZR2tqLnY35gk1C2ZxbBT8");
=======
            .Connect("redis-10243.c72.eu-west-1-2.ec2.redns.redis-cloud.com:10243,password=2L7I5GMXcx0PjiWPa1dpPlRhFzaPGk8o");
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
        private readonly IDatabase _database;

        public UserRepository()
        {
            _database = redis.GetDatabase();
        }

        public void CreateUser(Utilisateur user)
        {
<<<<<<< HEAD
            long newId = _database.StringIncrement("user:id_counter");

            user.Id = (int)newId;

            var json = JsonConvert.SerializeObject(user);

            _database.StringSet($"user:{user.Id}", json);
=======
            var json = JsonConvert.SerializeObject(user);
            _database.StringSet($"user:{user.id}", json);
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
        }

        public Utilisateur GetUser(int userId)
        {
            var json = _database.StringGet($"user:{userId}");
            return json.HasValue ? JsonConvert.DeserializeObject<Utilisateur>(json) : null;
        }

        public void UpdateUser(Utilisateur user)
        {
            var json = JsonConvert.SerializeObject(user);
<<<<<<< HEAD
            _database.StringSet($"user:{user.Id}", json);
=======
            _database.StringSet($"user:{user.id}", json);
>>>>>>> a0d22eb8b541443e64cd8e1363f5175b164539de
        }

        public void DeleteUser(int userId)
        {
            _database.KeyDelete($"user:{userId}");
        }
    }
}
