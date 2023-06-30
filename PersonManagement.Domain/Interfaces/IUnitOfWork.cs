using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> PersonRepository { get; }

        Task<int> SaveChangesAsync();
    }

}
