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
        /// <summary>
        /// used to modify value of a stat by val or create one if nonexistant
        /// </summary>
        /// <param name="type">Type of the stat</param>
        /// <param name="val">Value of the stat</param>
        public void ModStat(Type type, float val)
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
        /// <summary>
        /// Used to set a stat to a certain value
        /// </summary>
        /// <param name="type">Type of the stat</param>
        /// <param name="val">Value to set it to</param>
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

        /// <summary>
        /// Used to get rid of a stat from the page
        /// </summary>
        /// <param name="type">Type of a stat to get rid of</param>
        public void RemoveStat(Type type)
        {
            if (Values.ContainsKey(type))
            {
                Values.Remove(type);
            }
        }
        /// <summary>
        /// Used to clone Statistics page. Usefull when you don't want to modify stats
        /// </summary>
        /// <returns>A new object with the same stats as the statistics page it's used on</returns>
        public Statistics Clone()
        {
            Statistics other = new Statistics();
            foreach(KeyValuePair<Type, float> a in Values)
            {
                other.ModStat(a.Key, a.Value);
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
