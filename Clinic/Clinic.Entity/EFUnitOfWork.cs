using System.Threading.Tasks;
using Clinic.Entity.Context;

namespace Clinic.Entity
{
    public class EFUnitOfWork : UnitOfWork
    {
        private readonly ApplicationDbContext
            _context;
        public EFUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
