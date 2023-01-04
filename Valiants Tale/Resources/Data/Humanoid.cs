using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valiants_Tale.Resources.Data
{
    class Humanoid : Creature
    {
        /// <summary>
        /// Extends the functionality of the creature by adding a handler for equipment
        /// </summary>
        public Dictionary<Item.EquipType, Item> Equipment;

        public Humanoid(int BaseHP) : base(BaseHP)
        {
            Equipment = new Dictionary<Item.EquipType, Item>();
        }

        /// <summary>
        /// Equips the item and unequips the previous one in the same type, if one was equiped
        /// </summary>
        /// <param name="item">Item to be equiped</param>
        public void Equip(Item item)
        {
            Unequip(item.equipType);
            Equipment.Add(item.equipType, item);
            Buff(item.ID, item.StatPage);
        }
        /// <summary>
        /// Unequips an item from the provided slot
        /// </summary>
        /// <param name="slot">Equipment type slot to remove an item from</param>
        public void Unequip(Item.EquipType slot)
        {
            if (Equipment.ContainsKey(slot))
            {
                Cleanse(Equipment[slot].ID);
                Equipment.Remove(slot);
            }    
        }
    }
}
