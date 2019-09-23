using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Sprites
    {
        public static Texture2D tiles = rl.LoadTexture("Resources/Sprites/fantasy-tileset.png");
        //PLAYER
        public static Rectangle skin1 = new Rectangle(0, 0, 16, 16);
        public static Rectangle skin1f = new Rectangle(17, 0, 16, 16);
        public static Rectangle skin2 = new Rectangle(0, 17, 16, 16);
        public static Rectangle skin2f = new Rectangle(17, 17, 16, 16);
        public static Rectangle skin3 = new Rectangle(0, 34, 16, 16);
        public static Rectangle skin3f = new Rectangle(17, 34, 16, 16);
        public static Rectangle skin4 = new Rectangle(0, 51, 16, 16);
        public static Rectangle skin4f = new Rectangle(17, 51, 16, 16);
        public static Rectangle topPal = new Rectangle(171, 68, 16, 16);
        public static Rectangle topWar = new Rectangle(154, 51, 16, 16);
        public static Rectangle topRog = new Rectangle(239, 85, 16, 16);
        public static Rectangle topWiz = new Rectangle(120, 119, 16, 16);
        public static Rectangle topBrb = new Rectangle(222, 119, 16, 16);
        public static Rectangle hatClr = new Rectangle(222, 68, 16, 16);
        public static Rectangle hatWiz = new Rectangle(528, 136, 16, 16);
        public static Rectangle hatWar = new Rectangle(477, 102, 16, 16);
        public static Rectangle pants1 = new Rectangle(52, 0, 16, 16);
        public static Rectangle pants2 = new Rectangle(52, 17, 16, 16);
        public static Rectangle pants3 = new Rectangle(52, 34, 16, 16);
        public static Rectangle pants4 = new Rectangle(52, 51, 16, 16);
        public static Rectangle pants5 = new Rectangle(52, 85, 16, 16);
        public static Rectangle pants6 = new Rectangle(52, 102, 16, 16);
        public static Rectangle pants7 = new Rectangle(52, 119, 16, 16);
        public static Rectangle pants8 = new Rectangle(52, 136, 16, 16);
        public static Rectangle shoe1 = new Rectangle(69, 0, 16, 16);
        public static Rectangle shoe2 = new Rectangle(69, 17, 16, 16);
        public static Rectangle shoe3 = new Rectangle(69, 34, 16, 16);
        public static Rectangle shoe4 = new Rectangle(69, 51, 16, 16);
        public static Rectangle shoe5 = new Rectangle(69, 85, 16, 16);
        public static Rectangle shoe6 = new Rectangle(69, 102, 16, 16);
        public static Rectangle shoe7 = new Rectangle(69, 119, 16, 16);
        public static Rectangle shoe8 = new Rectangle(69, 136, 16, 16);
        public static Rectangle shield1 = new Rectangle(613, 51, 16, 16);
        public static Rectangle shield2 = new Rectangle(647, 34, 16, 16);
        public static Rectangle sword1 = new Rectangle(732, 102, 16, 16);
        public static Rectangle sword2 = new Rectangle(749, 102, 16, 16);
        public static Rectangle sword3 = new Rectangle(766, 102, 16, 16);
        public static Rectangle sword4 = new Rectangle(783, 102, 16, 16);
        public static Rectangle knife1 = new Rectangle(732, 119, 16, 16);
        public static Rectangle knife2 = new Rectangle(749, 119, 16, 16);
        public static Rectangle knife3 = new Rectangle(766, 119, 16, 16);
        public static Rectangle knife4 = new Rectangle(783, 119, 16, 16);
        public static Rectangle mace1 = new Rectangle(800, 0, 16, 16);
        public static Rectangle mace2 = new Rectangle(800, 68, 16, 16);
        public static Rectangle mace3 = new Rectangle(800, 102, 16, 16);
        public static Rectangle mace4 = new Rectangle(800, 136, 16, 16);
        public static Rectangle staff1 = new Rectangle(715, 0, 16, 16);
        public static Rectangle staff2 = new Rectangle(715, 51, 16, 16);
        public static Rectangle staff3 = new Rectangle(715, 17, 16, 16);
        public static Rectangle staff4 = new Rectangle(715, 34, 16, 16);
        public static Rectangle axe1 = new Rectangle(817, 17, 16, 16);
        public static Rectangle axe2 = new Rectangle(800, 17, 16, 16);
        public static Rectangle axe3 = new Rectangle(868, 0, 16, 16);
        public static Rectangle axe4 = new Rectangle(800, 153, 16, 16);
        public static Rectangle bow1 = new Rectangle(885, 0, 16, 16);
        public static Rectangle bow2 = new Rectangle(885, 17, 16, 16);
        public static Rectangle bow3 = new Rectangle(902, 17, 16, 16);
        public static Rectangle bow4 = new Rectangle(902, 68, 16, 16);
        public static List<Rectangle> knife = new List<Rectangle> { knife1, knife2, knife3, knife4 };
        public static List<Rectangle> sword = new List<Rectangle> { sword1, sword2, sword3, sword4 };
        public static List<Rectangle> mace = new List<Rectangle> { mace1, mace2, mace3, mace4 };
        public static List<Rectangle> bow = new List<Rectangle> { bow1, bow2, bow3, bow4 };
        public static List<Rectangle> axe = new List<Rectangle> { axe1, axe2, axe3, axe4 };
        public static List<Rectangle> staff = new List<Rectangle> { staff1, staff2, staff3, staff4 };
        //ICONS ======
        public static Rectangle i_sword = new Rectangle(0, 224, 32, 32);
        public static Rectangle i_knife = new Rectangle(64, 288, 16, 16);
        public static Rectangle i_book = new Rectangle(128, 192, 32, 32);
        public static Rectangle i_item = new Rectangle(224, 160, 32, 32);
        public static Rectangle i_flee = new Rectangle(192, 32, 32, 32);
        public static Rectangle i_hand = new Rectangle(0, 736, 16, 16);
        public static Rectangle i_skull = new Rectangle(192, 736, 16, 16);
        public static Rectangle[] i_race = new Rectangle[4]
        {
            new Rectangle(64,576,32,32),//human
            new Rectangle(128,576,32,32),//elf
            new Rectangle(32,576,32,32),//dwarf
            new Rectangle(96,576,32,32),//halfling
        };
        public static Rectangle[] i_class = new Rectangle[4]
        {
            new Rectangle(160,576,32,32),//fighter
            new Rectangle(192,576,32,32),//wizard
            new Rectangle(32,576,32,32),//cleric
            new Rectangle(0,576,32,32),//rogue
        };
        public static Rectangle[] symbol = new Rectangle[6]
        {
            new Rectangle(0, 544, 32, 32),
            new Rectangle(32, 544, 32, 32),
            new Rectangle(64, 544, 32, 32),
            new Rectangle(96, 544, 32, 32),
            new Rectangle(128, 544, 32, 32),
            new Rectangle(160, 544, 32, 32),
        };
        public static Rectangle[] i_swords = new Rectangle[8]
        {
            new Rectangle(0, 224, 32, 32),
            new Rectangle(32, 224, 32, 32),
            new Rectangle(64, 224, 32, 32),
            new Rectangle(96, 224, 32, 32),
            new Rectangle(128, 224, 32, 32),
            new Rectangle(160, 224, 32, 32),
            new Rectangle(192, 224, 32, 32),
            new Rectangle(224, 224, 32, 32),
        };
        public static Rectangle[] i_axes = new Rectangle[8]
        {
            new Rectangle(0, 256, 32, 32),
            new Rectangle(32, 256, 32, 32),
            new Rectangle(64, 256, 32, 32),
            new Rectangle(96, 256, 32, 32),
            new Rectangle(128, 256, 32, 32),
            new Rectangle(160, 256, 32, 32),
            new Rectangle(192, 256, 32, 32),
            new Rectangle(224, 256, 32, 32),
        };
        public static Rectangle[] i_rods = new Rectangle[8]
        {
            new Rectangle(0, 448, 32, 32),
            new Rectangle(32, 448, 32, 32),
            new Rectangle(64, 448, 32, 32),
            new Rectangle(96, 448, 32, 32),
            new Rectangle(128, 448, 32, 32),
            new Rectangle(160, 448, 32, 32),
            new Rectangle(192, 448, 32, 32),
            new Rectangle(224, 448, 32, 32),
        };

        public static Rectangle[] i_range = new Rectangle[8]
        {
            new Rectangle(0, 288, 32, 32),
            new Rectangle(32, 288, 32, 32),
            new Rectangle(64, 288, 32, 32),
            new Rectangle(96, 288, 32, 32),
            new Rectangle(128, 288, 32, 32),
            new Rectangle(160, 288, 32, 32),
            new Rectangle(192, 288, 32, 32),
            new Rectangle(224, 288, 32, 32),
        };
        public static Rectangle[] i_range2 = new Rectangle[8]
        {
            new Rectangle(0, 320, 32, 32),
            new Rectangle(32, 320, 32, 32),
            new Rectangle(64, 320, 32, 32),
            new Rectangle(96, 320, 32, 32),
            new Rectangle(128, 320, 32, 32),
            new Rectangle(160, 320, 32, 32),
            new Rectangle(192, 320, 32, 32),
            new Rectangle(224, 320, 32, 32),
        };
        public static Rectangle[] i_armor = new Rectangle[8]
        {
            new Rectangle(0, 352, 32, 32),
            new Rectangle(32, 352, 32, 32),
            new Rectangle(64, 352, 32, 32),
            new Rectangle(96, 352, 32, 32),
            new Rectangle(128, 352, 32, 32),
            new Rectangle(160, 352, 32, 32),
            new Rectangle(192, 352, 32, 32),
            new Rectangle(224, 352, 32, 32),
        };
        public static Rectangle[] i_potion = new Rectangle[8]
        {
            new Rectangle(0, 160, 32, 32),
            new Rectangle(32, 160, 32, 32),
            new Rectangle(64, 160, 32, 32),
            new Rectangle(96, 160, 32, 32),
            new Rectangle(128, 160, 32, 32),
            new Rectangle(160, 160, 32, 32),
            new Rectangle(192, 160, 32, 32),
            new Rectangle(224, 160, 32, 32),
        };
        //ENEMY ======
        public static Rectangle grave = new Rectangle(96, 512, 32, 32);
        //humanoid monsters
        public static Rectangle gobby = new Rectangle(0, 576, 32, 32);
        public static Rectangle kobby = new Rectangle(0,704,32,32);
        public static Rectangle orc = new Rectangle(96,704,32,32);
        public static Rectangle hob1 = new Rectangle(0,576,32,32);
        public static Rectangle hob2 = new Rectangle(96,576,32,32);
        public static Rectangle barb = new Rectangle(64,576,32,32);
        public static Rectangle dorf = new Rectangle(32,576,32,32);
        public static Rectangle drow = new Rectangle(128,576,32,32);
        //undead
        public static Rectangle zom = new Rectangle(32,704,32,32);
        public static Rectangle bones = new Rectangle(64,704,32,32);
        public static Rectangle drac = new Rectangle(128,672,32,32);
        public static Rectangle mummy = new Rectangle(160,672,32,32);
        public static Rectangle boo = new Rectangle(192,672,32,32);
        //bugs
        public static Rectangle spoder = new Rectangle(96, 608, 32, 32);
        public static Rectangle ciders = new Rectangle(64, 608, 32, 32);
        //animals
        public static Rectangle frog = new Rectangle(96, 608, 32, 32);
        public static Rectangle bat1 = new Rectangle(64,640,32,32);
        public static Rectangle bat2 = new Rectangle(96,640,32,32);
        public static Rectangle wolf = new Rectangle(160,640,32,32);
        public static Rectangle boar = new Rectangle(192,640,32,32);
        public static Rectangle bear = new Rectangle(224,640,32,32);
        public static Rectangle lich = new Rectangle(224, 704, 32, 32);
        //FX
        public static Texture2D miss = rl.LoadTexture("Resources/FX/circle01.png");
        public static Texture2D magMis = rl.LoadTexture("Resources/FX/impact01.png");
        public static Texture2D blunt = rl.LoadTexture("Resources/FX/break01.png");
        public static Texture2D blunt2 = rl.LoadTexture("Resources/FX/shards01.png");
        public static Texture2D slash = rl.LoadTexture("Resources/FX/hit01.png");
        public static Texture2D splash = rl.LoadTexture("Resources/FX/splash01.png");
        public static Texture2D pierce = rl.LoadTexture("Resources/FX/shards02.png");
    }
    class Icon
    {
        public Rectangle spr;
        public Color color;
    }
    class I_Sword : Icon
    {
        public I_Sword(int num, Color col)
        {
            if (num > Sprites.i_swords.Length) { num = 0; }
            spr = Sprites.i_swords[num];
            color = col;
        }
    }
    class I_Axe : Icon
    {
        public I_Axe(int num, Color col)
        {
            if (num > Sprites.i_axes.Length) { num = 0; }
            spr = Sprites.i_axes[num];
            color = col;
        }
    }
    class I_Rod : Icon
    {
        public I_Rod(int num, Color col)
        {
            if (num > Sprites.i_rods.Length) { num = 0; }
            spr = Sprites.i_rods[num];
            color = col;
        }
    }
    class I_Dagger : Icon
    {
        public I_Dagger(Color col)
        {

            spr = Sprites.i_knife;
            color = Color.RAYWHITE;
        }
    }
    class I_Ranged : Icon
    {
        public I_Ranged(int num, Color col)
        {
            if (num > Sprites.i_range.Length) { num = 0; }
            spr = Sprites.i_range[num];
            color = col;
        }
    }
    class I_Ranged_2 : Icon
    {
        public I_Ranged_2(int num, Color col)
        {
            if (num > Sprites.i_range2.Length) { num = 0; }
            spr = Sprites.i_range2[num];
            color = col;
        }
    }
    class I_Potion : Icon
    {
        public I_Potion(int num, Color col)
        {
            if (num > Sprites.i_potion.Length) { num = 0; }
            spr = Sprites.i_potion[num];
            color = col;
        }
    }
    class IconSpell : Icon
    {
        public IconSpell(int num, Color col)
        {
            if (num > Sprites.symbol.Length) { num = 0; }
            spr = Sprites.symbol[num];
            color = col;
        }
    }
    class I_Attack : Icon
    {
        public I_Attack()
        {
            spr = Sprites.i_sword;
            color = Color.WHITE;
        }
    }
    class I_Spell : Icon
    {
        public I_Spell()
        {
            spr = Sprites.i_book;
            color = Color.WHITE;
        }
    }
    class I_Item : Icon
    {
        public I_Item()
        {
            spr = Sprites.i_item;
            color = Color.WHITE;
        }
    }
    class I_Flee : Icon
    {
        public I_Flee()
        {
            spr = Sprites.i_flee;
            color = Color.WHITE;
        }
    }

    class I_Race : Icon
    {
        public I_Race(int num, Color col)
        {
            if (num > Sprites.i_race.Length) { num = 0; }
            spr = Sprites.i_race[num];
            color = col;
        }
    }

    class I_Class : Icon
    {
        public I_Class(int num, Color col)
        {
            if (num > Sprites.i_class.Length) { num = 0; }
            spr = Sprites.i_class[num];
            color = col;
        }
    }
}
