using Next3.Domain.Interfaces;
using Next3.Infra.Data.Context;

namespace Next3.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Next3Context _context;

        public UnitOfWork(Next3Context context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
