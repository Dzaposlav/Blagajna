using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOblagajna.Models
{
    public abstract class EntityBase<TId> : IEquatable<EntityBase<TId>>
    {
        protected EntityBase(TId id)
        {
            if (Equals(id, default(TId)))
            {
                throw new ArgumentException("Id cannot be the default value", "id");
            }
            Id = id;
        }

        public TId Id { get; set; }

        public bool Equals(EntityBase<TId> other)
        {
            if(other == null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            var entity = obj as EntityBase<TId>;
            if(entity != null)
            {
                return Equals(entity);
            }
            return base.Equals(obj);
        }
    }

}
