using System;
namespace OONV
{
    public class HeroBuilder
    {

        public static Hero CreateWarrior()
        {
            Attack attack = new AttackBlunt(5);
            Hero hero = new Hero(100, attack);

            hero.UpdateHealth(20);
            hero.UpdateArmor(20);

            return hero;
        }
    }
}
