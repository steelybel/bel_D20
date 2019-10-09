using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Player
    {
        Rectangle mouseArea;
        public bool selected;
        public Race pcRace;
        public Class pcClass;
        public int maxHP;
        public int hitPoints;
        public string name = "fgsfds";
        //public int skinColor;
        public int[] score = new int[6];
        public int[] finScore = new int[6];
        public int scoreMod(int abilityScore)
        {
            int c = finScore[abilityScore];
            c -= 10;
            c /= 2;
            return c;

        }
        //public int die = pcClass.wepDie;
        public int AC = 10;
        public int wepLevel = 0;
        public int level = 0;
        public Weapon weapon;
        public Weapon offHand;
        public List<Skill> splList = new List<Skill>();
        public void StatInit()
        {
            score = pcClass.scores;
            finScore = new int[6]
            {
            score[0] + pcRace.scoreMod[0] + level,
            score[1] + pcRace.scoreMod[1] + level,
            score[2] + pcRace.scoreMod[2] + level,
            score[3] + pcRace.scoreMod[3] + level,
            score[4] + pcRace.scoreMod[4] + level,
            score[5] + pcRace.scoreMod[5] + level
            };
            if (pcClass.armor > 0)
            {
                if (pcClass.armorType < 2) { AC = pcClass.armor + scoreMod(2); }
                else { AC = pcClass.armor; }
            }
            else
            {
                AC = 10 + scoreMod(2);
            }
            weapon = pcClass.initWeapon;
            maxHP = pcClass.baseHP + scoreMod(2);
            hitPoints = maxHP;
            splList.Clear();
            for (int l = 0; l < Math.Clamp(level+1,1,pcClass.skillz.Count); l++)
            {
                splList.Add(pcClass.skillz[l]);
            }
            foreach(Skill spl in splList)
            {
                if (!spl.inf) { spl.UsesReset(); spl.UsesDisp(); }
            }
        }
        public void LevUp()
        {
            int newHP = pcClass.hitDie + scoreMod(2);
            maxHP += newHP;
        }
        public void StatUpd()
        {
            score = pcClass.scores;
            finScore = new int[6]
            {
            score[0] + pcRace.scoreMod[0] + level,
            score[1] + pcRace.scoreMod[1] + level,
            score[2] + pcRace.scoreMod[2] + level,
            score[3] + pcRace.scoreMod[3] + level,
            score[4] + pcRace.scoreMod[4] + level,
            score[5] + pcRace.scoreMod[5] + level
            };
            hitPoints = maxHP;
            if (pcClass.armor > 0)
            {
                if (pcClass.armorType < 2) { AC = pcClass.armor + scoreMod(2); }
                else { AC = pcClass.armor; }
            }
            else
            {
                AC = 10 + scoreMod(2);
            }
            splList.Clear();
            for (int l = 0; l < Math.Clamp(level + 1, 1, pcClass.skillz.Count); l++)
            {
                splList.Add(pcClass.skillz[l]);
            }
            foreach (Skill spl in splList)
            {
                if (!spl.inf) { spl.UsesReset(); }
            }
        }
        public List<Item> inventory = new List<Item>()
        {
            new Potion1(),
        };
        Vector2 skin { get { return pcRace.skin; } }
        Color skinColor { get { return pcRace.skinC; } }
        Vector2 hair { get { return pcRace.hair; } }
        Color hairColor { get { return pcRace.hairC; } }
        Vector2 layer { get { return pcRace.layer; } }
        Vector2 cape { get { return pcClass.cape; } }
        Vector2 hat
        {
            get
            {
                return pcClass.hat;
            }
        }
        Vector2 top
        {
            get
            {
                return pcClass.top;
            }
        }
        Vector2 bottom
        {
            get
            {
                return pcClass.bottom;
            }
        }
        Vector2 shoe
        {
            get
            {
                return pcClass.shoe;
            }
        }
        Vector2 shield
        {
            get
            {
                return pcClass.shield;
            }
        }
        Vector2 wep
        {
            get
            {
                return weapon.spr_;
            }
        }
        public void Draw(Texture2D spr, Vector2 pos)
        {
            
            mouseArea = new Rectangle(pos.x - 16, pos.y - 16, 32, 32);
            if (hitPoints <= 0)
            {
                Vector2 posf = new Vector2(pos.x - 16, pos.y - 16);
                rl.DrawTextureRec(Sprites.tiles, Sprites.grave, posf, Color.WHITE);
            }
            else
            {
                Sprites.Tile(skin, pos, skinColor);
                Sprites.Tile(bottom, pos);
                Sprites.Tile(shoe, pos);
                Sprites.Tile(top, pos);
                Sprites.Tile(hair, pos, hairColor);
                Sprites.Tile(layer, pos, hairColor);
                Sprites.Tile(wep, pos);
            }
            if (rl.CheckCollisionPointRec(rl.GetMousePosition(), mouseArea))
            {
                UI.MouseOver(UI.uiWhite2, GameText.HeroStats(this), UI.smallFont);
                selected = true;
            }
            else
            {
                selected = false;
            }
        }
    }
    class Race
    {
        //cosmetic
        public Vector2 skin;
        public Color skinC;
        public Color hairC;
        public Vector2 layer;
        public Vector2 hair;
        public Rectangle hair2;
        //score
        public int[] scoreMod = new int[6];
    }
    //RACES
    class Human_m : Race
    {
        public Human_m(int skinColor)
        {
            skin = Sprites.humanM;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.BROWN;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.DARKGRAY;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_short;
            scoreMod = new int[6] { 1, 1, 1, 1, 1, 1 };
        }
    }
    class Human_f : Race
    {
        public Human_f(int skinColor)
        {
            skin = Sprites.humanF;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.BROWN;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.DARKGRAY;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_long1;
            scoreMod = new int[6] { 1, 1, 1, 1, 1, 1 };
        }
    }
    class Elf_m : Race
    {
        public Elf_m(int skinColor)
        {
            skin = Sprites.elfM;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.YELLOW;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.BROWN;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_long1;
            scoreMod = new int[6] { 0, 2, 0, 1, 0, 0 };
        }
    }
    class Elf_f : Race
    {
        public Elf_f(int skinColor)
        {
            skin = Sprites.elfF;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.YELLOW;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.BROWN;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_pony1;
            scoreMod = new int[6] { 0, 2, 0, 1, 0, 0 };
        }
    }
    class Dwarf_m : Race
    {
        public Dwarf_m(int skinColor)
        {
            skin = Sprites.dwarfM;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.ORANGE;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.MAROON;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_long1;
            layer = Sprites.dwarfL;
            scoreMod = new int[6] { 0, 0, 2, 0, 1, 0 };
        }
    }
    class Dwarf_f : Race
    {
        public Dwarf_f(int skinColor)
        {
            skin = Sprites.dwarfF;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.ORANGE;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.MAROON;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_pony2;
            layer = Sprites.dwarfL;
            scoreMod = new int[6] { 0, 0, 2, 0, 1, 0 };
        }
    }
    class Hobbit_m : Race
    {
        public Hobbit_m(int skinColor)
        {
            skin = Sprites.hobbitM;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.ORANGE;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.BROWN;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_short;
            scoreMod = new int[6] { 0, 2, 0, 0, 0, 1 };
        }
    }
    class Hobbit_f : Race
    {
        public Hobbit_f(int skinColor)
        {
            skin = Sprites.hobbitF;
            switch (skinColor)
            {
                case 0:
                    skinC = Color.WHITE;
                    hairC = Color.ORANGE;
                    break;
                case 1:
                    skinC = Sprites.skinTan;
                    hairC = Color.BROWN;
                    break;
                case 2:
                    skinC = Sprites.skinDark;
                    hairC = Color.DARKGRAY;
                    break;
            }
            hair = Sprites.h_pony1;
            scoreMod = new int[6] { 0, 2, 0, 0, 0, 1 };
        }
    }
    //CLASSES
    class Class
    {
        //cosmetic
        public Vector2 hat;
        public Vector2 top;
        public Vector2 bottom;
        public Vector2 shoe;
        public Vector2 cape;
        public Vector2 shield;
        public Weapon initWeapon;
        //score
        public int baseHP;
        public int hitDie;
        public int armor;
        public int armorType;
        public int[] scores = new int[6];
        public List<Skill> skillz;
    }
    class Fighter : Class
    {
        public Fighter()
        {
            top = Sprites.topWar;
            bottom = Sprites.botWar;
            shoe = Sprites.shoeWar;
            shield = Sprites.buckler;
            baseHP = 10;
            hitDie = Dice.d10(1);
            armor = 16;
            armorType = 2;
            scores = new int[6] { 15, 14, 13, 8, 10, 12 };
            initWeapon = new Longsword();
            skillz = new List<Skill>()
            {
                new Crossbow(),
            };
        }
    }
    class Wizard : Class
    {
        public Wizard()
        {
            top = Sprites.topWiz;
            bottom = Sprites.botWiz;
            shoe = Sprites.shoeWiz;
            baseHP = 6;
            hitDie = Dice.d6(1);
            scores = new int[6] { 8, 12, 10, 15, 14, 13 };
            initWeapon = new Dagger();
            skillz = new List<Skill>()
            {
                new MagMissile(),
                new AcidArrow(),
            };
        }
    }
    class Cleric : Class
    {
        public Cleric()
        {
            top = Sprites.topClr;
            bottom = Sprites.botClr;
            shoe = Sprites.shoeClr;
            shield = Sprites.clrShld;
            baseHP = 8;
            hitDie = Dice.d8(1);
            armor = 13;
            armorType = 1;
            scores = new int[6] { 12, 10, 13, 8, 15, 14 };
            initWeapon = new Mace();
            skillz = new List<Skill>()
            {
                new Healing(),
            };
        }
    }
    class Rogue : Class
    {
        public Rogue()
        {
            top = Sprites.topRog;
            bottom = Sprites.botRog;
            shoe = Sprites.shoeRog;
            baseHP = 8;
            hitDie = Dice.d8(1);
            armor = 11;
            armorType = 0;
            scores = new int[6] { 14, 15, 8, 12, 10, 13 };
            initWeapon = new Shortsword();
            skillz = new List<Skill>()
            {
                new Sneak(),
            };
        }
    }
    
    class Barbarian : Class
    {
        public Barbarian()
        {
            baseHP = 12;
            scores = new int[6] { 15, 12, 14, 8, 13, 10 };
            initWeapon = new Greataxe();
            skillz = new List<Skill>()
            {

            };
        }
    }
    class Ranger : Class
    {
        public Ranger()
        {
            baseHP = 12;
            hitDie = Dice.d10(1);
            scores = new int[6] { 15, 12, 14, 8, 13, 10 };
            initWeapon = new Longbow();
            skillz = new List<Skill>()
            {

            };
        }
    }
    //premade chars
    class Premade1 : Player
    {
        public Premade1()
        {
            name = "Beluwyn";
            pcRace = new Elf_f(0);
            pcClass = new Wizard();
        }
    }
    class Premade2 : Player
    {
        public Premade2()
        {
            name = "Jeremiah";
            pcRace = new Human_m(2);
            pcClass = new Cleric();
        }
    }
    class Premade3 : Player
    {
        public Premade3()
        {
            name = "Audhild";
            pcRace = new Dwarf_f(1);
            pcClass = new Fighter();
        }
    }
    class Premade4 : Player
    {
        public Premade4()
        {
            name = "Merric";
            pcRace = new Hobbit_m(0);
            pcClass = new Rogue();
        }
    }
}
