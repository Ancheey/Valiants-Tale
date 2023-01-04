using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valiants_Tale.Resources.Data
{
    class Creature : Unit
    {
        //Describes the guid that contains the base character stats. Those are used to calculate the StatPage
        Guid BaseStatPageBuffID;

        //Guid either describes the item guid or spell guid. Item will know its guid when it needs to manage this memory
        Dictionary<Guid, Statistics> StatBuffs;


        //Creates a new creature and its base stat page that can be accesed with StatBuffs[BaseStatPageBuffID]
        public Creature(int BaseHP) : base(BaseHP)
        {
            BaseStatPageBuffID = Guid.NewGuid();
            StatBuffs = new Dictionary<Guid, Statistics>();

            Statistics stats = new Statistics();
            stats.AddStat(Statistics.Type.Health, BaseHP);
            StatBuffs.Add(BaseStatPageBuffID, stats);
            CalculateStats();
        }

        //Adds a new buff or overwrites an existing one with the same GUID
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
        //Removes a buff if one with supplied guid exists in the buff page
        public void Cleanse(Guid target)
        {
            if (StatBuffs.ContainsKey(target))
            {
                StatBuffs.Remove(target);
                CalculateStats();
            }
        }
        //calcualtes stats from the base and 
        public void CalculateStats()
        {
            StatPage = new Statistics();
            foreach(KeyValuePair<Guid, Statistics> a in StatBuffs)
            {
                foreach(Statistics.Type t in Enum.GetValues(typeof(Statistics.Type)))
                {
                    StatPage.AddStat(t, a.Value.GetStat(t));
                }
            }
        }
    }
}
