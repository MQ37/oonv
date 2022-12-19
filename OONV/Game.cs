using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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
            this.Hero = hero;
            this.gInterface = gInterface;
            this.Reset();
        }

        private void CreateEnemy()
        {
            IEnemyBuilder builder = new SkeletonEnemyBuilder();
            Enemy enemy;
            if (this.Level < 5)
            {
                enemy = builder.CreateSmall();
            }
            else if (this.Level < 10)
            {
                enemy = builder.CreateMedium();
            }
            else
            {
                enemy = builder.CreateLarge();
            }

            this.Enemy = enemy;
        }

        public void PrintStatus()
        {
            Console.WriteLine(String.Format("---------- Level {0} ----------", this.Level));
            Console.WriteLine(String.Format("Hero health: {0}", this.Hero.Health));
            Console.WriteLine(String.Format("Enemy health: {0}", this.Enemy.Health));

        }

        private MenuOption ActionMenu()
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

            bool enemyAttack = true;

            // Hero action
            MenuOption option = this.ActionMenu();
            if (option == MenuOption.Attack) {
                ShowMessage("Hero attacking");
                this.Hero.DoAttack(this.Enemy);
            } else if (option == MenuOption.Nothing)
            {
                ShowMessage("You are vibing while the enemy is attacking you. What a power move!");
            } else if (option == MenuOption.Save)
            {
                ShowMessage("Saving...");
                GameSave save = new GameSave(this.Hero.Health, this.Enemy.Health, this.Level);
                Stream s = File.Open("save.dat", FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, save);
                s.Close();

                enemyAttack = false;
            }

            // Enemy attack
            if (enemyAttack)
            {
                this.Enemy.DoAttack(this.Hero);
            }

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
                    this.Reset();
                    this.Loop();
                } else if (option == MenuOption.Exit)
                {
                    break;
                } else if (option == MenuOption.Load)
                {
                    ShowMessage("Loading...");
                    GameSave save;
                    Stream s = File.Open("save.dat", FileMode.Open);
                    BinaryFormatter b = new BinaryFormatter();
                    save = (GameSave)b.Deserialize(s);
                    s.Close();

                    this.Load(save);
                    this.Loop();
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

        public void Reset()
        {
            this.Level = 0;
            this.Hero.Reset();
            this.CreateEnemy();
        }

        public void Load(GameSave save)
        {
            this.Level = save.Level;
            this.CreateEnemy();
            this.Hero.Load(save);
            this.Enemy.Load(save);
        }
    }
}
