using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Monster
    {
        public string name;
        public Rectangle sprite;
        public Color color;
        public int maxHP;
        public int hitPoints;
        public int AC;
        public int plusHit;
        public int atkDmg;
        public Skill skill;
        public int skillChance;
        Rectangle infobox = new Rectangle(0, 0, 128, 48);
        Rectangle mouseArea;
        public void Spawn(Vector2 pos)
        {
            mouseArea = new Rectangle(pos.x-16, pos.y-16, 32, 32);
            hitPoints = maxHP;
            GameText.SpitOut(GameText.EnemyEntry(name));
        }
        public void Draw(Vector2 pos)
        {
            rl.DrawTextureRec(Sprites.tiles, sprite, new Vector2(pos.x - 16,pos.y - 16), color);
            string crap = (name + "\nHP - " + hitPoints);
            if (rl.CheckCollisionPointRec(rl.GetMousePosition(),mouseArea) && hitPoints > 0)
            {
                UI.MouseOver(UI.uiWhite2, crap, UI.bigFont);
            }
        }
    }
    class Goblin : Monster
    {
        public Goblin()
        {
            name = "Goblin";
            sprite = Sprites.gobby;
            color = new Color(154,255,84,255);
            maxHP = 7;
            AC = 15;
            plusHit = 4;
            atkDmg = (Dice.d6(1) + 2);
        }
    }
    class Hobgoblin_m : Monster
    {
        public Hobgoblin_m()
        {
            name = "Hobgoblin Warrior";
            sprite = Sprites.hob1;
            color = Color.ORANGE;
            maxHP = 11;
            AC = 18;
            plusHit = 3;
            atkDmg = (Dice.d8(1) + 1);
        }
    }
    class Hobgoblin_f : Monster
    {
        public Hobgoblin_f()
        {
            name = "Hobgoblin Amazon";
            sprite = Sprites.hob2;
            color = Color.ORANGE;
            maxHP = 11;
            AC = 18;
            plusHit = 3;
            atkDmg = (Dice.d8(1) + 1);
        }
    }
    class Wolf : Monster
    {
        public Wolf()
        {
            name = "Wolf";
            sprite = Sprites.wolf;
            color = Color.LIGHTGRAY;
            maxHP = 31;
            AC = 13;
            plusHit = 4;
            atkDmg = (Dice.d4(2) + 2);
        }
    }
    class Boar : Monster
    {
        public Boar()
        {
            name = "Boar";
            sprite = Sprites.boar;
            color = Color.BEIGE;
            maxHP = 11;
            AC = 11;
            plusHit = 3;
            atkDmg = (Dice.d6(1) + 1);
        }
    }
    class Bear : Monster
    {
        public Bear()
        {
            name = "Black Bear";
            sprite = Sprites.bear;
            color = Color.GRAY;
            maxHP = 19;
            AC = 11;
            plusHit = 3;
            atkDmg = (Dice.d6(1) + 2);
        }
    }
    class UltraLich : Monster
    {
        public UltraLich()
        {
            name = "Ultra-Lich";
            sprite = Sprites.hob2;
            color = Color.RAYWHITE;
            maxHP = 11;
            AC = 18;
            plusHit = 3;
            atkDmg = (Dice.d8(1) + 1);
        }
    }
}
