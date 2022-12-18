using System;
namespace OONV
{
    public abstract class EntityAttacker : Entity
    {

        public Attack Attack { get; protected set; }

        protected EntityAttacker(int health, Attack attack, Sprite sprite) : base(health, sprite)
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
            if (this.IsAlive())
            {
                Console.WriteLine(String.Format("{0} -> Attack", this.GetType().Name));
                this.Attack.Do(this, to, hits);
            }
            else
            {
                Console.WriteLine(String.Format("{0} -> Cannot attack - entity not alive", this.GetType().Name));
            }
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
