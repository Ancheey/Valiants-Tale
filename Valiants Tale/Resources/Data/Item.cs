using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valiants_Tale.Resources.Data
{
    class Item : Unit
    {
        public Item(string name, float weight, SizeEnum size, int hp, MaterialEnum mat) : base(hp)
        {
            Name = name;
            Weight = weight;
            Size = size;
            Material = mat;
        }

        public MaterialEnum Material;
        public EquipType equipType;
        public ItemType itemType;
        

        public enum MaterialEnum
        {
            Wood,
            Iron,
            Stone
        }
        public enum EquipType
        {
            Unequipable,
            Head,
            Neck,
            Shoulders,
            Back,
            Chest,
            Wrists,
            Hands,
            Waist,
            Legs,
            Boots,
            MainHand,
            OffHand,
        }
        public enum ItemType
        {
            Cloth,
            Leather,
            Chain,
            Metal,
            Elemental,
            Magic,
            Sword,
            Axe,
            Mace,
            Hammer,
            Dagger,
            Spear,
            Glaive,
            Staff,
            Lantern,
            Shield,
            Book,
            Buckler,
            Junk,
            Food,
            Container
        }
    }
}
