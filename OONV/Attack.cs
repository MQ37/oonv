using System;
namespace OONV
{
    public abstract class Attack
    {
        public int Damage { get; private set; }
        public AttackType AttackType { get; private set; }

        protected Attack(int damage, AttackType attackType)
        {
            this.Damage = damage;
            this.AttackType = attackType;
        }

        public void Do(Entity to)
        {
            to.TakeHit(this.Damage);
        }

        public void Do(EntityAttacker from, EntityAttacker to, int hits)
        {
            to.TakeHit(from, this.Damage, hits);
        }
    }
}
