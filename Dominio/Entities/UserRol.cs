using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class UserRol : BaseEntity
    {
        public int UserIdFk { get; set; }
        public User Users { get; set; }
        public int RolIdFk { get; set; }
        public Rol Rols { get; set; }
    }
}
