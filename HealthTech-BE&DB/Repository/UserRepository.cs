using HealthTech331.Models;

namespace HealthTech331.Repository
{
    public class UserRepository : IRepositoryUser
    {
        private readonly HealthTechContext _dbcontext;

        public UserRepository()
        {
            _dbcontext = new HealthTechContext();
        }

        public ApplicationUser addUser(ApplicationUser @user)
        {
            var userEntry = _dbcontext.Add(@user);
            _dbcontext.SaveChanges();
            var u = userEntry.Entity;
            return u;

        }

        public void Delete(ApplicationUser @user) {
            var userEntry = _dbcontext.Remove(@user);
            _dbcontext.SaveChanges();
        
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            var @users = _dbcontext.ApplicationUsers.ToList();
            return @users;
        }

        public ApplicationUser Update(ApplicationUser @user)
        {
            var userEntry = _dbcontext.Update(@user);
            _dbcontext.SaveChanges();
            ApplicationUser u = userEntry.Entity;
            return u;
        }

        public async Task<ApplicationUser> GetById(int id)
        {
            var @user = _dbcontext.ApplicationUsers.FirstOrDefault(u => u.UserId == id);
            if(@user == null)
            {
                return null;
            }
            return @user;
        }

        //IEnumerable<Entities.ApplicationUser> IRepositoryUser.GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<Entities.ApplicationUser> IRepositoryUser.GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Entities.ApplicationUser Update(Entities.ApplicationUser user)
        //{
        //    throw new NotImplementedException();
        //}

        //public Entities.ApplicationUser Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
