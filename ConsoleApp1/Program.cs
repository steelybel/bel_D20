using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    static class Program
    {
        static Random rng = new Random();
        static bool choosing = true;
        static bool choice = false;
        static bool monsterAtk = false;
        static Skill skill = null;
        static Item item = null;
        static int multTarg = 0;
        static List<int> targets = new List<int>();
        static bool splReady = false;
        public static FX currentFX = new FX();
        public static int timer = 0;
        public static Dice dice = new Dice();
        public static bool looping = true;
        public static int turn = 0;
        public static int rTurn = 0;
        public static int turnM = 0;
        public static int rTurnM = 0;
        public static List<int> battleOrder = new List<int>();
        public static List<int> battleOrderM = new List<int>();
        static char[] blank = new char[] { '\0' };
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            rl.InitWindow(screenWidth, screenHeight, "Dungeons!");
            rl.SetTargetFPS(60);
            Texture2D hero = rl.LoadTexture("Resources/Sprites/roguelikeChar_transparent.png");
            bool starting = true;
            int creating = 0;
            bool inBattle = false;
            bool fightReady = false;
            bool looting = false;
            bool itemOrWep = false;
            bool gameOver = false;
            Item lootItem = new Item();
            Weapon lootWep = new Weapon();
            IComparer revComp = new ReverseComparer();
            int day = 0;
            int gold = 400;
            int fights = 0;
            int maxFights = 6;
            int partyLvl = 0;
            int partyXP = 0;
            bool splChoose = false;
            bool itmChoose = false;
            List<Monster> monsterList = new List<Monster>();
            Rectangle mainText = new Rectangle(160, 0, 480, 96);
            Vector2 textPlace = new Vector2((screenWidth / 2), 48);
            Font curFont = UI.bigFont;
            int textScl = curFont.baseSize;
            int midWidth = screenWidth / 2;
            int midHeight = screenHeight / 2;
            
            ExitOut xOut = new ExitOut();
            //charcreation====================================================
            Button[] raceButtons = new Button[]
            {
                new CButton(new I_Race(0,Color.WHITE), "Human", "An adaptable people who choose their own paths."),
                new CButton(new I_Race(1,Color.WHITE), "Elf", "A graceful race whose ties to magic run deep."),
                new CButton(new I_Race(2,Color.WHITE), "Dwarf", "An industrious race with a bold demeanor."),
                new CButton(new I_Race(3,Color.WHITE), "Halfling", "These small folk tend to avoid the dangers\nof the outside world."),
            };
            Button[] classButtons = new Button[]
            {
                new CButton(new I_Class(0,Color.WHITE), "Fighter", "One who fights with skill, strength and skin alone."),
                new CButton(new I_Class(1,Color.WHITE), "Wizard", "A student of magic whose powers know no bounds."),
                new CButton(new I_Class(2,Color.WHITE), "Cleric", "A warrior of the faith who calls upon their god to \nheal their friends and smite their foes."),
                new CButton(new I_Class(3,Color.WHITE), "Rogue", "A clever and cunning sort, relying upon cheap tricks\nto gain the upper hand."),
            };
            Class[] classes = new Class[4]
            {
                new Fighter(),
                new Wizard(),
                new Cleric(),
                new Rogue(),
            };
            int skinColor = 0;
            string skinString = "";
            Race[,] races = new Race[4, 2]
            {
                {new Human_m(0), new Human_f(0) },
                {new Elf_m(0), new Elf_f(0) },
                {new Dwarf_m(0), new Dwarf_f(0) },
                {new Human_m(0), new Human_f(0) },
            };
            Button presetButton = new CButton(null, "Use Presets", "Use a pre-made party.");
            bool gender = false;
            string genderStr = "";
            Button skinButton = new CButton(null, $"Skin: {skinString}", "Changes skin color.\nPurely cosmetic.");
            Button genderButton = new CButton(null, $"Gender: {genderStr}", "Changes gender presentation.\nPurely cosmetic.");
            int currentChar = 0;
            //The following are based on a raylib text input example
            int maxChars = 12;
            char[] name = new char[maxChars];
            int letterCount = 0;
            Rectangle nameBox = new Rectangle(midWidth - 64, midHeight, 128, 48);
            bool selectingNameBox = false;
            bool nameEntry = false;
            int blinkCounter = 0;
            Button confirmButton = new CButton(new Icon(), "Confirm", "Enter the name you have typed.");
            Button cancelButton = new CButton(new Icon(), "Cancel", "Continue onwards.");
            Button closeButton = new CButton(new Icon(), "End Game", "Close the game.");
            //market crap=====================================================
            List<Item> randItems = new List<Item>()
            {

            };
            List<Item> randWep = new List<Item>()
            {

            };
            //battle crap=====================================================
            int[] initRolls = new int[4];
            int[] initOrder = new int[4];
            Button[] encButtons = new Button[]
            {
                new B_Attack(),
                new B_Spell(),
                new B_Item(),
                new B_Flee(),
            };
            SkillButton[] splButtons = new SkillButton[8]
            {
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
                new SkillButton(new Skill()),
            };
            ItemButton[] itmButtons = new ItemButton[8]
            {
                new ItemButton(new Item()),
                new ItemButton(new Item()),
                new ItemButton(new Item()),
                new ItemButton(new Item()),
                new ItemButton(new Item()),
                new ItemButton(new Item()),
                new ItemButton(new Item()),
                new ItemButton(new Item()),
            };
            int[] buttonPlaces = new int[]
            {
                160,
                320,
                480,
                640,
            };
            Vector2[] skillItemPos = new Vector2[]
            {
                new Vector2(midWidth - 240, screenHeight - 146),
                new Vector2(midWidth - 80, screenHeight - 146),
                new Vector2(midWidth + 80, screenHeight - 146),
                new Vector2(midWidth + 240, screenHeight - 146),
                new Vector2(midWidth - 240, screenHeight - 66),
                new Vector2(midWidth - 80, screenHeight - 66),
                new Vector2(midWidth + 80, screenHeight - 66),
                new Vector2(midWidth + 240, screenHeight - 66),
            };
            Vector2[] heroPos = new Vector2[4]
            {
                new Vector2((screenWidth / 2) - 48, 256),
                new Vector2((screenWidth / 2) - 16, 256),
                new Vector2((screenWidth / 2) + 16, 256),
                new Vector2((screenWidth / 2) + 48, 256)
            };
            Vector2[] monsterPos = new Vector2[4]
            {
                new Vector2((screenWidth / 2) - 72, 160),
                new Vector2((screenWidth / 2) - 24, 160),
                new Vector2((screenWidth / 2) + 24, 160),
                new Vector2((screenWidth / 2) + 72, 160)
            };
            Vector2[] buyPos = new Vector2[4]
            {
                new Vector2((screenWidth / 2) - 72, 200),
                new Vector2((screenWidth / 2) - 24, 200),
                new Vector2((screenWidth / 2) + 24, 200),
                new Vector2((screenWidth / 2) + 72, 200)
            };
            Monster[] monstersLv0 = new Monster[]
            {
                new Monster(),
                new Monster(),
                new Goblin(),
                new Kobold(),
                new Goblin(),
                new Kobold(),
            };
            Monster[] monstersLv1 = new Monster[]
            {
                new Monster(),
                new Monster(),
                new Goblin(),
                new Kobold(),
                new Goblin(),
                new Kobold(),
                new Orc(),
                new Drow(),
            };
            Monster[] monstersLv2 = new Monster[]
            {
                new Monster(),
                new Monster(),
                new Goblin(),
                new Kobold(),
                new Orc(),
                new Drow(),
                new Zombie(),
                new Bones(),
            };
            Monster[] monstersLv3 = new Monster[]
            {
                new Monster(),
                new Orc(),
                new Goblin(),
                new Kobold(),
                new Hobgoblin_m(),
                new Hobgoblin_f(),
                new Zombie(),
                new Bones(),
                new Drow(),
                new Gnoll(),
                new Wolf(),
                new Bear(),
                new Boar(),
            };
            Monster[] monstersLv4 = new Monster[]
            {
                new Orc(),
                new Goblin(),
                new Kobold(),
                new Hobgoblin_m(),
                new Hobgoblin_f(),
                new Zombie(),
                new Bones(),
                new Drow(),
                new Gnoll(),
                new Wolf(),
                new Bear(),
                new Boar(),
                new Ghost(),
                new Dracula(),
                new Mummy(),
            };
            List<Monster[]> scaledEncounters = new List<Monster[]>
            {
                monstersLv0,
                monstersLv0,
                monstersLv1,
                monstersLv1,
                monstersLv2,
                monstersLv2,
                monstersLv3,
                monstersLv3,
                monstersLv4,
            };
            List<Item> randomItems = new List<Item>
            {
                new Potion1(),
                new Potion1(),
                new Potion2(),
                new ThrowKnife(),
            };
            List<Weapon> randomWeps = new List<Weapon>
            {
                new Longsword(),
                new Greatsword(),
                new Handaxe(),
                new Battleaxe(),
                new Greataxe(),
            };
            int[] expLevels = new int[]
            {
                0,
                300,
                900,
                2700,
                6500,
                14000,
                23000,
                34000,
                48000,
                64000,
                85000,
            };
            Player[] party = new Player[4]
            {
                new Premade1(),
                new Premade2(),
                new Premade3(),
                new Premade4()
            };
            Monster[] monsters = new Monster[4];
            
            //other init stuff
            for (int m = 0; m < monstersLv1.Length; m++)
            {
                monsterList.Add(monstersLv1[m]);
            }
            for (int h = 0; h < party.Length; h++)
            {
                party[h].StatInit();
            }
            NewEncounter(monsters, monsterList, monsterPos);
            GameText.Clear();
            GameText.SpitOut("Create your party.");
            Console.WriteLine("Finished initialization successfully");
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                if (closeButton.clicked)
                {
                    break;
                }
                //CHAR CUSTOM
                if (starting)
                {
                    if (currentChar < party.Length)
                    {

                        if (creating == 0)
                        {
                            if (presetButton.clicked)
                            {
                                PresetParty(party);
                                foreach (Player h in party) { h.StatInit(); }
                                starting = false;
                                fightReady = true;
                            }
                            switch (skinColor)
                            {
                                case 0:
                                    skinString = "Light";
                                    races = new Race[4, 2]
                                    {
                                        {new Human_m(0), new Human_f(0) },
                                        {new Elf_m(0), new Elf_f(0) },
                                        {new Dwarf_m(0), new Dwarf_f(0) },
                                        {new Human_m(0), new Human_f(0) },
                                    };
                                    break;
                                case 1:
                                    skinString = "Tan";
                                    races = new Race[4, 2]
                                    {
                                        {new Human_m(1), new Human_f(1) },
                                        {new Elf_m(1), new Elf_f(1) },
                                        {new Dwarf_m(1), new Dwarf_f(1) },
                                        {new Human_m(1), new Human_f(1) },
                                    };
                                    break;
                                case 2:
                                    skinString = "Dark";
                                    races = new Race[4, 2]
                                    {
                                        {new Human_m(2), new Human_f(2) },
                                        {new Elf_m(2), new Elf_f(0) },
                                        {new Dwarf_m(2), new Dwarf_f(2) },
                                        {new Human_m(2), new Human_f(2) },
                                    };
                                    break;
                            }
                            switch (gender)
                            {
                                case false:
                                    genderStr = "M";
                                    break;
                                case true:
                                    genderStr = "F";
                                    break;
                            }
                            if (skinButton.clicked)
                            {
                                if (skinColor == 2) skinColor = 0;
                                else skinColor++;
                            }
                            if (genderButton.clicked)
                            {
                                gender = !gender;
                            }
                            for (int but = 0; but < raceButtons.Length; but++)
                            {
                                if (raceButtons[but].clicked)
                                {
                                    party[currentChar] = new Player
                                    {
                                        pcRace = races[but, Convert.ToInt32(gender)]
                                    };
                                    GameText.SpitOut($"You have chosen the race of {raceButtons[but].text}.");
                                    GameText.SpitOut($"Which class will this character be?");
                                    creating++;
                                }
                            }
                        }
                        if (creating == 1)
                        {
                            for (int cla = 0; cla < classButtons.Length; cla++)
                            {
                                if (classButtons[cla].clicked)
                                {
                                    party[currentChar].pcClass = classes[cla];
                                    GameText.SpitOut($"You have chosen the class of {classButtons[cla].text}.");
                                    GameText.SpitOut($"What will this hero's name be?");
                                    nameEntry = true;
                                    letterCount = 0;
                                    creating++;
                                    classButtons[cla].clicked = false;
                                }
                            }
                        }
                        if (creating == 2)
                        {
                            int key = rl.GetKeyPressed();

                            // NOTE: Only allow keys in range [32..125]
                            if ((key >= 32) && (key <= 125) && (letterCount < maxChars))
                            {
                                name[letterCount] = (char)key;
                                letterCount++;
                            }

                            if (rl.IsKeyPressed(KeyboardKey.KEY_BACKSPACE))
                            {
                                letterCount--;
                                if (letterCount < 0) letterCount = 0;

                                name[letterCount] = '\0';
                            }
                            if (rl.IsKeyPressed(KeyboardKey.KEY_ENTER) || confirmButton.clicked)
                            {
                                string butt = new string(name);
                                party[currentChar].name = butt.Trim(blank);
                                creating++;
                                nameEntry = false;
                                name = new char[maxChars];
                                confirmButton.clicked = false;
                            }
                            blinkCounter++;
                        }
                        if (creating == 3)
                        {
                            if (currentChar < party.Length)
                            {
                                GameText.SpitOut($"You have created {party[currentChar].name}.");
                                GameText.SpitOut("Who is the next hero?");
                                party[currentChar].StatInit();
                                skinColor = 0;
                                gender = false;
                                currentChar++;
                                if (currentChar < party.Length) creating = 0;
                                else
                                {
                                    GameText.SpitOut($"Your party is now ready for an adventure.");
                                    starting = false;
                                    fightReady = true;
                                }
                            }
                            else
                            {
                                GameText.SpitOut($"Your party is now ready for an adventure.");
                                starting = false;
                                fightReady = true;
                            }
                        }
                    }
                }
                int clampLvl = Math.Clamp(partyLvl, 0, expLevels.Length-1);
                if (partyXP >= (expLevels[clampLvl + 1] - expLevels[clampLvl]))
                {
                    //int tempXP = (expLevels[clampLvl]) - partyXP;
                    partyXP = 0;
                    partyLvl++;
                    //partyXP += tempXP;
                    GameText.SpitOut($"The party leveled up!");
                    foreach (Player p in party) { p.level = partyLvl; p.LevUp(); p.StatUpd(); }
                }


                //MARKET PHAAAAAAAAAAAAAAAAAASE

                //RESETS TO NEW DAY for battle
                if (fightReady)
                {
                    foreach (Player p in party)
                    {
                        p.StatUpd();
                        if (day == 0)
                        {
                            //p.inventory.Add(new Potion1());
                        }
                    }
                    initRolls = new int[4];
                    initOrder = new int[4];
                    int[] initNorm = new int[4] { 0, 1, 2, 3 };
                    battleOrder.Clear();
                    for (int h = 0; h < 4; h++)
                    {
                        party[h].StatUpd();
                        initOrder[h] = h;
                        initRolls[h] = Dice.d20(1) + party[h].scoreMod(1);
                        Console.WriteLine($"{party[h].name} (party mem #{initOrder[h]}) rolled {initRolls[h]} for initiative!");
                    }
                    Array.Sort(initRolls, initOrder, revComp);
                    foreach (int buh in initOrder) { battleOrder.Add(initNorm[buh]); }
                    day++;
                    fights = 0;
                    fightReady = false;
                    inBattle = true;
                    monsterList.Clear();
                    Monster[] spawnEm = scaledEncounters[Math.Clamp(partyLvl, 0, scaledEncounters.Count - 1)];
                    foreach (Monster mo in spawnEm) { monsterList.Add(mo); }
                    NewEncounter(monsters, monsterList, monsterPos);
                    rTurn = battleOrder[turn];
                }
                if (fights >= maxFights)
                {
                    inBattle = false;
                    fightReady = true;
                }

                //END OF BATTLE
                if (!inBattle)
                {
                    if (looting)
                    {
                        if (itemOrWep) //if the drop is a weapon
                        {
                            for (int h = 0; h < party.Length; h++)
                            {
                                if (party[h].selected && rl.IsMouseButtonPressed(0))
                                {
                                    GameText.SpitOut($"{party[h].name} gets the {lootWep.name}");
                                    party[h].weapon = lootWep;
                                    DrawFX(new Miss(), heroPos[h]);
                                    inBattle = true;
                                    choosing = true;
                                }
                            }
                        }
                        else //if the drop is an item
                        {
                            for (int h = 0; h < party.Length; h++)
                            {
                                if (party[h].selected && rl.IsMouseButtonPressed(0) && party[h].inventory.Count < 8)
                                {
                                    GameText.SpitOut($"{party[h].name} gets the {lootItem.name}");
                                    DrawFX(new Miss(), heroPos[h]);
                                    inBattle = true;
                                    choosing = true;
                                }
                                else if (party[h].selected && rl.IsMouseButtonPressed(0))
                                {
                                    GameText.SpitOut($"{party[h].name}'s inventory is full.");
                                }
                            }
                        }
                        if (cancelButton.clicked)
                        {
                            inBattle = true;
                            choosing = true;
                            cancelButton.clicked = false;
                        }
                    }
                }

                //BATTLE PHASE
                
                Dice.NewSeed();
                if (skill == null) { multTarg = 0; }
                if (inBattle)
                {
                    foreach (Player p in party) { if (p.hitPoints < 0) p.hitPoints = 0; }
                    if (party.All(h => h.hitPoints <= 0))
                    {
                        gameOver = true;
                        choosing = false;
                        choice = false;
                        splChoose = false;
                        itmChoose = false;
                    }

                    if (choosing && !currentFX.active) //WHAT WILL [CHARACTER] DO?
                    {
                        
                        if (Array.TrueForAll(monsters, element => element.hitPoints <= 0))
                        {
                            if (looting)
                            {
                                fights++;
                                NewEncounter(monsters, monsterList, monsterPos);
                                looting = false;
                            }
                            else
                            {
                                inBattle = false;
                                itemOrWep = (rng.Next(2) > 0) ? true : false;
                                lootItem = randomItems[rng.Next(randomItems.Count)];
                                lootWep = randomWeps[rng.Next(randomWeps.Count)];
                                string dropName = (itemOrWep) ? lootWep.name : lootItem.name;
                                GameText.SpitOut($"The monsters dropped a {dropName}. Who will pick it up?");
                                looting = true;
                            }
                        }
                        if (encButtons[0].clicked) { Act_ATK(party); }
                        if (encButtons[1].clicked)
                        {
                            choosing = false;
                            splChoose = true;
                            for (int s = 0; s < party[rTurn].splList.Count; s++)
                            {
                                Skill sp = party[rTurn].splList[s];
                                splButtons[s] = new SkillButton(sp);
                            }
                        }
                        if (encButtons[2].clicked)
                        {
                            choosing = false;
                            itmChoose = true;
                            for (int s = 0; s < itmButtons.Length; s++)
                            {
                                itmButtons[s] = new ItemButton(new Item());
                            }
                            for (int s = 0; s < party[rTurn].inventory.Count; s++)
                            {
                                Item it = party[rTurn].inventory[s];
                                itmButtons[s] = new ItemButton(it);
                            }
                        }
                        if (encButtons[3].clicked) { inBattle = false; fightReady = true; encButtons[3].clicked = false; }
                        if (rl.IsKeyPressed(KeyboardKey.KEY_ONE))
                        {
                            monsterList.Clear();
                            Monster[] spawnEm = scaledEncounters[Math.Clamp(partyLvl, 0, scaledEncounters.Count - 1)];
                            foreach (Monster mo in spawnEm) { monsterList.Add(mo); }
                            NewEncounter(monsters, monsterList, monsterPos);
                        }
                        if (rl.IsKeyPressed(KeyboardKey.KEY_TWO))
                        {
                            partyXP = expLevels[partyLvl + 1];
                        }
                        if (rl.IsKeyPressed(KeyboardKey.KEY_THREE))
                        {
                            foreach (Monster en in monsters)
                            {
                                en.hitPoints = 0;
                            }
                        }
                        if (rl.IsKeyPressed(KeyboardKey.KEY_FOUR))
                        {
                            foreach (Player he in party)
                            {
                                he.hitPoints = 0;
                            }
                        }
                        for (int h = 0; h < monsters.Length; h++) //CHECK TO SEE IF MONSTER IS DEAD, GIVE XP+GOLD & SET TO BLANK MONSTER IF SO
                        {
                            if (monsters[h].hitPoints <= 0)
                            {
                                gold += monsters[h].killGold;
                                partyXP += monsters[h].killXP;
                                //battleOrderM.Remove(h);
                                monsters[h] = new Monster();
                            }
                                
                        }
                    }
                    else if (splReady && !currentFX.active) //APPLYING SPELLS TO ENEMIES/HEROES
                    {
                        if (targets.Count > 0 && !skill.party)
                        {
                            SkillUse(party[rTurn], monsters[targets.First()], monsterPos[targets.First()]);
                            targets.Remove(targets.First());
                        }
                        else if (targets.Count > 0)
                        {
                            SkillHeal(party[rTurn], party[targets.First()], heroPos[targets.First()]);
                            targets.Remove(targets.First());
                        }
                        else
                        {
                            splReady = false;
                            monsterAtk = true;
                        }
                    }
                    if (monsterAtk && !currentFX.active)
                    {
                        int which = rng.Next(battleOrder.Count);
                        MonsterAttack(monsters[rTurnM], party[battleOrder[which]],heroPos[battleOrder[which]], battleOrderM);
                        AdvanceTurn(battleOrder, battleOrderM, party, monsters);
                        if (Array.TrueForAll(monsters, element => element.hitPoints <= 0)) GameText.SpitOut(GameText.battleAction(party[rTurn].name));
                        monsterAtk = false;
                        choosing = true;
                    }
                    if (splChoose && !currentFX.active) //CHOOSE SPELLS
                    {
                        if (xOut.clicked) { splChoose = false; choosing = true; xOut.clicked = false; }
                        for (int s = 0; s < party[rTurn].splList.Count; s++)
                        {
                            Skill sp = party[rTurn].splList[s];
                            if ((splButtons[s].fClicked && sp.UsesDisp() > 0) || (splButtons[s].fClicked && sp.inf))
                            {
                                party[rTurn].splList[s].Use();
                                Act_SPL(party, party[rTurn].splList[s]);
                                splChoose = false;
                            }
                        }
                    }
                    if (itmChoose && !currentFX.active) //CHOOSE ITEMS
                    {
                        if (xOut.clicked) { itmChoose = false; choosing = true; xOut.clicked = false; }
                        for (int s = 0; s < party[rTurn].inventory.Count; s++)
                        {
                            if (itmButtons[s].fClicked)
                            {
                                Act_ITM(party, party[rTurn].inventory[s]);
                                itmChoose = false;
                            }
                        }
                    }
                    if (choice && !currentFX.active)
                    {

                        //choosing = false;
                        for (int h = 0; h < monsters.Length; h++)
                        {
                            if (monsters[h].selected && rl.IsMouseButtonPressed(0))
                            {
                                if (item == null)
                                {
                                    if (skill == null)
                                    {
                                        Attack(party[rTurn], monsters[h], monsterPos[h]);
                                        //AdvanceTurn(battleOrder, battleOrderM);
                                        monsterAtk = true;
                                        choice = false;
                                    }
                                    else if (!skill.party)
                                    {
                                        if (targets.Count < (skill.numTimes))
                                        {
                                            targets.Add(h);
                                            if ((skill.numTimes - targets.Count) > 1) { GameText.SpitOut("Choose " + (skill.numTimes - targets.Count) + " more targets."); }
                                            else { GameText.SpitOut("Choose " + (skill.numTimes - targets.Count) + " more target."); }
                                        }
                                        else
                                        {
                                            splReady = true;
                                            choice = false;
                                        }
                                    }
                                }
                                else if (!item.party)
                                {
                                    ItemAtk(party[rTurn], monsters[h], monsterPos[h]);
                                    choice = false;
                                    monsterAtk = true;
                                }
                                
                            }
                        }
                        for (int h = 0; h < party.Length; h++)
                        {
                            if (party[h].selected && rl.IsMouseButtonPressed(0) && skill != null && skill.party)
                            {
                                if (targets.Count < (skill.numTimes))
                                {
                                    targets.Add(h);
                                    if ((skill.numTimes - targets.Count) > 1) { GameText.SpitOut("Choose " + (skill.numTimes - targets.Count) + " more targets."); }
                                    else { GameText.SpitOut("Choose " + (skill.numTimes - targets.Count) + " more target."); }
                                }
                                else
                                {
                                    splReady = true;
                                    choice = false;
                                }
                            }
                            if (party[h].selected && rl.IsMouseButtonPressed(0) && item != null && item.party)
                            {
                                ItemHeal(party[rTurn], party[h], heroPos[h]);
                                choice = false;
                                monsterAtk = true;
                            }
                        }
                    }
                }
                

                //MEASURE WHERE TEXT SHOULD GO
                GameText.textLoc1 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 1f).x / 2), 64);
                GameText.textLoc2 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 1f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y);
                GameText.textLoc3 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest3, textScl, 1f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 0f).y);
                GameText.textLoc4 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest4, textScl, 1f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest3, textScl, 0f).y);
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.DARKGRAY);
                if (gameOver)
                {
                    closeButton.Draw(new Vector2(midWidth, screenHeight - 64));
                    string dieText = $"Your party has fallen.";
                    Vector2 dieTextM = rl.MeasureTextEx(UI.bigFont, dieText, UI.bigFont.baseSize, 1f);
                    rl.DrawTextEx(UI.bigFont, dieText, new Vector2(midWidth - (dieTextM.x / 2), screenHeight - 160),UI.bigFont.baseSize,1f,Color.BLACK);
                }
                rl.DrawTextureNPatch(UI.uiTan, UI.uiText, mainText, Vector2.Zero, 0f, Color.WHITE);
                rl.DrawTextEx(curFont, GameText.textLatest4, GameText.textLoc4, textScl, 1, rl.Fade(Color.BLACK, 0.25f));
                rl.DrawTextEx(curFont, GameText.textLatest3, GameText.textLoc3, textScl, 1, rl.Fade(Color.BLACK, 0.5f));
                rl.DrawTextEx(curFont, GameText.textLatest2, GameText.textLoc2, textScl, 1, rl.Fade(Color.BLACK, 0.75f));
                rl.DrawTextEx(curFont, GameText.textLatest1, GameText.textLoc1, textScl, 1, Color.BLACK);

                rl.DrawTextEx(UI.bigFont, $"Day: {day}", new Vector2(0,0),UI.bigFont.baseSize,1f,Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"Battles: {fights}/{maxFights}", new Vector2(0,24),UI.bigFont.baseSize,1f,Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"EXP: {partyXP}", new Vector2(0,48),UI.bigFont.baseSize,1f,Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"Level: {partyLvl+1}", new Vector2(0, 72), UI.bigFont.baseSize, 1f, Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"Gold: {gold}", new Vector2(0,96),UI.bigFont.baseSize,1f,Color.WHITE);

                //draw buttons
                if (choosing && inBattle)
                {
                    for (int b = encButtons.Length; b > 0; b--)
                    {
                        encButtons[b-1].Draw(new Vector2(buttonPlaces[b-1], 384));
                    }
                    encButtons[0].i = party[rTurn].weapon.icon;
                    encButtons[0].flavor = GameText.WeaponShow(party[rTurn]);
                }
                if (splChoose)
                {
                    xOut.Draw(new Vector2(midWidth, screenHeight - 32));
                    for (int s = 0; s < skillItemPos.Length; s++)
                    {
                        splButtons[s].Draw(skillItemPos[s]);
                    }
                }
                if (itmChoose)
                {
                    xOut.Draw(new Vector2(midWidth, screenHeight - 32));
                    if (xOut.clicked) { itmChoose = false; choosing = true; }
                    for (int s = 0; s < skillItemPos.Length; s++)
                    {
                        itmButtons[s].Draw(skillItemPos[s]);
                    }
                }

                //draw players (and monsters)
                if (!starting)
                {
                    for (int h = 3; h >= 0; h--)
                    {
                        party[h].Draw(hero, heroPos[h]);
                        if (inBattle) monsters[h].Draw(monsterPos[h]);
                    }
                }
                if (looting)
                {
                    if (itemOrWep) { rl.DrawTextureRec(Sprites.tiles, lootWep.icon.spr, new Vector2(midWidth - (lootWep.icon.spr.width / 2), screenHeight - 240), lootWep.icon.color); }
                    else { rl.DrawTextureRec(Sprites.tiles, lootItem.icon.spr, new Vector2(midWidth - (lootItem.icon.spr.width / 2), screenHeight - 240), lootItem.icon.color); }
                    cancelButton.Draw(new Vector2(midWidth, screenHeight - 64));
                }
                if (inBattle)
                {
                    if (battleOrder.Count > 0) rl.DrawTextureRec(Sprites.tiles, Sprites.i_hand, heroPos[rTurn], Color.WHITE);
                    if (battleOrderM.Count > 0) rl.DrawTextureRec(Sprites.tiles, Sprites.i_skull, monsterPos[battleOrderM[turnM]], Color.WHITE);
                }
                if (starting)
                {
                    if (creating == 0)
                    {
                        skinButton.text = $"Skin: {skinString}";
                        genderButton.text = $"Gender: {genderStr}";
                        presetButton.Draw(new Vector2(midWidth, screenHeight - 48));
                        skinButton.Draw(new Vector2(midWidth + 192, screenHeight - 48));
                        genderButton.Draw(new Vector2(midWidth - 192, screenHeight - 48));
                        for (int but = raceButtons.Length - 1; but >= 0; but--)
                        {
                            raceButtons[but].Draw(new Vector2(midWidth, midHeight + (48 * (but + 1 - (raceButtons.Length / 2)))));
                        }
                    }
                    if (creating == 1)
                    {
                        for (int but = classButtons.Length - 1; but >= 0; but--)
                        {
                            classButtons[but].Draw(new Vector2(midWidth, midHeight + (48 * (but + 1 - (classButtons.Length / 2)))));
                        }
                    }
                }
                if (nameEntry)
                {
                    rl.DrawTextureNPatch(UI.uiWhite2, UI.uiText, nameBox, Vector2.Zero, 0f, Color.WHITE);
                    if (((blinkCounter / 20) % 2) == 0)
                    {
                        rl.DrawTextEx(UI.bigFont, new string(name) + "_", new Vector2(nameBox.x + 4, nameBox.y + (nameBox.height / 2) - (rl.MeasureTextEx(UI.bigFont, new string(name), UI.bigFont.baseSize, 1f).y / 2)), UI.bigFont.baseSize, 1f, Color.BLACK);
                    }
                    else
                    {
                        rl.DrawTextEx(UI.bigFont, new string(name), new Vector2(nameBox.x + 4, nameBox.y + (nameBox.height / 2) - (rl.MeasureTextEx(UI.bigFont, new string(name), UI.bigFont.baseSize, 1f).y / 2)), UI.bigFont.baseSize, 1f, Color.BLACK);
                    }
                    confirmButton.Draw(new Vector2(midWidth, screenHeight - 64));
                }
                //draw whose turn it is
                //UI.Tile(0, 25, heroPos[turn]);
                

                
                if (rl.CheckCollisionPointRec(rl.GetMousePosition(), new Rectangle(0, 0, screenWidth, screenHeight)))
                {
                    rl.HideCursor();
                }
                else
                {
                    rl.ShowCursor();
                }
                if (Array.Exists(monsters, element => element.selected) || Array.Exists(party, element => element.selected))
                {
                    UI.Tile(9, 25,rl.GetMousePosition());
                }
                else
                {
                    UI.Tile(1, 32, rl.GetMousePosition());
                }
                if (currentFX.active) currentFX.Draw();
                //hover.Draw();
                //hover.active = false;
                
                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            GameText.txtLog.Close();
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }

        //VOIDS-------------------------------------------------------------------------------------
        
        static void Act_ATK(Player[] chars)
        {
            skill = null;
            //canAct = false;
            GameText.SpitOut("Which enemy will " + chars[rTurn].name + " target?");
            choosing = false;
            choice = true;
            
        }

        static void Act_SPL(Player[] chars, Skill spl)
        {
            skill = spl;
            item = null;
            //canAct = false;
            targets = new List<int>();
            multTarg = skill.numTimes;
            GameText.SpitOut("Who will " + chars[rTurn].name + " target?");
            choosing = false;
            choice = true;
            //for (int c = 0; c < skill.numTimes; c++) { multTarg++; }

        }
        static void Act_ITM(Player[] chars, Item itm)
        {
            skill = null;
            item = itm;
            //canAct = false;
            GameText.SpitOut("Who will " + chars[turn].name + " target?");
            choosing = false;
            choice = true;

        }

        static void Attack(Player player, Monster target, Vector2 fxPos)
        {
            Weapon wep = player.weapon;
            int scBonus = (wep.ranged) ? 2 : 0;
            int hitRoll = Dice.d20(1);
            //GameText.SpitOut("Rolled " + (hitRoll + player.scoreMod(0)));
            if ((hitRoll + player.scoreMod(0)) + 5 > target.AC || hitRoll == 20)
            {
                if (hitRoll == 20) GameText.SpitOut("Critical hit!");
                DrawFX(player.weapon.hitFX,fxPos);
                
                int dmgRoll = Dice.Die(wep.die[0], wep.die[1]) + wep.bonus + player.scoreMod(scBonus);
                //AtkTimer(player, target, dmgRoll);
                AtkOutcome(player, target, dmgRoll);
            }
            else
            {
                GameText.SpitOut(GameText.HeroMiss(player.name, target.name));
                DrawFX(new Miss(), fxPos);
            }
        }
        static void SkillUse(Player player, Monster target, Vector2 fxPos)
        {
            
            int dmgRoll = 0;
            if (!skill.wepSpl) dmgRoll = Dice.Die(skill.die[0], skill.die[1]) + skill.addDmg;
            else
            {
                Weapon wp = player.weapon;
                dmgRoll = Dice.Die(wp.die[0], wp.die[1]) + player.scoreMod(0) + Dice.Die(skill.die[0], skill.die[1]) + skill.addDmg;
            }
            DrawFX(skill.hitFX, fxPos);
            AtkOutcome(player, target, dmgRoll);
        }
        static void SkillHeal(Player player, Player target, Vector2 fxPos)
        {
            int dmgRoll = 0;
            if (skill.alwaysHit) dmgRoll = (Dice.Die(skill.die[0], skill.die[1]) * -1) - skill.addDmg;
            DrawFX(skill.hitFX, fxPos);
            HealOutcome(player, target, dmgRoll);
        }
        static void ItemAtk(Player player, Monster target, Vector2 fxPos)
        {
            int dmgRoll = Dice.Die(item.die[0], item.die[1]) + item.add;
            player.inventory.Remove(item);
            DrawFX(item.fx, fxPos);
            AtkOutcome(player, target, dmgRoll);
            item = null;
            skill = null;
        }
        static void ItemHeal(Player player, Player target, Vector2 fxPos)
        {
            int dmgRoll = (Dice.Die(item.die[0], item.die[1]) * -1) - item.add;
            player.inventory.Remove(item);
            DrawFX(item.fx, fxPos);
            HealOutcome(player, target, dmgRoll);
            item = null;
            skill = null;
        }
        static void MonsterAttack(Monster monster, Player target, Vector2 fxPos, List<int> mons)
        {
            if (monster.hitPoints <= 0)
            {
                if (turnM >= mons.Count - 1) { turnM = 0; }
                else { turnM += 1; }
            }
            else
            {
                int hitRoll = Dice.d20(1);
                //GameText.SpitOut("Rolled " + (hitRoll + player.scoreMod(0)));
                if ((hitRoll + monster.plusHit) > target.AC || hitRoll == 20)
                {
                    if (hitRoll == 20) GameText.SpitOut("Critical hit!");
                    //DrawFX(monster.hitFX);
                    int dmgRoll = monster.atkDmg;
                    DrawFX(monster.hitFX, fxPos);
                    MonsterOutcome(monster, target, dmgRoll);
                }
                else
                {
                    GameText.SpitOut(GameText.HeroMiss(monster.name, target.name));
                    DrawFX(new Miss(), fxPos);
                }
            }
        }
        static void AtkOutcome(Player player, Monster target, int dmg)
        {
            if (dmg >= target.hitPoints)
            {
                GameText.SpitOut(GameText.HeroAtk(player.name, target.name, dmg));
                GameText.SpitOut(target.name + " is slain.");
            }
            else
            {
                GameText.SpitOut(GameText.HeroAtk(player.name, target.name, dmg));
            }
            target.hitPoints -= dmg;
        }
        static void MonsterOutcome(Monster monster, Player target, int dmg)
        {
            if (dmg >= target.hitPoints)
            {
                GameText.SpitOut(GameText.HeroAtk(monster.name, target.name, dmg));
                GameText.SpitOut(target.name + " has fallen in battle.");
            }
            else
            {
                GameText.SpitOut(GameText.HeroAtk(monster.name, target.name, dmg));
            }
            target.hitPoints -= dmg;
        }
        static void HealOutcome(Player player, Player target, int dmg)
        {
            GameText.SpitOut(GameText.HeroHeal(player.name, target.name, dmg));
            target.hitPoints -= dmg;
            if (target.hitPoints > target.maxHP) { target.hitPoints = target.maxHP; }
        }
        static void DrawFX(FX fx, Vector2 position)
        {
            currentFX = fx;
            currentFX.pos = position;
            currentFX.Reset();
            currentFX.active = true;
        }
        static void NewEncounter(Monster[] enc, List<Monster> list, Vector2[] pos)
        {
            battleOrderM.Clear();
            turnM = 0;
            List<Monster> dupCheck = new List<Monster>();
            foreach(Monster mo in list)
            {
                dupCheck.Add(mo);
            }
            for (int a = 0; a < enc.Length; a++)
            {
                Monster newMon = dupCheck[rng.Next(dupCheck.Count)];
                dupCheck.Remove(newMon);
                enc[a] = newMon;
                newMon.Spawn(pos[a]);
                if (newMon.maxHP > 0)
                {
                    battleOrderM.Add(a);
                }
            }
            //turnM = Array.FindIndex(enc, mons => mons.hitPoints > 0);
        }
        static void AdvanceTurn(List<int> pl, List<int> mon, Player[] par, Monster[] mons)
        {
            for (int c = 0; c < par.Length; c++)
            {

                if (par[c].hitPoints <= 0) { pl.Remove(c); Console.WriteLine($"party mem #{c} is dead as hell boy!"); }
                else if (!pl.Contains(c))
                {
                    Console.WriteLine($"Whoopsy daisy! Player {c} is alive now!");
                    pl.Add(c);
                }
                
            }
            for (int m = 0; m < mons.Length; m++)
            {

                if (mons[m].hitPoints <= 0) { mon.Remove(m); Console.WriteLine($"monster #{m} is dead as hell boy!"); }
                else if (!mon.Contains(m))
                {
                    Console.WriteLine($"Whoopsy daisy! Monster {m} is alive now!");
                    mon.Add(m);
                }

            }
            if (turn >= pl.Count - 1) { turn = 0; }
            else { turn ++; }
            if (turnM >= mon.Count - 1) { turnM = 0; }
            else { turnM ++; }
            if (!par.All(hero => hero.hitPoints <= 0)) rTurn = pl[turn];
            if (!mons.All(monst => monst.hitPoints <= 0)) rTurnM = mon[turnM];
        }
        static void PresetParty(Player[] p)
        {
            p[0] = new Premade1();
            p[1] = new Premade2();
            p[2] = new Premade3();
            p[3] = new Premade4();
        }
    }

    public class ReverseComparer : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(Object x, Object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }
}
