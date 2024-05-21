using ProjetWebApi.Data.DatabaseContext;
using ProjetWebApi.Data.Entities;

namespace ProjetWebApi.Models
{
    public class DbHelper
    {
        private DataContext _context;
        public DbHelper(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// READ
        /// </summary>
        /// <returns></returns>
        public List<UtilisateurModel> GetUtilisateurs()
        {
            List<UtilisateurModel> response = new List<UtilisateurModel>();
            var dataList = _context.Utilisateurs.ToList();
            dataList.ForEach(row => response.Add(new UtilisateurModel()
            {
                email = row.email,
                mdp = row.mdp,
                age = row.age,
            }));
            return response;
        }

        public UtilisateurModel GetUtilisateurById(int id)
        {
            UtilisateurModel response = new UtilisateurModel();
            var row = _context.Utilisateurs.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new UtilisateurModel()
            {
                email = row.email,
                mdp = row.mdp,
                age = row.age,
            };
        }

        /// <summary>
        /// CREATE + UPDATE
        /// </summary>
        /// <param name="utilisateurModel"></param>
        public void SaveUtilisateur(UtilisateurModel utilisateurModel)
        {
            Utilisateur dbTable = new Utilisateur();
            if(utilisateurModel.id > 0)
            {
                //PUT
                dbTable = _context.Utilisateurs.Where(d => d.id.Equals(utilisateurModel.id)).FirstOrDefault();
                if(dbTable != null)
                {
                    dbTable.email = utilisateurModel.email;
                    dbTable.mdp = utilisateurModel.mdp;
                    dbTable.age = utilisateurModel.age;
                }
                else
                {
                    //POST
                    dbTable = new Utilisateur
                    {
                        email = utilisateurModel.email,
                        mdp = utilisateurModel.mdp,
                        age = utilisateurModel.age
                    };
                _context.Utilisateurs.Add(dbTable);

            }
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteUtilisateur(int id)
        {
            var utilisateur = _context.Utilisateurs.Where(d => d.id.Equals(id)).FirstOrDefault();
            if(utilisateur != null)
            {
                _context.Utilisateurs.Remove(utilisateur);
                _context.SaveChanges();
            }
        }
    }
}
