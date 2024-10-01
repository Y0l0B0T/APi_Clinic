using System.Threading.Tasks;

namespace Clinic.Entity
{
    public interface UnitOfWork
    {
        void Save();
    }
}
