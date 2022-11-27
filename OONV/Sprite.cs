using System;
namespace OONV
{
    public class Sprite
    {
        // 80x24 - terminal
        // 20x15 - sprite
        public string[] Body { get; private set; }

        public Sprite(string[] body)
        {
            // Height
            if (body.Length != 15)
            {
                throw new ArgumentException("Wrong sprite size! Must be 20x15");
            }

            // Width
            foreach (string row in body)
            {
                if (row.Length != 20)
                {
                    throw new ArgumentException("Wrong sprite size! Must be 20x15");
                }
            }

            this.Body = body;
        }

        public int GetHeight()
        {
            return this.Body.Length;
        }

        public int GetWidth()
        {
            return this.Body[0].Length;
        }

        public void PrintRow(int row)
        {
            if (row > this.Body.Length)
            {
                throw new IndexOutOfRangeException("Row out of range!");
            }

            Console.Write(this.Body[row]);
        }
    }
}
