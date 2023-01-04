using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Valiants_Tale.Resources.Access;

namespace Valiants_Tale.Resources.Data
{
    class SpellEffect
    {
        List<float> values;
        public SpellEffect(float[] val)
        {
            values = new List<float>(val);
        }
        public void ModifyDamage(DamageEventArgs e)
        {
            if(values.Count < 1)
            {
                MessageBox.Show("Someone tried casting a ModifyDamage spell without enough values");
            }
            e.amount = (int)(e.amount * values[0]);
        }
        public static void ImmuneToPhysical(DamageEventArgs e)
        {
            if(e.damageType == DamageEventArgs.DamageType.Physical)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to physical damage.");
            }
        }
        public static void ImmuneToMagical(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Magic)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to magic damage.");
            }
        }
        public static void ImmuneToAstral(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Astral)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to astral damage.");
            }
        }
        public static void ImmuneToFire(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Fire)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to fire damage.");
            }
        }
        public static void ImmuneToWater(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Water)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to water damage.");
            }
        }
        public static void ImmuneToElemental(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Elemental)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to elemental damage.");
            }
        }
        public static void ImmuneToCrushing(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Crushing)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to crushing damage.");
            }
        }
        public static void ImmuneToPuncturing(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Elemental)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to puncturing damage.");
            }
        }
        public static void ImmuneToSlashing(DamageEventArgs e)
        {
            if (e.damageType == DamageEventArgs.DamageType.Elemental)
            {
                e.amount = 0;
                ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to slashing damage.");
            }
        }
        public static void Immune(DamageEventArgs e)
        {
            e.amount = 0;
            ChatManager.Instance.WriteMind(e.attacked.Name + " is immune to damage.");
        }
    }
}
