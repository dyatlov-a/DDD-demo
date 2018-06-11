using System;
using DDD.Domain.Interfaces;

namespace DDD.EntityFramework.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public int Save()
        {
            if (!_context.ChangeTracker.HasChanges())
                return 0;

            return _context.SaveChanges();
        }
    }
}
