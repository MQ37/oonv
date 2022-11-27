using System;
namespace OONV
{
    public class Hero : EntityAttacker
    {


        public int Armor { get; private set; }
        public int Agility { get; private set; }
        public int Inteligence { get; private set; }

        public Hero(int health, Attack attack, Sprite sprite) : base(health, attack, sprite)
        {
            this.Armor = 0;
            this.Agility = 0;
            this.Inteligence = 0;
        }

        public void UpdateArmor(int armor)
        {
            if (this.Armor + armor > 0)
            {
                this.Armor += armor;
            }
        }

        public void UpdateHealth(int health)
        {
            if (this.Health + health > 0) {
                this.Health += health;
                this.MaxHealth += health;
            }
        }

        public void UpdateAgility(int agility)
        {
            if (this.Agility + agility > 0)
            {
                this.Agility += agility;
            }
        }

        public void UpdateInteligence(int inteligence)
        {
            if (this.Inteligence + inteligence > 0)
            {
                this.Inteligence += inteligence;
            }
        }
    }
}
