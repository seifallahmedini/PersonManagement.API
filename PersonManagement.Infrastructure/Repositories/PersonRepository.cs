using Microsoft.EntityFrameworkCore;
using PersonManagement.Domain.Entities;
using PersonManagement.Domain.Interfaces;
using System.Linq.Expressions;

namespace PersonManagement.Infrastructure
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Person>> GetAsync(Expression<Func<Person, bool>> predicate)
        {
            return await _context.Persons.Where(predicate).ToListAsync();
        }

        public async Task<Person?> GetSingleOrDefaultAsync(Expression<Func<Person, bool>> predicate)
        {
            return await _context.Persons.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(Person entity)
        {
            await _context.Persons.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person entity)
        {
            _context.Persons.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person entity)
        {
            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
