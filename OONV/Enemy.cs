using System;
namespace OONV
{
    public class Enemy : EntityAttacker
    {

        public Enemy(int health, Attack attack) : base(health, attack)
        { 

        }

        public void UpdateHealth(int health)
        {
            if (this.Health + health > 0)
            {
                this.Health += health;
            }
        }
    }
}
