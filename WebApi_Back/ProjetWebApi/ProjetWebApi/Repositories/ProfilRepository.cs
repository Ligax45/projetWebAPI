using Newtonsoft.Json;
using ProjetWebApi.Data.Entities;
using StackExchange.Redis;

namespace ProjetWebApi.Repositories
{
    public class ProfilRepository
    {
        private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer
            .Connect("redis-19723.c258.us-east-1-4.ec2.redns.redis-cloud.com:19723,password=3aWyyDQO7gJZR2tqLnY35gk1C2ZxbBT8");
        private readonly IDatabase _database;

        public ProfilRepository()
        {
            _database = redis.GetDatabase();
        }

        public void CreateProfil(Profile profile)
        {
            long newId = _database.StringIncrement("profil:id_counter");

            profile.Id = (int)newId;

            var json = JsonConvert.SerializeObject(new
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                UserId = profile.User.Id
            });

            _database.StringSet($"profil:{profile.Id}", json);
        }

        public Profile GetById(int profilId)
        {
            var json = _database.StringGet($"user:{profilId}");
            return json.HasValue ? JsonConvert.DeserializeObject<Profile>(json) : null;
        }

        public void UpdateProfil(Profile profil)
        {
            var json = JsonConvert.SerializeObject(profil);
            _database.StringSet($"user:{profil.Id}", json);
        }

        public void DeleteProfil(int profilId)
        {
            _database.KeyDelete($"user:{profilId}");
        }

    }
}
