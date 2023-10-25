using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interfaces;

namespace Core.Interfaces
{
    public interface IUnitOfWork
    {
        IUser Usuarios { get; }
        IRol Roles { get; }
        Task<int> SaveAsync();
    }
}