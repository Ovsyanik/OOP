using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    class FlyHeroDecorator : Hero
    {
        private readonly Hero hero;

        public FlyHeroDecorator(Hero hero) 
        {
            this.hero = hero;
        }

        public override string Name { get => this.hero.Name; set => this.hero.Name = value; }

        public override Armor armor { get => this.hero.armor; set => this.hero.armor = value; }

        public override Weapon weapon { get => this.hero.weapon; set => this.hero.weapon = value; }

        public override string ToString()
        {
            string info = $"-- Этот герой летает -- \n";
            return info + this.hero.ToString();
        }
    }
}
