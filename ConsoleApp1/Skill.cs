using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Skill
    {
        public string name;
        public Icon icon;
        public bool party = false;
        public bool whole = false;
        public int dmg = 0;
        public int scoreModDmg;
        public int numTimes = 1;
        public string flavor;

    }
    class MagMissile : Skill
    {
        public MagMissile()
        {
            icon = new IconSpell(3, new Color(155, 255, 205, 255));
            name = "Magic Missile";
            dmg = (Dice.d4(1)) + 1;
            numTimes = 3;
            flavor = "Casts three bolts of magic at targets of your choice.";
        }
    }
    class Healing : Skill
    {
        public Healing()
        {
            party = true;
            dmg = (Dice.d8(2)) * -1;
        }
    }
    class Crossbow : Skill
    {
        public Crossbow()
        {
            dmg = Dice.d8(1);
        }
    }
}
