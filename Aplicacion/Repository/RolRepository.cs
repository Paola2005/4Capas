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
    public class RolRepository : GenericRepository<Rol>, IRol
    {
        private readonly StudentsContext _context;

        public RolRepository(StudentsContext context) : base(context)
        {
            _context = context;
        }
    }
}