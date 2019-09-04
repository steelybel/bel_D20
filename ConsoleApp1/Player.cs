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
        //public int skinColor;
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
        Rectangle hat
        {
            get
            {
                return pcClass.hat;
            }
        }
        Rectangle top
        {
            get
            {
                return pcClass.top;
            }
        }
        Rectangle bottom
        {
            get
            {
                return pcClass.bottom;
            }
        }
        Rectangle shoe
        {
            get
            {
                return pcClass.shoe;
            }
        }
        public Rectangle shield;
        Rectangle wep
        {
            get
            {
                return pcClass.wep[wepLevel];
            }
        }
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
    class Human_m : Race
    {
        public Human_m(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1; hair = new Rectangle(324, 0, 16, 16);
            if (skinColor == 1) skin = Sprites.skin2; hair = new Rectangle(392, 68, 16, 16);
            if (skinColor == 2) skin = Sprites.skin3; hair = new Rectangle(392, 68, 16, 16);
        }
    }
    class Human_f : Race
    {
        public Human_f(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1f; hair = new Rectangle(341, 0, 16, 16);
            if (skinColor == 1) skin = Sprites.skin2f; hair = new Rectangle(409, 68, 16, 16);
            if (skinColor == 2) skin = Sprites.skin3f; hair = new Rectangle(443, 85, 16, 16);
        }
    }
    class Elf_m : Race
    {
        public Elf_m(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1;
            if (skinColor == 1) skin = Sprites.skin2;
            if (skinColor == 2) skin = Sprites.skin3;
            hair = new Rectangle(341, 68, 16, 16);
        }
    }
    class Elf_f : Race
    {
        public Elf_f(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1f;
            if (skinColor == 1) skin = Sprites.skin2f;
            if (skinColor == 2) skin = Sprites.skin3f;
            hair = new Rectangle(358, 85, 16, 16);
        }
    }
    class Dwarf_m : Race
    {
        public Dwarf_m(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1;
            if (skinColor == 1) skin = Sprites.skin2;
            if (skinColor == 2) skin = Sprites.skin3;
            hair = new Rectangle(443, 17, 16, 16);
            hair2 = new Rectangle(426, 51, 16, 16);
        }
    }
    class Dwarf_f : Race
    {
        public Dwarf_f(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1f;
            if (skinColor == 1) skin = Sprites.skin2f;
            if (skinColor == 2) skin = Sprites.skin3f;
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
        public Rectangle[] wep = new Rectangle[5];
        //stats
    }
    class Barbarian : Class
    {
        public Barbarian()
        {
            top = Sprites.topBrb;
            bottom = Sprites.pants1;
            shoe = Sprites.shoe2;
            //wep = new Rectangle[](715, 17, 16, 16);
        }
    }
    class Paladin : Class
    {
        public Paladin()
        {
            top = Sprites.topPal;
            bottom = Sprites.pants1;
            shoe = Sprites.shoe3;
            //wep = new Rectangle[](715, 17, 16, 16);
        }
    }
    class Rogue : Class
    {
        public Rogue()
        {
            top = Sprites.topRog;
            bottom = Sprites.pants1;
            shoe = Sprites.shoe1;
            //wep = new Rectangle[](715, 17, 16, 16);
        }
    }
    class Wizard : Class
    {
        public Wizard()
        {
            hat = new Rectangle(494, 136, 16, 16);
            top = Sprites.topWiz;
            bottom = new Rectangle(52, 34, 16, 16);
            shoe = new Rectangle(69, 0, 16, 16);
            //wep = new Rectangle[](715, 17, 16, 16);
        }
    }
    //premade chars
    class Premade1 : Player
    {
        public Premade1()
        {
            pcRace = new Elf_f(0);
            pcClass = new Wizard();
        }
    }
    class Premade2 : Player
    {
        public Premade2()
        {
            pcRace = new Human_m(2);
            pcClass = new Paladin();
        }
    }
}
