using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Valiants_Tale.Resources.Access;

namespace Valiants_Tale.Resources.Data
{
    class Place : Unit
    {
        public Sturdiness sturdiness;
        public Prefix prefix;
        public bool IsMinor = false; //Describes the diff between a table and a city. if it is minor, a place that contains this place can see its contents

        public List<Unit> Container { get; private set; }

        public string insideDescription;

        /// <summary>
        /// Creates a Building or a container
        /// </summary>
        /// <param name="BaseHP">Health of the object</param>
        /// <param name="p">Prefix when describing contents</param>
        /// <param name="s">Sturdiness of the object</param>
        /// <param name="minor">A minor object is a chest or a table while not minor is a building or a city</param>
        public Place(int BaseHP, Prefix p, Sturdiness s, bool minor) : base(BaseHP)
        {
            prefix = p;
            IsMinor = minor;
            sturdiness = s;
            Container = new List<Unit>();
            SetImmunities();
            
        }
        private void SetImmunities()
        {
            if (sturdiness == Sturdiness.Unbreakable)
            {
                PreStruck += SpellEffect.Immune;
            }
            if (sturdiness == Sturdiness.Sturdy)
            {
                PreStruck += SpellEffect.ImmuneToSlashing;
                PreStruck += new SpellEffect(new float[] { 0.5f }).ModifyDamage; //Reduce all damage taken by 50%
            }
        }
        /// <summary>
        /// Puts the entering unit inside of the container
        /// </summary>
        /// <param name="entering">The object that's being put inside</param>
        public void Enter(Unit entering)
        {
            Container.Add(entering);
        }
        /// <summary>
        /// Removes the unit inside of the container from it
        /// </summary>
        /// <param name="leaving">Unit to remove from the holder</param>
        public void Leave(Unit leaving)
        {
            Container.Remove(leaving);
        }

        /// <summary>
        /// Describe the insides if it has them and list units in this thing.
        /// If units are huge or humongous it adds a prefix
        /// </summary>
        public void DescribeContents()
        {
            //TODO: Implement a memory interface
            if(insideDescription != null)
                ChatManager.Instance.WriteMind(prefix.ToString() + " the " + Name + " you can see that it's " + insideDescription);

            string UnitsInside = "";
            foreach(Unit UnitInside in Container)
            {
                //check for places inside the place
                if (UnitInside is Place)
                {
                    //if theres a minor place inside, lit its contents
                    if (((Place)UnitInside).IsMinor)
                    {
                        Place PlaceInside = (Place)UnitInside;
                        UnitsInside += " {[" + PlaceInside.Name + "] and";
                        foreach(Unit UnitsInsidePlaceInside in PlaceInside.Container)
                        {
                            UnitsInside += UnitsInsidePlaceInside.Size > SizeEnum.Medium ? $" [{UnitsInsidePlaceInside.Size} {UnitsInsidePlaceInside.Name}]" : $" [{UnitsInsidePlaceInside.Name}]";
                        }
                        UnitsInside += " " + PlaceInside.prefix.ToString().ToLower() + " it}";
                    }
                    else
                    {
                        UnitsInside += UnitInside.Size > SizeEnum.Medium ? $" [{UnitInside.Size} {UnitInside.Name}]" : $" [{UnitInside.Name}]";
                    }
                }
                else
                {
                    UnitsInside += UnitInside.Size > SizeEnum.Medium ? $" [{UnitInside.Size} {UnitInside.Name}]" : $" [{UnitInside.Name}]";
                }
                
            }
            //write out the string that was built previously
            ChatManager.Instance.WriteMind(prefix.ToString() +" the " + Name + " you see the following:" + UnitsInside);
        }
        public override void Describe(float strenght)
        {
            base.Describe();
            ChatManager.Instance.WriteMind("No matter how hard you try, you are unable to measure its weight;");
        }

        public enum Sturdiness
        {
            Flimsy,
            Average,
            Sturdy,
            Solid,
            Unbreakable
        }
        public enum Prefix
        {
            Inside,
            At
        }
    }
}
