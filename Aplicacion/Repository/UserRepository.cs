using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Infrastructure.Repositories;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly StudentsContext _context;

        public UserRepository(StudentsContext context) : base(context)
        {
            _context = context;
        }
    }
}