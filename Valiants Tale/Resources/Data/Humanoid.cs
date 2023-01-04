using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valiants_Tale.Resources.Data
{
    class Humanoid : Creature
    {
        //The difference between this and creature is that this one can have items equiped
        public Dictionary<Item.EquipType, Item> Equipment;

        public Humanoid(int BaseHP) : base(BaseHP)
        {
            Equipment = new Dictionary<Item.EquipType, Item>();
        }

        //Equips the item and unequips the previous one
        public void Equip(Item item)
        {
            Unequip(item);
            Equipment.Add(item.equipType, item);
            Buff(item.ID, item.StatPage);
        }
        public void Unequip(Item item)
        {
            if (Equipment.ContainsKey(item.equipType))
            {
                Equipment.Remove(item.equipType);
                Cleanse(item.ID);
            }    
        }
    }
}
