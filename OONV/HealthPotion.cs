using System;
namespace OONV
{
    public class HealthPotion : Item, IHeroApplicable
    {

        private int health;

        public HealthPotion(string name, int health) : base(name)
        {
            this.health = health;
        }

        public void Apply(Hero hero)
        {
            hero.Heal(this.health);
        }
    }
}
