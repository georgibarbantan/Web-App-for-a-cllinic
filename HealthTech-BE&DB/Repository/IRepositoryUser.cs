using HealthTech331.Models;

namespace HealthTech331.Repository
{
    public interface IRepositoryUser
    {
        IEnumerable<ApplicationUser> GetAll();

        Task<ApplicationUser> GetById(int id);

        ApplicationUser Update(ApplicationUser user);

        void Delete(ApplicationUser @user);




    }
}
