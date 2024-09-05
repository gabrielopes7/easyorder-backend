using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class Service<Entity>
        where Entity : class
    {
        public virtual Validation Validar(Validation validation, Entity entity)
        {
            validation.AddInconsistence(new ValidationMessage(1, "Service não construida para a entidade. Contate o administrador do sistema."));
            return validation;
        }

        public virtual Validation Validar(Validation validation, Entity entity, Persistencia.Models.ConnectionContext dbContext)
        {
            validation.AddInconsistence(new ValidationMessage(1, "Service não construida para a entidade. Contate o administrador do sistema."));
            return validation;
        }
        public virtual Validation ValidarDesativar(Validation validation, Entity entity)
        {
            return validation;
        }
    }
}
