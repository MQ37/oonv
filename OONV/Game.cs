using System;
namespace OONV
{
    public class Game
    {

        public int Level { get; private set; }
        public Hero Hero { get; private set; }
        public Enemy Enemy { get; private set; }

        public Game(Hero hero)
        {
            this.Level = 0;
            this.Hero = hero;
            this.CreateEnemy();
        }

        private void CreateEnemy()
        {
            Enemy enemy = EnemyBuilder.CreateSmall();
            this.Enemy = enemy;
        }

        public void PrintStatus()
        {
            Console.WriteLine(String.Format("---------- Level {0} ----------", this.Level));
            Console.WriteLine(String.Format("Hero health: {0}", this.Hero.Health));
            Console.WriteLine(String.Format("Enemy health: {0}", this.Enemy.Health));

        }

        public Action ActionMenu()
        {
            Console.WriteLine("1) Attack");
            Console.WriteLine("2) Nothing");
            Console.Write("Choose action: ");

            string input = Console.ReadLine();

            if (input == "1")
            {
                return Action.Attack;
            } else if (input == "2")
            {
                return Action.Nothing;
            }

            return Action.Nothing;

        }

        private void NextLevel()
        {
            this.Level += 1;
            this.CreateEnemy();
        }

        public bool Round()
        {
            this.PrintStatus();
            Action action = this.ActionMenu();
            if (action == Action.Attack) {
                Console.WriteLine("Hero attacking");
                this.Hero.DoAttack(this.Enemy);
            } else if (action == Action.Nothing)
            {
                Console.WriteLine("You are vibing while the enemy is attacking you. What a power move!");
            }

            if (this.Enemy.IsAlive())
            {
                Console.WriteLine("Enemy attacking");
                this.Enemy.DoAttack(this.Hero);
            }
            else
            {
                Console.WriteLine("Enemy died!");
                Console.WriteLine("Progressing to next level");
                this.NextLevel();
            }

            if (!this.Hero.IsAlive())
            {
                Console.WriteLine("----------  YOU DIED ---------- ");
                return false;
            }

            return true;
        }

        public void Loop()
        {
            while(true)
            {
                if (!this.Round())
                {
                    break;
                }
            }
        }
    }
}
