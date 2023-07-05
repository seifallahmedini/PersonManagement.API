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

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task AddAsync(Person entity)
        {
            await _context.Persons.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}
