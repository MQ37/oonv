using System;
namespace OONV
{
    public static class HeroBuilder
    {

        public static Hero CreateWarrior()
        {
            Attack attack = new AttackBlunt(5);
            Sprite sprite = new Sprite(HeroSprites.Warrior);
            Hero hero = new Hero(100, attack, sprite);

            hero.UpdateHealth(20);
            hero.UpdateArmor(20);

            return hero;
        }
    }
}
