using System;
namespace OONV
{
    public abstract class Entity
    {
        public int Health { get; protected set; }

        protected Entity(int health)
        {
            this.Health = health;
        }

        virtual public void TakeHit(int damage)
        {
            this.Health -= damage;
        }

        public bool IsAlive()
        {
            return this.Health > 0;
        }
    }
}
