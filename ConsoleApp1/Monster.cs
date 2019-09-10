using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Monster
    {
        public bool selected;
        public string name;
        public Rectangle sprite;
        public Color color;
        public Color dColor;
        public int maxHP;
        public int hitPoints;
        public int AC;
        public int plusHit;
        public int atkDmg;
        public Skill skill;
        public int skillChance;
        public FX hitFX;
        Rectangle infobox = new Rectangle(0, 0, 128, 48);
        Rectangle mouseArea;
        public void Spawn(Vector2 pos)
        {
            mouseArea = new Rectangle(pos.x-16, pos.y-16, 32, 32);
            hitPoints = maxHP;
            color = dColor;
            if (name != null)GameText.SpitOut(GameText.EnemyEntry(name));
        }
        public void Draw(Vector2 pos)
        {
            rl.DrawTextureRec(Sprites.tiles, sprite, new Vector2(pos.x - 16,pos.y - 16), color);
            string crap = (name + "\nHP - " + hitPoints);
            if (rl.CheckCollisionPointRec(rl.GetMousePosition(),mouseArea) && hitPoints > 0)
            {
                UI.MouseOver(UI.uiWhite2, crap, UI.bigFont);
                selected = true;
            }
            else
            {
                selected = false;
            }
            if (hitPoints <= 0)
            {
                color = Color.MAROON;
            }
        }
    }
    class Dead : Monster
    {
        public Dead()
        {
            sprite = Sprites.grave;
        }
    }
    //HUMANOIDS=============================
    class Goblin : Monster
    {
        public Goblin()
        {
            name = "Goblin";
            sprite = Sprites.gobby;
            dColor = Color.LIME;//new Color(154,255,84,255);
            maxHP = 7;
            AC = 15;
            plusHit = 4;
            atkDmg = (Dice.d6(1) + 2);
            hitFX = new Slash();
        }
    }
    class Hobgoblin_m : Monster
    {
        public Hobgoblin_m()
        {
            name = "Hobgoblin Warrior";
            sprite = Sprites.hob1;
            dColor = Color.ORANGE;
            maxHP = 11;
            AC = 18;
            plusHit = 3;
            atkDmg = (Dice.d8(1) + 1);
            hitFX = new Slash();
        }
    }
    class Hobgoblin_f : Monster
    {
        public Hobgoblin_f()
        {
            name = "Hobgoblin Amazon";
            sprite = Sprites.hob2;
            dColor = Color.ORANGE;
            maxHP = 11;
            AC = 18;
            plusHit = 3;
            atkDmg = (Dice.d8(1) + 1);
            hitFX = new Slash();
        }
    }
    class Orc : Monster
    {
        public Orc()
        {
            name = "Orc Marauder";
            sprite = Sprites.orc;
            dColor = new Color(235, 236, 128, 255);
            maxHP = 15;
            AC = 13;
            plusHit = 5;
            atkDmg = (Dice.d12(1) + 3);
            hitFX = new Slash();
        }
    }
    class Gnoll : Monster
    {
        public Gnoll()
        {
            name = "Gnoll Barbarian";
            sprite = Sprites.barb;
            dColor = new Color(236, 211, 52, 255);
            maxHP = 22;
            AC = 15;
            plusHit = 4;
            atkDmg = (Dice.d8(1) + 2);
            hitFX = new Slash();
        }
    }
    class Drow : Monster
    {
        public Drow()
        {
            name = "Drow Archer";
            sprite = Sprites.drow;
            dColor = Color.DARKGRAY;
            maxHP = 13;
            AC = 15;
            plusHit = 4;
            atkDmg = (Dice.d6(1) + 2);
            hitFX = new Pierce();
        }
    }
    //UNDEAD================================
    class Zombie : Monster
    {
        public Zombie()
        {
            name = "Shambling Corpse";
            sprite = Sprites.zom;
            dColor = Color.BEIGE;
            maxHP = 22;
            AC = 8;
            plusHit = 3;
            atkDmg = (Dice.d6(1) + 1);
            hitFX = new Blunt();
        }
    }
    class Bones : Monster
    {
        public Bones()
        {
            name = "Skeleton";
            sprite = Sprites.bones;
            dColor = Color.RAYWHITE;
            maxHP = 13;
            AC = 13;
            plusHit = 4;
            atkDmg = (Dice.d6(1) + 2);
            hitFX = new Slash();
        }
    }
    class Dracula : Monster
    {
        public Dracula()
        {
            name = "Vampire";
            sprite = Sprites.drac;
            dColor = new Color(213, 191, 255,255);
            maxHP = 82;
            AC = 15;
            plusHit = 6;
            atkDmg = (Dice.d4(2) + 3);
            hitFX = new Slash();
        }
    }
    class Ghost : Monster
    {
        public Ghost()
        {
            name = "Ghost";
            sprite = Sprites.boo;
            dColor = Color.SKYBLUE;
            maxHP = 45;
            AC = 11;
            plusHit = 5;
            atkDmg = (Dice.d6(4) + 3);
            hitFX = new Slash();
        }
    }
    class Mummy : Monster
    {
        public Mummy()
        {
            name = "Mummy";
            sprite = Sprites.mummy;
            dColor = Color.BEIGE;
            maxHP = 58;
            AC = 11;
            plusHit = 5;
            atkDmg = (Dice.d6(2) + 3);
            hitFX = new Blunt();
        }
    }
    //ANIMALS===============================
    class Wolf : Monster
    {
        public Wolf()
        {
            name = "Wolf";
            sprite = Sprites.wolf;
            dColor = Color.LIGHTGRAY;
            maxHP = 31;
            AC = 13;
            plusHit = 4;
            atkDmg = (Dice.d4(2) + 2);
            hitFX = new Slash();
        }
    }
    class Boar : Monster
    {
        public Boar()
        {
            name = "Boar";
            sprite = Sprites.boar;
            dColor = Color.BEIGE;
            maxHP = 11;
            AC = 11;
            plusHit = 3;
            atkDmg = (Dice.d6(1) + 1);
            hitFX = new Blunt();
        }
    }
    class Bear : Monster
    {
        public Bear()
        {
            name = "Black Bear";
            sprite = Sprites.bear;
            dColor = Color.GRAY;
            maxHP = 19;
            AC = 11;
            plusHit = 3;
            atkDmg = (Dice.d6(1) + 2);
            hitFX = new Slash();
        }
    }
    //FINAL BOSS============================
    class UltraLich : Monster
    {
        public UltraLich()
        {
            name = "Ultra-Lich";
            sprite = Sprites.hob2;
            dColor = Color.RAYWHITE;
            maxHP = 11;
            AC = 18;
            plusHit = 3;
            atkDmg = (Dice.d8(1) + 1);
            hitFX = new Slash();
        }
    }
}
