using System;
namespace OONV
{
    public class Enemy : EntityAttacker
    {
        private int dropRate;
        public Enemy(int health, Attack attack, Sprite sprite) : base(health, attack, sprite)
        {
            this.dropRate = 20;
        }

        public Enemy(Attack attack, Sprite sprite) : this(20, attack, sprite)
        {

        }

        public void UpdateHealth(int health)
        {
            if (this.Health + health > 0)
            {
                this.Health += health;
                this.MaxHealth += health;
            }
        }

        public void UpdateDropRate(int dropRate)
        {
            if (this.dropRate + dropRate > 0)
            {
                this.dropRate = dropRate;
            }
        }

        public void UpdateDamage(int damage)
        {
            this.Attack.UpdateDamage(damage);
        }

        public Item DropItem()
        {
            Random rnd = new Random();
            if (rnd.Next(100) < this.dropRate)
            {
                return new HealthPotion("Lesser Health Potion", 10);
            }

            return null;
        }

        public void Load(GameSave save)
        {
            this.Health = save.EnemyHealth;
        }
    }
}
