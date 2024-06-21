using Microsoft.EntityFrameworkCore;
using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Data.Entities;
using ProjetWebApi.Models;

namespace ProjetWebApi.Services
{
    public class DbHelper
    {
        private DataContext _context;
        public DbHelper(DataContext context)
        {
            _context = context;
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> response = new List<UserModel>();
            var dataList = _context.Users.ToList();
            dataList.ForEach(row => response.Add(new UserModel()
            {
                Id = row.Id,
                Email = row.Email,
                Password = row.Password,
                Salt = row.Salt,
            }));
            return response;
        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel GetUserById(int id)
        {
            var row = _context.Users.FirstOrDefault(d => d.Id == id);
            if (row != null)
            {
                return new UserModel()
                {
                    Id = row.Id,
                    Email = row.Email,
                    Password = row.Password,
                    Salt = row.Salt,
                };
            }
            return null;
        }

        public void CreateUser(UserModel userModel, string salt)
        {
            User dbTable = new User
            {
                Email = userModel.Email,
                Password = userModel.Password,
                Salt = salt
            };

            _context.Users.Add(dbTable);
            _context.SaveChanges();
        }

        public void UpdateUser(UserModel userModel, string salt)
        {
            User dbTable = _context.Users.FirstOrDefault(d => d.Id == userModel.Id);

            if (dbTable != null)
            {
                dbTable.Email = userModel.Email;
                dbTable.Password = userModel.Password;
                dbTable.Salt = salt;

                _context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            var utilisateur = _context.Users.FirstOrDefault(d => d.Id == id);
            if (utilisateur != null)
            {
                _context.Users.Remove(utilisateur);
                _context.SaveChanges();
            }
        }

        //Profil
        public List<ProfileModel> GetAllProfiles()
        {
            List<ProfileModel> response = new List<ProfileModel>();
            var dataList = _context.Profiles.Include(p => p.User).ToList();

            dataList.ForEach(row => response.Add(new ProfileModel()
            {
                Id = row.Id,
                FirstName = row.FirstName,
                LastName = row.LastName,
                UserId = row.User.Id,
            }));

            return response;
        }

        public ProfileModel GetProfileById(int id)
        {
            var row = _context.Profiles.FirstOrDefault(d => d.Id == id);
            if (row != null)
            {
                return new ProfileModel()
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    UserId = row.User.Id,
                };
            }
            return null;
        }

        public void CreateProfile(ProfileModel profileModel)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == profileModel.UserId);

            if (user != null)
            {
                Profile dbTable = new Profile
                {
                    FirstName = profileModel.FirstName,
                    LastName = profileModel.LastName,
                    User = user
                };

                _context.Profiles.Add(dbTable);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Utilisateur avec l'ID {profileModel.UserId} non trouvé.");
            }
        }

        public void UpdateProfile(ProfileModel profileModel)
        {
            Profile dbTable = _context.Profiles.FirstOrDefault(p => p.Id == profileModel.Id);

            if (dbTable != null)
            {
                dbTable.FirstName = profileModel.FirstName;
                dbTable.LastName = profileModel.LastName;

                var utilisateur = _context.Users.FirstOrDefault(u => u.Id == profileModel.UserId);

                if (utilisateur != null)
                {
                    dbTable.User = utilisateur;
                }
                else
                {
                    throw new ArgumentException($"Utilisateur avec l'ID {profileModel.UserId} non trouvé.");
                }

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Profil avec l'ID {profileModel.Id} non trouvé.");
            }
        }

        public void DeleteProfile(int id)
        {
            var profil = _context.Profiles.FirstOrDefault(d => d.Id == id);
            if (profil != null)
            {
                _context.Profiles.Remove(profil);
                _context.SaveChanges();
            }
        }
    }
}
