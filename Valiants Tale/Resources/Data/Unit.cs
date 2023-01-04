using System;
using System.Configuration;
using Valiants_Tale.Resources.Access;

namespace Valiants_Tale.Resources.Data
{
    class Unit
    {
        //General description
        public Guid ID { get; private set; }
        public string Name = "Unknown";
        public float Weight = 0f;
        public SizeEnum Size = SizeEnum.Medium;
        public string Description = "thing of unknown properties.";

        //Calculated outcome of all stats summed up. This is used in combat. These are not permanent. Creatures have this calcualted.
        //Objects stay with one permanent stat page
        //items use this to describe their bonus stats when equiped
        public Statistics StatPage;
        public float CurrentHP;

        public delegate void DamageEventHandler(DamageEventArgs e);
        public event DamageEventHandler PreStruck;
        public event DamageEventHandler PostStruck;

        public Unit(int BaseHP)
        {
            ID = Guid.NewGuid();
            StatPage = new Statistics();
            StatPage.ModStat(Statistics.Type.Health, BaseHP);
            CurrentHP = BaseHP;

            
        }

        /// <summary>
        /// First thing that fires when the target is damaged
        /// THIS METHOD CALCUALTED ALL THE IMMUNITIES AND SHOULD BE THE PRIMARY WAY TO MODIFY ANY UNITS HEALTH
        /// Damage is checked and the value is substracted based on the types and defences that player has in PreHit
        /// Healing is done via sub-0 amounts in the damagevent TEMP
        /// </summary>
        /// <param name="e">Damage to apply to the unit</param>
        public void ChangeHealthStatus(DamageEventArgs e)
        {
            e.setDefendant(this);
            PreStruck?.Invoke(e); // modify the damage based on buffs/debuffs

            //ADD PARRY AND BLOCK
            //calcualte armor
            //Move parry & block
            
            //to a spell effect
            if (e.damageType != DamageEventArgs.DamageType.True)
            {
                if (e.isParryable)
                {
                    //TODO: Add parry
                    //if true set hasbeenparried to true;
                    //set damage to 0
                }
                else if (e.isBlockable)
                {
                    //TODO: Add parry
                    //if true set hasbeenparried to true;
                }
                if (!e.hasBeenDodged && !e.hasBeenParried && e.amount > 0)
                {
                    //Substract armor from damage or set to 1 if armor is higher
                    //dodged or parried attackes deal no damage
                    e.amount = e.amount > StatPage.GetStat(Statistics.Type.Armor) ? e.amount -= ((int)Math.Floor(StatPage.GetStat(Statistics.Type.Armor))) : 1;
                }
                ChatManager.Instance.WriteAction($"{Name} took {e.amount} of {e.damageType.ToString().ToLower()} damage.");
                ApplyHealthChange(e);
                PostStruck?.Invoke(e);
                
            }
        }
        void ApplyHealthChange(DamageEventArgs e)
        {
            CurrentHP -= e.amount;           
        }

        //describe with only size
        public virtual void Describe()
        {
            if(Size != SizeEnum.Medium)
                ChatManager.Instance.WriteMind($"{Name} is a {Size.ToString().ToLower()} {Description}");
            else
                ChatManager.Instance.WriteMind($"{Name} is a {Description}");
        }
        //Describe with weight
        public virtual void Describe(float strenght)
        {
            float a = strenght / Weight;
            string b = "";
            if (a > 50) b = "very light";
            else if (a > 10) b = "light";
            else if (a > 5) b = "moderately light";
            else if (a > 0) b = "heavy";
            else if (a < 0) b = "really heavy";
            if (Size != SizeEnum.Medium)
                ChatManager.Instance.WriteMind($"{Name} is a {Size.ToString().ToLower()} and {b} {Description}");
            else
                ChatManager.Instance.WriteMind($"{Name} is a {b} {Description}");
        }
        public enum SizeEnum
        {
            Tiny,
            Small,
            Medium,
            Big,
            Huge,
            Humongous
        }
    }
    class DamageEventArgs
    {
        public int baseAmount { get; private set; }
        public int amount;
        public object attacker { get; private set; }
        public Unit attacked { get; private set; }
        public DamageType damageType { get; private set; }
        public bool isParryable { get; private set; }
        public bool isBlockable { get; private set; }
        public bool isDodgeable { get; private set; }

        public bool hasBeenParried = false; //only melee / thrown are parryable
        public bool hasBeenBlocked = false; //all except for true damage should be blockable
        public bool hasBeenDodged = false; //all except for true should be dodgeable


        public DamageEventArgs(int val, object att, DamageType dt, bool p, bool b, bool d)
        {
            amount = val;
            baseAmount = val;
            attacker = att;
            damageType = dt;
            isParryable = p;
            isBlockable = b;
            isDodgeable = d;
        }
        public void setDefendant(Unit o)
        {
            attacked = o;
        }
        public enum DamageType
        {
            Physical,
            Magic,
            Astral,
            Fire,
            Water,
            Elemental,
            True,
            Crushing,
            Slashing,
            Puncturing
        }
    }
}
