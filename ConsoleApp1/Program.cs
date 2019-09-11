using System;
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
        static bool canAct = true;
        static bool choosing = true;
        static bool choice = false;
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
            Rectangle testRec = new Rectangle(0, screenHeight-96, 32, 32);
            Texture2D hero = rl.LoadTexture("Resources/Sprites/roguelikeChar_transparent.png");
            bool market = false;
            int day = 0;
            int gold = 0;
            int fights = 0;
            int maxFights = 0;
            Vector2 hero1Pos = new Vector2((screenWidth / 2) - 48, 300);
            Vector2 hero2Pos = new Vector2((screenWidth / 2) - 16, 300);
            Vector2 hero3Pos = new Vector2((screenWidth / 2) + 16, 300);
            Vector2 hero4Pos = new Vector2((screenWidth / 2) + 48, 300);
            Monster enemy = new Monster();
            Vector2 enemyPos = new Vector2((screenWidth / 2) - 16, 200);
            Vector2 enemyHP = new Vector2();
            Rectangle mainText = new Rectangle(160, 0, 480, 96);
            Vector2 textPlace = new Vector2((screenWidth / 2), 48);
            Font curFont = UI.bigFont;
            int textScl = curFont.baseSize;
            Button[] encButtons = new Button[]
            {
                new B_Attack(),
                new B_Spell(),
                new B_Item(),
                new B_Flee(),
            };
            int[] buttonPlaces = new int[]
            {
                160,
                320,
                480,
                640,
            };
            Vector2[] heroPos = new Vector2[4]
            {
                new Vector2((screenWidth / 2) - 48, 300),
                new Vector2((screenWidth / 2) - 16, 300),
                new Vector2((screenWidth / 2) + 16, 300),
                new Vector2((screenWidth / 2) + 48, 300)
            };
            Vector2[] monsterPos = new Vector2[4]
            {
                new Vector2((screenWidth / 2) - 72, 200),
                new Vector2((screenWidth / 2) - 24, 200),
                new Vector2((screenWidth / 2) + 24, 200),
                new Vector2((screenWidth / 2) + 72, 200)
            };
            List<Monster> monsterList = new List<Monster>();
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
                new Bear(),
                new Boar(),
            };
            Monster[] monstersLv2 = new Monster[]
            {
                new Monster(),
                new Monster(),
                new Goblin(),
                new Goblin(),
                new Orc(),
                new Orc(),
                new Orc(),
                new Zombie(),
                new Bones(),
                new Hobgoblin_m(),
                new Hobgoblin_f(),
                new Wolf(),
                new Bear(),
                new Boar(),
            };
            Player[] party = new Player[4]
            {
                new Premade1(),
                new Premade2(),
                new Premade3(),
                new Premade4()
            };
            Monster[] monsters = new Monster[4];
            fights = 0;
            for (int h = 0; h < 4; h++)
            {
                party[h].StatInit();
            }
            for (int m = 0; m < monstersLv1.Length; m++)
            {
                monsterList.Add(monstersLv1[m]);
            }
            NewEncounter(monsters, monsterList, monsterPos);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                if (skill == null) { multTarg = 0; }
                if (rl.CheckCollisionPointRec(rl.GetMousePosition(), testRec))
                {
                    UI.MouseOverIcon(UI.uiTan, "Whatta hell fried chicken", UI.bigFont, new Icon_Sword());
                }
                if (choosing && !currentFX.active)
                {
                    if (Array.TrueForAll(monsters, element => element.hitPoints <= 0))
                    {
                        fights = 0;
                        NewEncounter(monsters, monsterList, monsterPos);
                    }
                    if (encButtons[0].clicked) { Act_ATK(party); }
                    if (encButtons[1].clicked) { Act_SPL(party); }
                    if (rl.IsKeyPressed(KeyboardKey.KEY_ONE))
                    {
                        NewEncounter(monsters, monsterList, monsterPos);
                    }
                    if (rl.IsKeyPressed(KeyboardKey.KEY_TWO))
                    {
                        NewEncounter(monsters, monsterList, monsterPos);
                    }
                    for (int h = 0; h < monsters.Length; h++)
                    {
                        if (monsters[h].hitPoints <= 0) monsters[h] = new Monster();
                    }
                }
                else if (splReady && !currentFX.active)
                {
                    if (targets.Count > 0)
                    {
                        SkillUse(party[turn], monsters[targets.First()], monsterPos[targets.First()]);
                        targets.Remove(targets.First());
                    }
                    else
                    {
                        splReady = false;
                        if (turn == party.Length - 1) { turn = 0; }
                        else { turn += 1; }
                        GameText.SpitOut(GameText.battleAction(party[turn].name));
                        choosing = true;
                    }
                }
                if (choice && !currentFX.active)
                {
                    
                    //choosing = false;
                    for (int h = 0; h < monsters.Length; h++)
                    {
                        if (monsters[h].selected && rl.IsMouseButtonPressed(0))
                        {
                            if(skill == null)
                            {
                                Attack(party[turn], monsters[h], monsterPos[h]);
                                if (turn == party.Length - 1) { turn = 0; }
                                else { turn += 1; }
                                GameText.SpitOut(GameText.battleAction(party[turn].name));
                                choosing = true;
                                choice = false;
                            }
                            else
                            {
                                if (targets.Count < (skill.numTimes))
                                {
                                    targets.Add(h);
                                    if ((skill.numTimes - targets.Count) > 1) { GameText.SpitOut("Choose " + (skill.numTimes - targets.Count) + " more targets."); }
                                    else { GameText.SpitOut("Choose " + (skill.numTimes - targets.Count) + " more targets."); }
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
                GameText.textLoc1 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 1f).x / 2), 64);
                GameText.textLoc2 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 1f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y);
                GameText.textLoc3 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest3, textScl, 1f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 0f).y);
                GameText.textLoc4 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest4, textScl, 1f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest3, textScl, 0f).y);
                //whereText = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, textStr, textScl, 0f).x / 2), 48);
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);
                
                rl.DrawTextureNPatch(UI.uiTan, UI.uiText, mainText, Vector2.Zero, 0f, Color.WHITE);
                rl.DrawTextEx(curFont, GameText.textLatest4, GameText.textLoc4, textScl, 1, rl.Fade(Color.BLACK, 0.25f));
                rl.DrawTextEx(curFont, GameText.textLatest3, GameText.textLoc3, textScl, 1, rl.Fade(Color.BLACK, 0.5f));
                rl.DrawTextEx(curFont, GameText.textLatest2, GameText.textLoc2, textScl, 1, rl.Fade(Color.BLACK, 0.75f));
                rl.DrawTextEx(curFont, GameText.textLatest1, GameText.textLoc1, textScl, 1, Color.BLACK);
                

                for (int h = 0; h < 4; h++)
                {
                    party[h].Draw(hero, heroPos[h]);
                    monsters[h].Draw(monsterPos[h]);
                }

                //hero1.Draw(hero, hero1Pos);
                //hero2.Draw(hero, hero2Pos);
                //hero3.Draw(hero, hero3Pos);
                //hero4.Draw(hero, hero4Pos);
                if (choosing)
                {
                    for (int b = 0; b < encButtons.Length; b++)
                    encButtons[b].Draw(new Vector2(buttonPlaces[b], 384));
                }
                if (currentFX.active) currentFX.Draw();
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
        static void MarketPhase()
        {

        }
        
        static void Act_ATK(Player[] chars)
        {
            skill = null;
            //canAct = false;
            GameText.SpitOut("Which enemy will " + chars[turn].name + " target?");
            choosing = false;
            choice = true;
            
        }

        static void Act_SPL(Player[] chars)
        {
            skill = new MagMissile();
            //canAct = false;
            targets = new List<int>();
            multTarg = skill.numTimes;
            GameText.SpitOut("Who will " + chars[turn].name + " target?");
            choosing = false;
            choice = true;
            //for (int c = 0; c < skill.numTimes; c++) { multTarg++; }

        }

        static void Attack(Player player, Monster target, Vector2 fxPos)
        {
            int hitRoll = Dice.d20(1);
            //GameText.SpitOut("Rolled " + (hitRoll + player.scoreMod(0)));
            if ((hitRoll + player.scoreMod(0)) + 5 > target.AC || hitRoll == 20)
            {
                if (hitRoll == 20) GameText.SpitOut("Critical hit!");
                DrawFX(player.pcClass.hitFX,fxPos);
                int dmgRoll = player.pcClass.wepDie + player.wepLevel;
                //AtkTimer(player, target, dmgRoll);
                AtkOutcome(player, target, dmgRoll);
            }
            else
            {
                GameText.SpitOut(GameText.HeroMiss(player.name, target.name));
            }
        }
        static void SkillUse(Player player, Monster target, Vector2 fxPos)
        {
            int dmgRoll = 0;
            if (skill.alwaysHit) dmgRoll = skill.dmg + skill.addDmg;
            DrawFX(skill.hitFX, fxPos);
            AtkOutcome(player, target, dmgRoll);
        }
        static void MonsterAttack(Monster monster, Player target)
        {
            int hitRoll = Dice.d20(1);
            //GameText.SpitOut("Rolled " + (hitRoll + player.scoreMod(0)));
            if ((hitRoll + monster.plusHit) > target.AC || hitRoll == 20)
            {
                if (hitRoll == 20) GameText.SpitOut("Critical hit!");
                //DrawFX(monster.hitFX);
                int dmgRoll = monster.atkDmg;
                MonsterOutcome(monster, target, dmgRoll);
            }
            else
            {
                GameText.SpitOut(GameText.HeroMiss(monster.name, target.name));
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
}
