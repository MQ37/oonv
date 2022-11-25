using System;

namespace OONV
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hero hero = HeroBuilder.CreateWarrior();

            Game game = new Game(hero);

            game.Loop();
        }
    }
}
