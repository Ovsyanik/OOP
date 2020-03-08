using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace LabWork1
{

    public interface IHeroFactory
    {
        Weapon CreateWeapon();
        Armor CreateArmor();
        string CreateName();
    }

    [Serializable]
    public class Armor
    {
        public virtual string armor { get; set; }

        public Armor(string armor)
        {
            this.armor = armor;
        }

        public override string ToString()
        {
            return $"Броня: {armor.ToString()}.";
        }
    }

    [Serializable]
    public class Weapon
    {
        public virtual string weapon { get; set; }

        public Weapon(string weapon)
        {
            this.weapon = weapon;
        }

        public override string ToString()
        {
            return $"Оружие: {weapon.ToString()}.";
        }
    }

    [Serializable]
    class Assasin : IHeroFactory
    {
        public string CreateName()
        {
            Console.Clear();
            Console.WriteLine("Введите имя: \t");
            string name = Console.ReadLine();
            return name;
        }

        public Weapon CreateWeapon()
        {
            return new Weapon("Клинки");
        }

        public Armor CreateArmor()
        {
            return new Armor("Кожанная");
        }

    }

    [Serializable]
    class Warrior : IHeroFactory
    {
        public string CreateName()
        {
            Console.Clear();
            Console.WriteLine("Введите имя: \t");
            string name = Console.ReadLine();
            return name;
        }

        public Weapon CreateWeapon()
        {
            return new Weapon("Меч");
        }

        public Armor CreateArmor()
        {
            return new Armor("Стальная");
        }
    }

    class Hunter : IHeroFactory
    {
        public string CreateName()
        {
            Console.Clear();
            Console.WriteLine("Введите имя: \t");
            string name = Console.ReadLine();
            return name;
        }

        public Weapon CreateWeapon()
        {
            return new Weapon("Лук");
        }

        public Armor CreateArmor()
        {
            return new Armor("Кожанная");
        }
    }
}
