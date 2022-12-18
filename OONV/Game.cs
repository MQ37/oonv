using System;
namespace OONV
{
    public class Game
    {

        public int Level { get; private set; }
        public Hero Hero { get; private set; }
        public Enemy Enemy { get; private set; }
        private CLIInterface gInterface;

        public Game(Hero hero, CLIInterface gInterface)
        {
            this.Level = 0;
            this.Hero = hero;
            this.CreateEnemy();

            this.gInterface = gInterface;
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

        private Action ActionMenu()
        {
            return this.gInterface.ActionMenu();

        }

        private void ShowMessage(string msg)
        {
            this.gInterface.ShowMessage(msg);
        }

        private void NextLevel()
        {
            this.ShowMessage("Progressing into next level");
            this.Level += 1;
            this.CreateEnemy();
        }

        public void Render()
        {
            this.gInterface.Render(this.Hero, this.Enemy);
        }

        private bool CanProgress()
        {
            if (!this.Enemy.IsAlive())
            {
                return true;
            }

            return false;
        }

        public bool Round()
        {
            this.Render();
            this.PrintStatus();

            // Hero action
            Action action = this.ActionMenu();
            if (action == Action.Attack) {
                ShowMessage("Hero attacking");
                this.Hero.DoAttack(this.Enemy);
            } else if (action == Action.Nothing)
            {
                ShowMessage("You are vibing while the enemy is attacking you. What a power move!");
            }

            // Enemy attack
            this.Enemy.DoAttack(this.Hero);

            // Drop
            if (!this.Enemy.IsAlive())
            {
                ShowMessage("Enemy died");
                Item item = this.Enemy.DropItem();
                if (item != null)
                {
                    ShowMessage(String.Format("Enemy dropped: {0}", item.Name));
                    if (item is IHeroApplicable)
                    {
                        IHeroApplicable applicable = (IHeroApplicable)item;
                        applicable.Apply(this.Hero);
                    }
                }
            }

            // Alive check
            if (!this.Hero.IsAlive())
            {
                ShowMessage("----------  YOU DIED ---------- ");
                return false;
            }

            // Next level
            if (CanProgress())
            {
                this.NextLevel();
            }

            return true;
        }

        public void Entry()
        {
            while (true)
            {
                MenuOption option = this.gInterface.GameMenu();
                if (option == MenuOption.Play)
                {
                    this.Loop();
                } else if (option == MenuOption.Exit)
                {
                    break;
                }
            }
        }

        public void Loop()
        {
            while (true)
            {
                if (!this.Round())
                {
                    break;
                }
            }
        }
    }
}
