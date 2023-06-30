

using PersonManagement.Domain.Entities;
using PersonManagement.Domain.Interfaces;
using System.Data;
using System.Reflection.Metadata;

namespace PersonManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext,
                          IRepository<Person> personRepository)
        {
            _dbContext = dbContext;
            PersonRepository = personRepository;
        }

        public IRepository<Person> PersonRepository { get; }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
