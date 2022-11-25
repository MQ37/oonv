using System;
namespace OONV
{
    public class EnemyBuilder
    {
        public static Enemy CreateSmall()
        {
            Attack attack = new AttackBlunt(2);
            Enemy enemy = new Enemy(20, attack);
            return enemy;
        }
    }
}
