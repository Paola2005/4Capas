using Aplicacion.Repository;
using Core.Interfaces;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Infrastructura.UnitOfWork
{
    public class UnitOfWork :IUnitOfWork,IDisposable
    {
        private readonly StudentsContext _context;

        private RolRepository _rol ;
        private UserRepository _user ;

        public IRol Roles{
            get{
                if(_rol==null)
                {
                    _rol=new RolRepository(_context);
                }
                return _rol;
            }
        }

        public IUser Usuarios {
            get{
                if(_user==null)
                {
                    _user=new UserRepository(_context);
                }
                return _user;
            }
            }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
        }