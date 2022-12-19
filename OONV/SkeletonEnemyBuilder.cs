using System;
namespace OONV
{
    public class SkeletonEnemyBuilder : IEnemyBuilder
    {
        public Enemy CreateSmall()
        {
            Attack attack = new AttackBlunt(2);
            Sprite sprite = new Sprite(EnemySprites.Small);
            Enemy enemy = new Enemy(attack, sprite);
            return enemy;
        }

        public Enemy CreateMedium()
        {
            Attack attack = new AttackBlunt(2);
            Sprite sprite = new Sprite(EnemySprites.Medium);
            Enemy enemy = new Enemy(attack, sprite);

            enemy.UpdateDamage(2);
            enemy.UpdateHealth(10);
            enemy.UpdateDropRate(30);

            return enemy;
        }

        public Enemy CreateLarge()
        {
            Attack attack = new AttackBlunt(2);
            Sprite sprite = new Sprite(EnemySprites.Medium);
            Enemy enemy = new Enemy(attack, sprite);

            enemy.UpdateDamage(4);
            enemy.UpdateHealth(30);
            enemy.UpdateDropRate(60);

            return enemy;
        }
    }
}
