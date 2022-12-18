using System;
namespace OONV
{
    public class Enemy : EntityAttacker
    {

        public Enemy(int health, Attack attack, Sprite sprite) : base(health, attack, sprite)
        { 

        }

        public void UpdateHealth(int health)
        {
            if (this.Health + health > 0)
            {
                this.Health += health;
            }
        }

        public Item DropItem()
        {
            Random rnd = new Random();
            if (rnd.Next(100) > 80)
            {
                return new HealthPotion("Lesser Health Potion", 10);
            }

            return null;
        }
    }
}
