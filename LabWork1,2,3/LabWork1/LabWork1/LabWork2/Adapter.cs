using System;
using System.Threading;

namespace LabWork1
{
    [Serializable]
    public class Adapter : Prototype<Adapter>, IComponent
    {
        private readonly Hero hero;

        public Adapter(Hero hero)
        {
            this.hero = hero;
        }

        public string Title { get => this.hero.Name; set => this.hero.Name = value; }

        public void Draw()
        {
            Thread.Sleep(50);
            var random = new Random();
            int x = random.Next(0, 100);
            int y = random.Next(0, 100);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(this.hero);
            Console.WriteLine($"Position -X:{x}-Y:{y}-");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------");
            Console.ResetColor();
        }



        public IComponent Find(string title)
        {
            return this;
        }

        public override string ToString()
        {
            return "Имя : " + this.hero.Name.ToString() + "." + this.hero.ToString();
        }
    }
}
