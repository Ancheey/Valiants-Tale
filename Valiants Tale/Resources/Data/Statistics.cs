using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valiants_Tale.Resources.Data
{
    class Statistics
    {
        private Dictionary<Type, float> Values;

        public Statistics(float hp, float armor, float vit, float agi, float str, float inte, float wis, float cha)
        {
            Values = new Dictionary<Type, float>();
            Values.Add(Type.Health, hp);
            Values.Add(Type.Armor, armor);
            Values.Add(Type.Vitality, vit);
            Values.Add(Type.Agility, agi);
            Values.Add(Type.Strenght, str);
            Values.Add(Type.Intelligence, inte);
            Values.Add(Type.Wisdom, wis);
            Values.Add(Type.Charisma, cha);
        }
        public Statistics()
        {
            Values = new Dictionary<Type, float>();
        }
        //used to add value to a stat or create one if nonexistant
        public void AddStat(Type type, float val)
        {
            if (Values.ContainsKey(type))
            {
                Values[type] += val;
            }
            else
            {
                Values.Add(type, val);
            }
        }
        public float GetStat(Type type)
        {
            if (Values.ContainsKey(type))
                return Values[type];
            else
                return 0f;
        }
        //used to lower the stat or add if nonexistant
        public void SubstractStat(Type type, float val)
        {
            if (Values.ContainsKey(type))
            {
                Values[type] -= val;
            }
            else
            {
                Values.Add(type, -val);
            }
        }
        //Used to set a stat to a certain value
        public void SetStat(Type type, float val)
        {
            if (Values.ContainsKey(type))
            {
                Values[type] = val;
            }
            else
            {
                Values.Add(type, val);
            }
        }
        //Used to get rid of a stat from the page
        public void RemoveStat(Type type)
        {
            if (Values.ContainsKey(type))
            {
                Values.Remove(type);
            }
        }
        //Used to clone Statistics page. Usefull when you don't want to modify stats
        public Statistics Clone()
        {
            Statistics other = new Statistics();
            foreach(KeyValuePair<Type, float> a in Values)
            {
                other.AddStat(a.Key, a.Value);
            }
            return other;
        }

        public enum Type
        {
            Health,
            Armor,
            Vitality,
            Agility,
            Strenght,
            Intelligence,
            Wisdom,
            Charisma
        }
    }
}
