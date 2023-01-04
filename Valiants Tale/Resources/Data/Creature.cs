using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valiants_Tale.Resources.Data
{
    class Creature : Unit
    {
        /// <summary>
        /// Describes the guid that contains the base character stats. Those are used to calculate the StatPage
        /// </summary>
        Guid BaseStatPageBuffID;

        /// <summary>
        /// Guid either describes the item guid or spell guid. Item will know its guid when it needs to manage this memory
        /// </summary>
        Dictionary<Guid, Statistics> StatBuffs;


        /// <summary>
        /// Creates a new creature and its base stat page that can be accesed with StatBuffs[BaseStatPageBuffID]
        /// </summary>
        /// <param name="BaseHP">Base amount of health that will be given to the unit as a starter stat page</param>
        public Creature(int BaseHP) : base(BaseHP)
        {
            BaseStatPageBuffID = Guid.NewGuid();
            StatBuffs = new Dictionary<Guid, Statistics>();

            Statistics stats = new Statistics();
            stats.ModStat(Statistics.Type.Health, BaseHP);
            StatBuffs.Add(BaseStatPageBuffID, stats);
            CalculateStats();
        }

        /// <summary>
        /// Adds a new buff or overwrites an existing one with the same GUID
        /// </summary>
        /// <param name="source">GUID of the source of the buff. Used to recognise if the buff belongs to a spell or an item</param>
        /// <param name="stats">Statistics page that will be attributed to the provided guid</param>
        public void Buff(Guid source, Statistics stats)
        {
            if (StatBuffs.ContainsKey(source))
            {
                StatBuffs[source] = stats;
            }
            else
            {
                StatBuffs.Add(source, stats);
            }
            CalculateStats();
        }
        /// <summary>
        /// Removes a buff if one with supplied guid exists in the buff page
        /// </summary>
        /// <param name="target">Guid of the source of the buff</param>
        public void Cleanse(Guid target)
        {
            if (StatBuffs.ContainsKey(target))
            {
                StatBuffs.Remove(target);
                CalculateStats();
            }
        }
        /// <summary>
        /// Recalcualtes stats from all the stat pages in the buffs and the base stat page guid
        /// </summary>
        public void CalculateStats()
        {
            StatPage = new Statistics();
            foreach(KeyValuePair<Guid, Statistics> a in StatBuffs)
            {
                foreach(Statistics.Type t in Enum.GetValues(typeof(Statistics.Type)))
                {
                    StatPage.ModStat(t, a.Value.GetStat(t));
                }
            }
        }
    }
}
