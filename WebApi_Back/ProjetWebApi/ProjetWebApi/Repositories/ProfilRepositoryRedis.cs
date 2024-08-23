using Newtonsoft.Json;
using ProjetWebApi.Data.Entities;
using StackExchange.Redis;

namespace ProjetWebApi.Repositories
{
    public class ProfilRepositoryRedis
    {
        private static readonly ConnectionMultiplexer redis = ConnectionMultiplexer
            .Connect("redis-11955.c339.eu-west-3-1.ec2.redns.redis-cloud.com:11955,password=PN5bWjv3H7ZKeTv9RwIkAJcNPLpMYpix");
        private readonly IDatabase _database;

        public ProfilRepositoryRedis()
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
