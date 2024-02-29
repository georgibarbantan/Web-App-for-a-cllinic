using HealthTech331.Models;

namespace HealthTech331.Repository
{
    public interface IRepostoryDoctor
    {
        IEnumerable<Doctor> GetAll();

    }
}
