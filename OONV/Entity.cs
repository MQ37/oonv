using System;
namespace OONV
{
    public abstract class Entity
    {
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set;  }
        public Sprite Sprite { get; protected set; }

        protected Entity(int health, Sprite sprite)
        {
            this.Health = health;
            this.MaxHealth = health;
            this.Sprite = sprite;
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
