using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Player
    {
        public Race pcRace;
        public Class pcClass;
        public int skinColor;
        public int[] stats = new int[6];
        int[] finStats = new int[6];
        int pStr;
        int pDex;
        int pCon;
        int pInt;
        int pWis;
        int pCha;
        public int wepLevel;
        Rectangle skin
        {
            get
            {
                return pcRace.skin;
            }
        }
        Rectangle hair
        {
            get
            {
                return pcRace.hair;
            }
        }
        Rectangle hair2
        {
            get
            {
                return pcRace.hair2;
            }
        }
        public Rectangle hat;
        public Rectangle top;
        public Rectangle bottom;
        public Rectangle shoe;
        public Rectangle shield;
        public Rectangle wep;
        public void Draw(Texture2D spr, Vector2 pos)
        {
            Vector2 posf = new Vector2(pos.x - 8, pos.y - 8);
            rl.DrawTextureRec(spr,skin,posf,Color.WHITE);
            rl.DrawTextureRec(spr,bottom,posf,Color.WHITE);
            rl.DrawTextureRec(spr,shoe,posf,Color.WHITE);
            rl.DrawTextureRec(spr,top,posf,Color.WHITE);
            rl.DrawTextureRec(spr,hair2,posf,Color.WHITE);
            rl.DrawTextureRec(spr,hair,posf,Color.WHITE);
            rl.DrawTextureRec(spr,hat,posf,Color.WHITE);
            rl.DrawTextureRec(spr,shield,posf,Color.WHITE);
            rl.DrawTextureRec(spr,wep,posf,Color.WHITE);
        }
    }
    class Race
    {
        //cosmetic
        public Rectangle skin;
        public Rectangle hair;
        public Rectangle hair2;
        //stats
        public int[] skillMod = new int[6];
    }
    //RACES
    class Elf_m : Race
    {
        public Elf_m()
        {
            skin = new Rectangle(0, 0, 16, 16);
            hair = new Rectangle(358, 85, 16, 16);
        }
    }
    class Elf_f : Race
    {
        public Elf_f()
        {
            skin = new Rectangle(17, 0, 16, 16);
            hair = new Rectangle(358, 85, 16, 16);
        }
    }
    class Dwarf_m : Race
    {
        public Dwarf_m()
        {
            skin = new Rectangle(0, 0, 16, 16);
            hair = new Rectangle(443, 17, 16, 16);
            hair2 = new Rectangle(426, 51, 16, 16);
        }
    }
    class Dwarf_f : Race
    {
        public Dwarf_f()
        {
            skin = new Rectangle(17, 0, 16, 16);
            hair = new Rectangle(443, 17, 16, 16);
            hair2 = new Rectangle(426, 51, 16, 16);
        }
    }
    //CLASSES
    class Class
    {
        //cosmetic
        public Rectangle hat;
        public Rectangle top;
        public Rectangle bottom;
        public Rectangle shoe;
        public Rectangle shield;
        public Rectangle wep;
        //stats
    }
    class Wizard : Class
    {
        public Wizard()
        {
            hat = new Rectangle(494, 136, 16, 16);
            top = new Rectangle(256, 119, 16, 16);
            wep = new Rectangle(715, 17, 16, 16);
        }
    }
    //premade chars
    class Premade1 : Player
    {
        public Premade1()
        {
            pcRace = new Elf_f();
            pcClass = new Wizard();
        }
    }
}
