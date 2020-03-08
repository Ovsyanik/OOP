using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork1
{
    [Serializable]
    public class Hero
    {
        public virtual string Name { get; set; }
        public virtual Weapon weapon { get; set; }
        public virtual Armor armor { get; set; }

        public Hero() { }
        public Hero(IHeroFactory factory)
        {
            Name = factory.CreateName();
            weapon = factory.CreateWeapon();
            armor = factory.CreateArmor();
        }

        public override string ToString()
        {
            return $"{weapon.ToString()} {armor.ToString()}";
        }
    }
}
