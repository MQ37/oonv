using System;
namespace OONV
{
    public abstract class EntityAttacker : Entity
    {

        public Attack Attack { get; protected set; }

        protected EntityAttacker(int health, Attack attack) : base(health)
        {
            this.Attack = attack;
        }

        public void DoAttack(Entity to)
        {
            this.Attack.Do(to);
        }

        public void DoAttack(EntityAttacker to)
        {
            this.DoAttack(to, 0);
        }

        public void DoAttack(EntityAttacker to, int hits)
        {
            Console.WriteLine("Attack");
            this.Attack.Do(this, to, hits);
        }

        virtual public void TakeHit(EntityAttacker from, int damage, int hits)
        {
            hits += 1;

            Random rnd = new Random();
            if (from.IsAlive() && rnd.Next(100) > 70 + Math.Pow(2, hits+1))
            {
                this.DoAttack(from, hits);
            }
            base.TakeHit(damage);
        }
    }
}
