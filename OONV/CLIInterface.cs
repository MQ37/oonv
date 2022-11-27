using System;
namespace OONV
{
    public class CLIInterface
    {
        private int healthbarSize;
        private int logSize;

        public CLIInterface()
        {
            this.healthbarSize = 20;
            this.logSize = 20;
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
            }
            else if (input == "2")
            {
                return Action.Nothing;
            }

            return Action.Nothing;

        }

        public void ShowMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        private void HorizontalBorder()
        {
            for(int i = 0; i < 80; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine("");
        }

        private void VerticalBorder()
        {
            Console.Write("*");
        }

        private void Separator(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(" ");
            }
        }

        private void Newline()
        {
            Console.WriteLine();
        }

        private void Healthbar(Entity entity)
        {
            this.Healthbar(entity, this.healthbarSize);
        }

        private void Healthbar(Entity entity, int length)
        {
            int portion = (int) (((double) entity.Health / entity.MaxHealth) * length-1) + 1;

            Console.Write("HP: ");

            for (int i = 0; i < length; i++)
            {
                if (i < portion)
                {
                    Console.Write("█");
                }
                else
                {
                    Console.Write("░");
                }
            }
        }

        public void Render(Entity hero, Entity enemy)
        {
            this.HorizontalBorder();
            int separatorSprite = 80 - hero.Sprite.GetWidth() - enemy.Sprite.GetWidth() - this.logSize - 2;
            int pritedLines = 0;

            for (int i = 0; i < hero.Sprite.GetHeight(); i++)
            {
                this.VerticalBorder();
                hero.Sprite.PrintRow(i);
                
                this.Separator(separatorSprite);

                enemy.Sprite.PrintRow(i);

                this.Separator(this.logSize);
                this.VerticalBorder();
                this.Newline();
            }
            pritedLines += hero.Sprite.GetHeight();

            int separatorHealthbar = 80 - (this.healthbarSize+4)*2 - this.logSize - 2;
            this.VerticalBorder();
            this.Healthbar(hero);
            this.Separator(separatorHealthbar);
            this.Healthbar(enemy);
            this.Separator(this.logSize);
            this.VerticalBorder();
            this.Newline();
            pritedLines += 1;

            for (int i = 0; i < 23 - pritedLines; i++)
            {
                this.VerticalBorder();
                this.Separator(78);
                this.VerticalBorder();
                this.Newline();
            }

            this.HorizontalBorder();
        }
    }
}
