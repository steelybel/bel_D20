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
        Rectangle skin { get { return pcRace.skin; } }
        Rectangle hair { get { return pcRace.hair; } }
        Rectangle hair2{ get { return pcRace.hair2; } }
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
        Rectangle shield
        {
            get
            {
                return pcClass.shield;
            }
        }
        Rectangle wep
        {
            get
            {
                return weapon.spr;
            }
        }
        public void Draw(Texture2D spr, Vector2 pos)
        {
            if (hitPoints <= 0)
            {
                Vector2 posf = new Vector2(pos.x - 16, pos.y - 16);
                mouseArea = new Rectangle(pos.x - 8, pos.y - 8, 16, 16);
                rl.DrawTextureRec(Sprites.tiles, Sprites.grave, posf, Color.WHITE);
            }
            else
            {
                Vector2 posf = new Vector2(pos.x - 8, pos.y - 8);
                mouseArea = new Rectangle(pos.x - 8, pos.y - 8, 16, 16);
                rl.DrawTextureRec(spr, skin, posf, Color.WHITE);
                rl.DrawTextureRec(spr, bottom, posf, Color.WHITE);
                rl.DrawTextureRec(spr, shoe, posf, Color.WHITE);
                rl.DrawTextureRec(spr, top, posf, Color.WHITE);
                rl.DrawTextureRec(spr, hair2, posf, Color.WHITE);
                rl.DrawTextureRec(spr, hair, posf, Color.WHITE);
                rl.DrawTextureRec(spr, hat, posf, Color.WHITE);
                rl.DrawTextureRec(spr, shield, posf, Color.WHITE);
                rl.DrawTextureRec(spr, wep, posf, Color.WHITE);
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
        public Rectangle skin;
        public Rectangle hair;
        public Rectangle hair2;
        //score
        public int[] scoreMod = new int[6];
    }
    //RACES
    class Human_m : Race
    {
        public Human_m(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1; hair = new Rectangle(324, 0, 16, 16);
            if (skinColor == 1) skin = Sprites.skin2; hair = new Rectangle(392, 68, 16, 16);
            if (skinColor == 2) skin = Sprites.skin3; hair = new Rectangle(392, 68, 16, 16);
            scoreMod = new int[6] { 1, 1, 1, 1, 1, 1 };
        }
    }
    class Human_f : Race
    {
        public Human_f(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1f; hair = new Rectangle(341, 0, 16, 16);
            if (skinColor == 1) skin = Sprites.skin2f; hair = new Rectangle(409, 68, 16, 16);
            if (skinColor == 2) skin = Sprites.skin3f; hair = new Rectangle(443, 85, 16, 16);
            scoreMod = new int[6] { 1, 1, 1, 1, 1, 1 };
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
            scoreMod = new int[6] { 0, 2, 0, 1, 0, 0 };
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
            scoreMod = new int[6] { 0, 2, 0, 1, 0, 0 };
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
            scoreMod = new int[6] { 0, 0, 2, 0, 1, 0 };
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
            scoreMod = new int[6] { 0, 0, 2, 0, 1, 0 };
        }
    }
    class Hobbit_m : Race
    {
        public Hobbit_m(int skinColor)
        {
            if (skinColor == 0) { skin = Sprites.skin1; hair = new Rectangle(426, 34, 16, 16); }
            if (skinColor == 1) { skin = Sprites.skin2; hair = new Rectangle(358, 34, 16, 16); }
            if (skinColor == 2) { skin = Sprites.skin3; hair = new Rectangle(426, 102, 16, 16); }
            scoreMod = new int[6] { 0, 2, 0, 0, 0, 1 };
        }
    }
    class Hobbit_f : Race
    {
        public Hobbit_f(int skinColor)
        {
            if (skinColor == 0) skin = Sprites.skin1f; hair = new Rectangle(409, 0, 16, 16);
            if (skinColor == 1) skin = Sprites.skin2f; hair = new Rectangle(341, 0, 16, 16);
            if (skinColor == 2) skin = Sprites.skin3f; hair = new Rectangle(409, 102, 16, 16);
            scoreMod = new int[6] { 0, 2, 0, 0, 0, 1 };
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
        public List<Rectangle> wepf;// = new List<Rectangle>();
        public Weapon initWeapon;
        //score
        public int baseHP;
        public int wepDie;
        public int hitDie;
        public int armor;
        public int armorType;
        public int[] scores = new int[6];
        public bool ranged = false;
        public FX hitFX;
        public List<Skill> skillz;
    }
    class Barbarian : Class
    {
        public Barbarian()
        {
            top = Sprites.topBrb;
            bottom = Sprites.pants1;
            shoe = Sprites.shoe2;
            wepf = Sprites.axe;
            baseHP = 12;
            wepDie = Dice.d12(1);
            scores = new int[6] { 15, 12, 14, 8, 13, 10 };
            hitFX = new Blunt();
            initWeapon = new Greataxe();
            skillz = new List<Skill>()
            {

            };
        }
    }
    class Cleric : Class
    {
        public Cleric()
        {
            hat = Sprites.hatClr;
            top = Sprites.topPal;
            bottom = Sprites.pants1;
            shoe = Sprites.shoe3;
            shield = Sprites.shield1;
            wepf = Sprites.mace;
            baseHP = 8;
            wepDie = Dice.d6(1);
            hitDie = Dice.d8(1);
            armor = 13;
            armorType = 1;
            scores = new int[6] { 12, 10, 13, 8, 15, 14 };
            hitFX = new Blunt();
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
            bottom = Sprites.pants1;
            shoe = Sprites.shoe1;
            wepf = Sprites.knife;
            baseHP = 8;
            wepDie = Dice.d8(1);
            hitDie = Dice.d8(1);
            armor = 11;
            armorType = 0;
            scores = new int[6] { 14, 15, 8, 12, 10, 13 };
            hitFX = new Pierce();
            initWeapon = new Shortsword();
            skillz = new List<Skill>()
            {
                new Sneak(),
            };
        }
    }
    class Fighter : Class
    {
        public Fighter()
        {
            //hat = Sprites.hatWar;
            top = Sprites.topWar;
            bottom = Sprites.pants4;
            shoe = Sprites.shoe1;
            wepf = Sprites.sword;
            baseHP = 10;
            wepDie = Dice.d10(1);
            hitDie = Dice.d10(1);
            armor = 16;
            armorType = 2;
            scores = new int[6] { 15, 14, 13, 8, 10, 12 };
            hitFX = new Slash();
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
            hat = Sprites.hatWiz;
            top = Sprites.topWiz;
            bottom = new Rectangle(52, 34, 16, 16);
            //shoe = new Rectangle(69, 0, 16, 16);
            wepf = Sprites.staff;
            baseHP = 6;
            wepDie = Dice.d4(1);
            hitDie = Dice.d6(1);
            scores = new int[6] { 8, 12, 10, 15, 14, 13 };
            hitFX = new Blunt();
            initWeapon = new Dagger();
            skillz = new List<Skill>()
            {
                new MagMissile(),
                new AcidArrow(),
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
