using System;
namespace OONV
{
    [Serializable]
    public class GameSave
    {
        public int HeroHealth { get; private set; }
        public int EnemyHealth { get; private set; }
        public int Level { get; private set; }

        public GameSave(int heroHealth, int enemyHealth, int level)
        {
            this.HeroHealth = heroHealth;
            this.EnemyHealth = enemyHealth;
            this.Level = level;
        }

        public GameSave() : this(0, 0, 0)
        {
        }
    }
}
