using HealthTech331.Models;

namespace HealthTech331.Repository
{
    public interface IRepositoryPatient
    {
        IEnumerable<Patient> GetAllPatients();

        Patient GetPatientById(int id);

        Patient GetPatientByCNP(string CNP);
    }
}
