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
        public static Texture2D uTiles = rl.LoadTexture("Resources/Sprites/ProjectUtumno_full.png");
        public static void Tile(int x, int y, Vector2 pos)
        {
            Rectangle tile = new Rectangle(x * 32, y * 32, 32, 32);
            rl.DrawTextureRec(uTiles, tile, pos, Color.WHITE);
        }
        public static void Tile(Vector2 xy, Vector2 pos)
        {
            Vector2 posR = new Vector2(pos.x - 16, pos.y - 16);
            Rectangle tile = new Rectangle(xy.x * 32, xy.y * 32, 32, 32);
            rl.DrawTextureRec(uTiles, tile, posR, Color.WHITE);
        }
        public static void Tile(Vector2 xy, Vector2 pos, Color col)
        {
            Vector2 posR = new Vector2(pos.x - 16, pos.y - 16);
            Rectangle tile = new Rectangle(xy.x * 32, xy.y * 32, 32, 32);
            rl.DrawTextureRec(uTiles, tile, posR, col);
        }
        //PLAYER
        public static Color skinTan = new Color(219,192,160,255);
        public static Color skinDark = new Color(112,67,41,255);
        public static Vector2 humanM = new Vector2(9,80);
        public static Vector2 humanF = new Vector2(8,80);
        public static Vector2 elfM = new Vector2(61, 79);
        public static Vector2 elfF = new Vector2(60, 79);
        public static Vector2 dwarfM = new Vector2(59, 79);
        public static Vector2 dwarfF = new Vector2(58, 79);
        public static Vector2 dwarfL = new Vector2(23, 94);
        public static Vector2 hobbitM = new Vector2(7, 80);
        public static Vector2 hobbitF = new Vector2(6, 80);
        public static Vector2 h_short = new Vector2(34, 85);
        public static Vector2 h_long1 = new Vector2(11, 85);
        public static Vector2 h_long2 = new Vector2(15, 85);
        public static Vector2 h_pony1 = new Vector2(8, 85);
        public static Vector2 h_pony2 = new Vector2(7, 85);

        public static Vector2 topWar    = new Vector2(19, 82);
        public static Vector2 botWar    = new Vector2(30, 93);
        public static Vector2 shoeWar   = new Vector2(59, 83);
        public static Vector2 topWiz    = new Vector2(8, 83);
        public static Vector2 topWiz_   = new Vector2(16, 82);
        public static Vector2 botWiz    = new Vector2(32, 93);
        public static Vector2 botWiz_   = new Vector2(57, 93);
        public static Vector2 shoeWiz   = new Vector2(57, 93);
        public static Vector2 capeWiz   = new Vector2(13, 84);
        public static Vector2 topClr    = new Vector2(19, 81);
        public static Vector2 botClr    = new Vector2(32, 93);
        public static Vector2 shoeClr   = new Vector2(32, 93);
        public static Vector2 topRog    = new Vector2(30,83);
        public static Vector2 botRog    = new Vector2(47, 93);
        public static Vector2 shoeRog   = new Vector2(59, 83);
        public static Vector2 topBarb   = new Vector2(4,82);
        public static Vector2 botBarb   = new Vector2(45, 93);
        public static Vector2 shoeBarb  = new Vector2(53, 83);

        public static Vector2 swrd1     = new Vector2(16,89);
        public static Vector2 swrd2     = new Vector2(8,87);
        public static Vector2 dagg1     = new Vector2(8,88);
        public static Vector2 ax1       = new Vector2(16, 87);
        public static Vector2 mace      = new Vector2(61, 88);
        public static Vector2 buckler   = new Vector2(39, 85);
        public static Vector2 clrShld   = new Vector2(51, 85);

        public static Rectangle sword1 = new Rectangle(732, 102, 16, 16);
        public static Rectangle sword2 = new Rectangle(749, 102, 16, 16);
        public static Rectangle sword3 = new Rectangle(766, 102, 16, 16);
        public static Rectangle sword4 = new Rectangle(783, 102, 16, 16);
        public static Rectangle scim = new Rectangle(749, 135, 16, 16);
        public static Rectangle knife1 = new Rectangle(732, 119, 16, 16);
        public static Rectangle knife2 = new Rectangle(749, 119, 16, 16);
        public static Rectangle knife3 = new Rectangle(766, 119, 16, 16);
        public static Rectangle knife4 = new Rectangle(783, 119, 16, 16);
        public static Rectangle mace1 = new Rectangle(800, 0, 16, 16);
        public static Rectangle mace2 = new Rectangle(800, 68, 16, 16);
        public static Rectangle mace3 = new Rectangle(800, 102, 16, 16);
        public static Rectangle mace4 = new Rectangle(800, 136, 16, 16);
        public static Rectangle flail1 = new Rectangle(817, 0, 16, 16);
        public static Rectangle flail2 = new Rectangle(817, 68, 16, 16);
        public static Rectangle flail3 = new Rectangle(817, 102, 16, 16);
        public static Rectangle flail4 = new Rectangle(817, 136, 16, 16);
        public static Rectangle staff1 = new Rectangle(715, 0, 16, 16);
        public static Rectangle staff2 = new Rectangle(715, 51, 16, 16);
        public static Rectangle staff3 = new Rectangle(715, 17, 16, 16);
        public static Rectangle staff4 = new Rectangle(715, 34, 16, 16);
        public static Rectangle spear1 = new Rectangle(834, 0, 16, 16);
        public static Rectangle axe1 = new Rectangle(817, 17, 16, 16);
        public static Rectangle axe2 = new Rectangle(800, 17, 16, 16);
        public static Rectangle axe3 = new Rectangle(868, 0, 16, 16);
        public static Rectangle axe4 = new Rectangle(800, 153, 16, 16);
        public static Rectangle bow1 = new Rectangle(885, 0, 16, 16);
        public static Rectangle bow2 = new Rectangle(885, 17, 16, 16);
        public static Rectangle bow3 = new Rectangle(902, 17, 16, 16);
        public static Rectangle bow4 = new Rectangle(902, 68, 16, 16);
        //ICONS ======
        public static Vector2 i_knife_ = new Vector2(17, 45);
        public static Vector2 i_shortsword = new Vector2(18, 45);
        public static Vector2 i_longsword = new Vector2(18, 45);
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
