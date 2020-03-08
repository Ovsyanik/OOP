using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    // абстрактный класс строителя
    abstract class AbstractHeroBuilder
    {
        public Hero Hero { get; private set; }

        public void CreateHero()
        {
            Hero = new Hero();
        }
        public abstract void SetName();
        public abstract void SetWeapon();
        public abstract void SetArmor();
    }
   
    class Director
    {
        public Hero Make(AbstractHeroBuilder heroBuilder)
        {
            heroBuilder.CreateHero();
            heroBuilder.SetName();
            heroBuilder.SetWeapon();
            heroBuilder.SetArmor();
            return heroBuilder.Hero;
        }
    }
        
    class HeroBuilder : AbstractHeroBuilder
    {

        public override void SetName()
        {
            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();
            this.Hero.Name = name;
        }

        public override void SetWeapon()
        {
            Console.WriteLine("Введите оружие:");
            string weapon = Console.ReadLine();
            this.Hero.weapon = new Weapon(weapon);
        }

        public override void SetArmor()
        {
            Console.WriteLine("Введите количество брони:");
            string armor = Console.ReadLine();
            this.Hero.armor = new Armor(armor);
        }
    }
}
