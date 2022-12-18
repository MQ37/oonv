using System;

namespace OONV
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hero hero = HeroBuilder.CreateWarrior();
            CLIInterface gInterface = new CLIInterface();
            Game game = new Game(hero, gInterface);

            game.Entry();
        }
    }
}
