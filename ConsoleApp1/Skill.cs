using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Skill
    {
        public string name = "";
        public Icon icon = new Icon();
        public bool party = false;
        public enum TargetType { Single, Whole, Self };
        public int trgType = 0;
        public int dmg = 0;
        public int addDmg = 0;
        public bool wepSpl = false;
        //public int scoreMod;
        public int numTimes = 1;
        public string flavor;
        public FX hitFX;
        public bool alwaysHit = false;
        public bool inf = false;
        public int uses = 0;
        int usesLeft = 0;
        int seed = 0;
        public int UsesDisp()
        {
            return usesLeft;
        }
        public void Use()
        {
            usesLeft -= 1;
        }
        public void SeedReset()
        {
            seed += 1;
        }
        public void UsesReset()
        {
            usesLeft = uses;
        }
    }
    //FIGHTER SPECIALS
    class Crossbow : Skill
    {
        public Crossbow()
        {
            icon = new I_Ranged(7, Color.BEIGE);
            name = "Heavy Crossbow";
            hitFX = new Pierce();
            dmg = Dice.d8(1);
            addDmg = 5;
            alwaysHit = true;
            flavor = "Fire a crossbow at one enemy.";
            uses = 10;
        }
    }
    //WIZARD SPECIALS
    class MagMissile : Skill
    {
        public MagMissile()
        {
            icon = new IconSpell(3, new Color(155, 255, 205, 255));
            name = "Magic Missile";
            hitFX = new MagMis();
            dmg = Dice.d4(1);
            addDmg = 1;
            numTimes = 3;
            alwaysHit = true;
            flavor = "Casts three bolts of magic at targets of your choice.";
            inf = true;
        }
    }
    class AcidArrow : Skill
    {
        public AcidArrow()
        {
            icon = new IconSpell(3, Color.ORANGE);
            name = "Acid Arrow";
            hitFX = new AcArr();
            dmg = Dice.d6(2);
            addDmg = 0;
            alwaysHit = true;
            flavor = "Create a sphere of fire directed at one enemy.";
            uses = 10;
        }
    }
    //CLERIC SPECIALS
    class Healing : Skill
    {
        public Healing()
        {
            icon = new IconSpell(1, Color.RAYWHITE);
            name = "Healing Word";
            hitFX = new Holy();
            party = true;
            alwaysHit = true;
            dmg = (Dice.d4(1));
            inf = true;
        }
    }
    //ROGUE SPECIALS
    class Sneak : Skill
    {
        public Sneak()
        {
            icon = new IconSpell(2, Color.PURPLE);
            name = "Sneak Attack";
            hitFX = new Pierce();
            wepSpl = true;
            dmg = Dice.d6(1);
            inf = true;
        }
    }
    //BARBARIAN SPECIALS

}
