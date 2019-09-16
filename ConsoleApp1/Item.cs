using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Item
    {
        public enum ItemType { Consume, Weapon };
        public string name = "";
        public string flavor = "";
        public int cost = 0;
        public ItemType type = ItemType.Consume;
        public Icon icon;
        public bool party = true;
        public int effect;
        void Use()
        {

        }

    }
    class Potion1 : Item
    {
        public Potion1()
        {
            name = "Small Potion of Healing";
            icon = new I_Potion(0,Color.PINK);
            cost = 25;

        }
    }
    class Weapon
    {
        public enum DamageType { Acid, Blunt, Cold, Fire, Force, Lightning, Necrotic, Piercing, Poison, Psychic, Radiant, Slashing, Thunder };
        public string name = "";
        public string flavor = "";
        public int cost = 0;
        public Icon icon = new Icon();
        public Rectangle spr = new Rectangle();
        public FX hitFX;
        public int die;
        public int dmgType;
        public bool ranged = false;
        public bool twoHand = false;
    }
    class Dagger : Weapon
    {
        public Dagger()
        {
            name = "Dagger";
            flavor = "A lightweight knife.\n1d4 piercing damage.";
            cost = 2;
            icon = new I_Dagger(Color.RAYWHITE);
            spr = Sprites.knife2;
            die = Dice.d4(1);
            hitFX = new Pierce();
            dmgType = (int)DamageType.Piercing;
        }
    }
    class Shortsword : Weapon
    {
        public Shortsword()
        {
            name = "Shortsword";
            flavor = "A soldier's blade. Easily concealed.\n1d6 piercing damage.";
            cost = 10;
            icon = new I_Sword(0,Color.RAYWHITE);
            spr = Sprites.sword2;
            die = Dice.d6(1);
            hitFX = new Pierce();
            dmgType = (int)DamageType.Piercing;
        }
    }
    class Longsword : Weapon
    {
        public Longsword()
        {
            name = "Longsword";
            flavor = "A well-rounded blade for any fighter.\n1d8 slashing damage.";
            cost = 15;
            icon = new I_Sword(0,Color.RAYWHITE);
            spr = Sprites.sword2;
            die = Dice.d8(1);
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
        }
    }
    class Greatsword : Weapon
    {
        public Greatsword()
        {
            name = "Longsword";
            flavor = "A massive & mighty blade.\n2d6 slashing damage.";
            cost = 50;
            icon = new I_Sword(0,Color.RAYWHITE);
            spr = Sprites.sword2;
            die = Dice.d6(2);
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
            twoHand = true;
        }
    }
    class Mace : Weapon
    {
        public Mace()
        {
            name = "Mace";
            flavor = "A simple tool of destruction.\n1d6 blunt damage.";
            cost = 5;
            icon = new I_Rod(0,Color.RAYWHITE);
            spr = Sprites.mace1;
            die = Dice.d6(1);
            hitFX = new Blunt();
            dmgType = (int)DamageType.Blunt;
        }
    }
    class Handaxe : Weapon
    {
        public Handaxe()
        {
            name = "Handaxe";
            flavor = "";
            cost = 5;
            icon = new I_Axe(0, Color.RAYWHITE);
            spr = Sprites.axe1;
            die = Dice.d6(1);
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
        }
    }
    class Battleaxe : Weapon
    {
        public Battleaxe()
        {
            name = "Battleaxe";
            flavor = "";
            cost = 10;
            icon = new I_Axe(0, Color.RAYWHITE);
            spr = Sprites.axe2;
            die = Dice.d6(1);
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
        }
    }
    class Greataxe : Weapon
    {
        public Greataxe()
        {
            name = "Greataxe";
            flavor = "";
            cost = 30;
            icon = new I_Axe(0, Color.RAYWHITE);
            spr = Sprites.axe3;
            die = Dice.d12(1);
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
            twoHand = true;
        }
    }
}
