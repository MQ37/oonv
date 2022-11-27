using System;
namespace OONV
{
    public static class EnemyBuilder
    {
        public static Enemy CreateSmall()
        {
            Attack attack = new AttackBlunt(2);
            Sprite sprite = new Sprite(EnemySprites.Small);
            Enemy enemy = new Enemy(20, attack, sprite);
            return enemy;
        }
    }
}
