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
        static int multTarg = 0;
        static List<int> targets = new List<int>();
        static bool splReady = false;
        public static FX currentFX = new FX();
        public static int timer = 0;
        public static Dice dice = new Dice();
        public static bool looping = true;
        public static int turn = 0;
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            rl.InitWindow(screenWidth, screenHeight, "Dungeons!");
            rl.SetTargetFPS(60);
            Texture2D hero = rl.LoadTexture("Resources/Sprites/roguelikeChar_transparent.png");
            bool starting = false;
            int creating = 0;
            bool inBattle = false;
            bool fightReady = true;
            IComparer revComp = new ReverseComparer();
            int day = 0;
            int gold = 400;
            int fights = 0;
            int maxFights = 6;
            int partyLvl = 0;
            int partyXP = 0;
            bool splChoose = false;
            List<Monster> monsterList = new List<Monster>();
            List<int> battleOrder = new List<int>();
            int rTurn = 0;
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
                new CButton(new I_Race(0,Color.WHITE), "Human", "A graceful race whose ties to magic run deep."),
                new CButton(new I_Race(1,Color.WHITE), "Elf", "A graceful race whose ties to magic run deep."),
                new CButton(new I_Race(2,Color.WHITE), "Dwarf", "A graceful race whose ties to magic run deep."),
                new CButton(new I_Race(3,Color.WHITE), "Halfling", "A graceful race whose ties to magic run deep."),
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
            int[] buttonPlaces = new int[]
            {
                160,
                320,
                480,
                640,
            };
            Vector2[] skillItemPos = new Vector2[]
            {
                new Vector2(midWidth - 160, screenHeight - 146),
                new Vector2(midWidth - 80, screenHeight - 146),
                new Vector2(midWidth + 80, screenHeight - 156),
                new Vector2(midWidth + 160, screenHeight - 146),
                new Vector2(midWidth - 160, screenHeight - 66),
                new Vector2(midWidth - 80, screenHeight - 66),
                new Vector2(midWidth + 80, screenHeight - 66),
                new Vector2(midWidth + 160, screenHeight - 66),
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
            Monster[] monstersLv1 = new Monster[]
            {
                new Monster(),
                new Monster(),
                new Monster(),
                new Goblin(),
                new Goblin(),
                new Goblin(),
                new Orc(),
                new Orc(),
                new Zombie(),
                new Bones(),
                new Wolf(),
            };
            Monster[] monstersLv2 = new Monster[]
            {
                new Monster(),
                new Orc(),
                new Hobgoblin_m(),
                new Hobgoblin_f(),
                new Drow(),
                new Gnoll(),
                new Wolf(),
                new Bear(),
                new Boar(),
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
            NewEncounter(monsters, monsterList, monsterPos);
            GameText.Clear();
            GameText.SpitOut("Create your first hero.");
            Console.WriteLine("Finished initialization successfully");
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------

                //CHAR CUSTOM
                if (starting)
                {
                    if (currentChar < party.Length)
                    {
                        
                        if (creating == 0)
                        {
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
                            //Console.WriteLine("Hey, are you alright? Did ya hit your head?");
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
                                    creating++;
                                    GameText.SpitOut($"You have chosen the race of {raceButtons[but].text}.");
                                    GameText.SpitOut($"Which class will this character be?");
                                }
                            }
                        }
                        if (creating == 1)
                        {
                            for (int but = 0; but < classButtons.Length; but++)
                            {
                                if (classButtons[but].clicked)
                                {
                                    party[currentChar].pcClass = classes[but];
                                    creating++;
                                    GameText.SpitOut($"You have chosen the class of {classButtons[but].text}.");
                                    GameText.SpitOut($"What will this hero's name be?");
                                    nameEntry = true;
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
                            if (rl.IsKeyPressed(KeyboardKey.KEY_ENTER))
                            {
                                party[currentChar].name = new string(name);
                                creating++;
                                nameEntry = false;
                                name = new char[maxChars];
                            }
                            blinkCounter++;
                        }
                        if (creating == 3)
                        {
                            Console.WriteLine("Is this what's causing all the trouble?");
                            if (currentChar < party.Length)
                            {
                                GameText.SpitOut($"You have created {party[currentChar].name}.Who is the next hero?");
                                party[currentChar].StatInit();
                                skinColor = 0;
                                gender = false;
                                currentChar++;
                                if (currentChar < party.Length) creating = 0;
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
                if (partyXP >= (expLevels[partyLvl + 1] - expLevels[partyLvl]))
                {
                    int tempXP = (50 * partyLvl) - partyXP;
                    partyXP = 0;
                    partyLvl++;
                    partyXP += tempXP;
                    foreach (Player p in party) { p.level = partyLvl; p.StatUpd(); }
                }


                //MARKET PHAAAAAAAAAAAAAAAAAASE

                //RESETS TO NEW DAY for battle
                if (fightReady)
                {
                    foreach (Player p in party) { p.StatInit(); }
                    initRolls = new int[4];
                    initOrder = new int[4];

                    for (int h = 0; h < 4; h++)
                    {
                        //battleOrder.RemoveAt(h);
                        party[h].StatUpd();
                        initOrder[h] = h;
                        initRolls[h] = Dice.d20(1) + party[h].scoreMod(1);
                        Console.WriteLine($"{party[h].name} (party mem #{initOrder[h]}) rolled {initRolls[h]} for initiative!");
                    }
                    Array.Sort(initRolls, initOrder, revComp);
                    foreach (int buh in initOrder) { battleOrder.Add(initRolls[buh]); }
                    day++;
                    fights = 0;
                    fightReady = false;
                    inBattle = true;
                    rTurn = battleOrder[turn];
                    NewEncounter(monsters,monsterList,monsterPos);
                }
                if (fights >= maxFights)
                {
                    fightReady = true;
                }

                //BATTLE PHASE
                
                Dice.NewSeed();
                if (skill == null) { multTarg = 0; }
                if (inBattle)
                {
                    if (choosing && !currentFX.active) //WHAT WILL [CHARACTER] DO?
                    {
                        if (Array.TrueForAll(monsters, element => element.hitPoints <= 0))
                        {
                            fights++;
                            NewEncounter(monsters, monsterList, monsterPos);
                        }
                        if (encButtons[0].clicked) { Act_ATK(party); }
                        if (encButtons[1].clicked)
                        {
                            choosing = false;
                            splChoose = true;
                            for (int s = 0; s < party[turn].splList.Count; s++)
                            {
                                Skill sp = party[turn].splList[s];
                                splButtons[s] = new SkillButton(sp);
                            }
                        }
                        if (rl.IsKeyPressed(KeyboardKey.KEY_ONE))
                        {
                            NewEncounter(monsters, monsterList, monsterPos);
                        }
                        if (rl.IsKeyPressed(KeyboardKey.KEY_TWO))
                        {
                            NewEncounter(monsters, monsterList, monsterPos);
                        }
                        for (int h = 0; h < monsters.Length; h++) //CHECK TO SEE IF MONSTER IS DEAD, GIVE XP+GOLD & SET TO BLANK MONSTER IF SO
                        {
                            if (monsters[h].hitPoints <= 0)
                            {
                                gold += monsters[h].killGold;
                                partyXP += monsters[h].killXP;
                                monsters[h] = new Monster();
                            }
                                
                        }
                    }
                    else if (splReady && !currentFX.active) //APPLYING SPELLS TO ENEMIES/HEROES
                    {
                        if (targets.Count > 0 && !skill.party)
                        {
                            SkillUse(party[turn], monsters[targets.First()], monsterPos[targets.First()]);
                            targets.Remove(targets.First());
                        }
                        else if (targets.Count > 0)
                        {
                            SkillHeal(party[turn], party[targets.First()], heroPos[targets.First()]);
                            targets.Remove(targets.First());
                        }
                        else
                        {
                            splReady = false;
                            monsterAtk = true;
                            //if (turn == party.Length - 1) { turn = 0; }
                            //else { turn += 1; }
                            //if (Array.TrueForAll(monsters, element => element.hitPoints <= 0)) GameText.SpitOut(GameText.battleAction(party[turn].name));
                            //choosing = true;
                        }
                    }
                    if (monsterAtk && !currentFX.active)
                    {
                        int which = rng.Next(party.Length);
                        MonsterAttack(monsters[turn], party[which],heroPos[which]);
                        if (turn == party.Length - 1) { turn = 0; }
                        else { turn += 1; }
                        if (Array.TrueForAll(monsters, element => element.hitPoints <= 0)) GameText.SpitOut(GameText.battleAction(party[turn].name));
                        monsterAtk = false;
                        choosing = true;
                    }
                    if (splChoose && !currentFX.active) //CHOOSE SPELLS
                    {
                        for (int s = 0; s < party[turn].splList.Count; s++)
                        {
                            Skill sp = party[turn].splList[s];
                            if ((splButtons[s].fClicked && sp.UsesDisp() > 0) || (splButtons[s].fClicked && sp.inf))
                            {
                                party[turn].splList[s].Use();
                                Act_SPL(party,party[turn].splList[s]);
                                splChoose = false;
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
                                if (skill == null)
                                {
                                    Attack(party[turn], monsters[h], monsterPos[h]);
                                    if (turn == party.Length - 1) { turn = 0; }
                                    else { turn += 1; }
                                    GameText.SpitOut(GameText.battleAction(party[turn].name));
                                    choosing = true;
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
                
                rl.DrawTextureNPatch(UI.uiTan, UI.uiText, mainText, Vector2.Zero, 0f, Color.WHITE);
                rl.DrawTextEx(curFont, GameText.textLatest4, GameText.textLoc4, textScl, 1, rl.Fade(Color.BLACK, 0.25f));
                rl.DrawTextEx(curFont, GameText.textLatest3, GameText.textLoc3, textScl, 1, rl.Fade(Color.BLACK, 0.5f));
                rl.DrawTextEx(curFont, GameText.textLatest2, GameText.textLoc2, textScl, 1, rl.Fade(Color.BLACK, 0.75f));
                rl.DrawTextEx(curFont, GameText.textLatest1, GameText.textLoc1, textScl, 1, Color.BLACK);

                rl.DrawTextEx(UI.bigFont, $"Day: {day+1}", new Vector2(0,0),UI.bigFont.baseSize,1f,Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"Battles: {fights}/{maxFights}", new Vector2(0,24),UI.bigFont.baseSize,1f,Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"EXP: {partyXP}", new Vector2(0,48),UI.bigFont.baseSize,1f,Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"Level: {partyLvl+1}", new Vector2(0, 72), UI.bigFont.baseSize, 1f, Color.WHITE);
                rl.DrawTextEx(UI.bigFont, $"Gold: {gold}", new Vector2(0,96),UI.bigFont.baseSize,1f,Color.WHITE);

                //draw players (and monsters)
                if (!starting)
                {
                    for (int h = 3; h >= 0; h--)
                    {
                        party[h].Draw(hero, heroPos[h]);
                        if (inBattle) monsters[h].Draw(monsterPos[h]);
                    }
                }
                if (starting)
                {
                    if (creating == 0)
                    {
                        skinButton.text = $"Skin: {skinString}";
                        genderButton.text = $"Gender: {genderStr}";
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
                }
                //draw whose turn it is
                //UI.Tile(0, 25, heroPos[turn]);
                rl.DrawTextureRec(Sprites.tiles, Sprites.i_hand, heroPos[turn], Color.WHITE);

                //draw buttons
                if (choosing && inBattle)
                {
                    for (int b = 0; b < encButtons.Length; b++)
                    {
                        encButtons[b].Draw(new Vector2(buttonPlaces[b], 384));
                    }
                    encButtons[0].i = party[turn].weapon.icon;
                }
                if (splChoose)
                {
                    xOut.Draw(new Vector2(midWidth, screenHeight - 32));
                    if (xOut.clicked) { splChoose = false; choosing = true; }
                    for (int s = 0; s < party[turn].splList.Count; s++)
                    {
                        splButtons[s].Draw(skillItemPos[s]);
                    }
                }
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
            GameText.SpitOut("Which enemy will " + chars[turn].name + " target?");
            choosing = false;
            choice = true;
            
        }

        static void Act_SPL(Player[] chars, Skill spl)
        {
            skill = spl;
            //canAct = false;
            targets = new List<int>();
            multTarg = skill.numTimes;
            GameText.SpitOut("Who will " + chars[turn].name + " target?");
            choosing = false;
            choice = true;
            //for (int c = 0; c < skill.numTimes; c++) { multTarg++; }

        }
        static void Act_ITM(Player[] chars, Item itm)
        {
            skill = null;
            //canAct = false;
            GameText.SpitOut("Who will " + chars[turn].name + " target?");
            choosing = false;
            choice = true;

        }

        static void Attack(Player player, Monster target, Vector2 fxPos)
        {
            int hitRoll = Dice.d20(1);
            //GameText.SpitOut("Rolled " + (hitRoll + player.scoreMod(0)));
            if ((hitRoll + player.scoreMod(0)) + 5 > target.AC || hitRoll == 20)
            {
                if (hitRoll == 20) GameText.SpitOut("Critical hit!");
                DrawFX(player.weapon.hitFX,fxPos);
                int dmgRoll = player.pcClass.wepDie + player.wepLevel;
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
            if (skill.alwaysHit) dmgRoll = skill.dmg + skill.addDmg;
            DrawFX(skill.hitFX, fxPos);
            AtkOutcome(player, target, dmgRoll);
        }
        static void SkillHeal(Player player, Player target, Vector2 fxPos)
        {
            int dmgRoll = 0;
            if (skill.alwaysHit) dmgRoll = (skill.dmg * -1) - skill.addDmg;
            DrawFX(skill.hitFX, fxPos);
            HealOutcome(player, target, dmgRoll);
        }
        static void MonsterAttack(Monster monster, Player target, Vector2 fxPos)
        {
            if (monster.hitPoints <= 0)
            {
                GameText.SpitOut($"{monster.name} is dead, and cannot take a turn.");
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
            for (int a = 0; a < enc.Length; a++)
            {
                Monster newMon = list[rng.Next(0, list.Count)];
                for (int b = 0; b < enc.Length;)
                {
                    while (newMon == enc[b])
                    {
                        newMon = list[rng.Next(0, list.Count)];
                    }
                    b++;
                }
                enc[a] = newMon;
                newMon.Spawn(pos[a]);
            }
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
