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
        public int[] die = new int[2] { 0, 0 };
        public int add = 0;
        public FX fx = new Holy();
        public int amount = 1;
        void Use()
        {
            amount--;
        }

    }
    class Potion1 : Item
    {
        public Potion1()
        {
            name = "Potion of Healing";
            icon = new I_Potion(0,Color.PINK);
            flavor = "Heals 2d4 + 2 health.";
            cost = 50;
            die = new int[2] { 2, 4 };
            add = 2;
        }
    }
    class Potion2 : Item
    {
        public Potion2()
        {
            name = "Potion of Greater Healing";
            icon = new I_Potion(1, Color.PINK);
            flavor = "Heals 4d4 + 4 health.";
            cost = 250;
            die = new int[2] { 4, 4 };
            add = 4;
        }
    }
    class Potion3 : Item
    {
        public Potion3()
        {
            name = "Potion of Superior Healing";
            icon = new I_Potion(6, Color.PINK);
            flavor = "Heals 8d4 + 8 health.";
            cost = 2500;
            die = new int[2] { 8, 4 };
            add = 8;
        }
    }
    class Potion4 : Item
    {
        public Potion4()
        {
            name = "Potion of Supreme Healing";
            icon = new I_Potion(7, Color.PINK);
            flavor = "Heals 10d4 + 20 health.";
            cost = 25000;
            die = new int[2] { 10, 4 };
            add = 20;
        }
    }

    class ThrowKnife : Item
    {
        public ThrowKnife(int many)
        {
            amount = many;
            name = "Throwing Dagger";
            icon = new I_Ranged(2, Color.RAYWHITE);
            cost = 1;
            party = false;
            die = new int[2] { 1, 4 };
            add = 0;
            fx = new Pierce();
        }
    }
    class Javelin : Item
    {
        public Javelin(int many)
        {
            amount = many;
            name = "Javelin";
            icon = new I_Ranged_2(6, Color.RAYWHITE);
            cost = 2;
            party = false;
            die = new int[2] { 1, 6 };
            add = 0;
            fx = new Pierce();
        }
    }
    class Bomb : Item
    {
        public Bomb(int many)
        {
            amount = many;
            name = "Bomb";
            icon = new I_Ranged_2(1, Color.RAYWHITE);
            cost = 150;
            party = false;
            die = new int[2] { 3, 6 };
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
        public Vector2 spr_ = Sprites.ax1;
        public FX hitFX;
        public int[] die = new int[2];
        public int dmgType;
        public int bonus = 0;
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
            spr_ = Sprites.dagg1;
            die = new int[2] { 1, 4 };
            hitFX = new Pierce();
            dmgType = (int)DamageType.Piercing;
        }
    }
    class Staff : Weapon
    {
        public Staff()
        {
            name = "Quarterstaff";
            flavor = "A wooden staff made for combat.\n1d4 blunt damage.";
            cost = 1;
            icon = new I_Rod(2, Color.RAYWHITE);
            spr = Sprites.mace1;
            die = new int[2] { 1, 6 };
            hitFX = new Blunt();
            dmgType = (int)DamageType.Blunt;
        }
    }
    class Mace : Weapon
    {
        public Mace()
        {
            name = "Mace";
            flavor = "A simple tool of destruction.\n1d6 blunt damage.";
            cost = 5;
            icon = new I_Rod(0, Color.RAYWHITE);
            spr = Sprites.mace1;
            spr_ = Sprites.mace;
            die = new int[2] { 1, 6 };
            hitFX = new Blunt();
            dmgType = (int)DamageType.Blunt;
        }
    }
    class Handaxe : Weapon
    {
        public Handaxe()
        {
            name = "Handaxe";
            flavor = "A survival tool fashioned into a weapon.\n1d6 slashing damage.";
            cost = 5;
            icon = new I_Axe(0, Color.RAYWHITE);
            spr = Sprites.axe1;
            die = new int[2] { 1, 6 };
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
        }
    }
    class Spear : Weapon
    {
        public Spear()
        {
            name = "Spear";
            flavor = "A long-range tool of warfare";
            cost = 1;
            icon = new I_Axe(0, Color.RAYWHITE);
            spr = Sprites.spear1;
            die = new int[2] { 1, 6 };
            hitFX = new Pierce();
            dmgType = (int)DamageType.Piercing;
        }
    }
    //martial
    class Shortsword : Weapon
    {
        public Shortsword()
        {
            name = "Shortsword";
            flavor = "A soldier's blade. Easily concealed.\n1d6 piercing damage.";
            cost = 10;
            icon = new I_Sword(0,Color.RAYWHITE);
            spr = Sprites.sword2;
            spr_ = Sprites.swrd1;
            die = new int[2] { 1, 6 };
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
            icon = new I_Sword(2,Color.RAYWHITE);
            spr = Sprites.sword2;
            spr_ = Sprites.swrd2;
            die = new int[2] { 1, 8 };
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
            icon = new I_Sword(3, Color.RAYWHITE);
            spr = Sprites.sword2;
            die = new int[2] { 2, 6 };
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
            twoHand = true;
        }
    }
    
    class Battleaxe : Weapon
    {
        public Battleaxe()
        {
            name = "Battleaxe";
            flavor = "A proper warrior's axe.\n1d8 slashing damage.";
            cost = 10;
            icon = new I_Axe(3, Color.RAYWHITE);
            spr = Sprites.axe2;
            die = new int[2] { 1, 8 };
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
        }
    }
    class Greataxe : Weapon
    {
        public Greataxe()
        {
            name = "Greataxe";
            flavor = "An axe for those with superior strength.\n1d12 slashing damage.";
            cost = 30;
            icon = new I_Axe(7, Color.RAYWHITE);
            spr = Sprites.axe3;
            die = new int[2] { 1, 12 };
            hitFX = new Slash();
            dmgType = (int)DamageType.Slashing;
            twoHand = true;
        }
    }
    class Maul : Weapon
    {
        public Maul()
        {
            name = "Maul";
            flavor = "A thinking man's hammer-axe.\n2d6 blunt damage.";
            cost = 10;
            icon = new I_Rod(0, Color.RAYWHITE);
            spr = Sprites.mace1;
            die = new int[2] { 2, 6 };
            hitFX = new Blunt();
            dmgType = (int)DamageType.Blunt;
        }
    }
    class Flail : Weapon
    {
        public Flail()
        {
            name = "Flail";
            flavor = "A more skillful counterpart to the mace,\nrequiring great strength and greater control\n1d8 blunt damage.";
            cost = 10;
            icon = new I_Rod(0, Color.RAYWHITE);
            spr = Sprites.flail1;
            die = new int[2] { 1, 8 };
            hitFX = new Blunt();
            dmgType = (int)DamageType.Blunt;
        }
    }
    class Shortbow : Weapon
    {
        public Shortbow()
        {
            name = "Shortbow";
            flavor = "A lightweight bow often used on horseback.\n1d6 piercing damage.";
            cost = 25;
            icon = new I_Ranged(3, Color.RAYWHITE);
            spr = Sprites.bow1;
            die = new int[2] { 1, 6 };
            ranged = true;
            hitFX = new Pierce();
            dmgType = (int)DamageType.Piercing;
        }
    }
    class Longbow : Weapon
    {
        public Longbow()
        {
            name = "Longbow";
            flavor = "A heavy bow used by infantrymen.\n1d8 piercing damage.";
            cost = 50;
            icon = new I_Ranged(3, Color.RAYWHITE);
            spr = Sprites.bow2;
            die = new int[2] { 1, 8 };
            ranged = true;
            hitFX = new Pierce();
            dmgType = (int)DamageType.Piercing;
        }
    }
}
