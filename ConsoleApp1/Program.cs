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
        static bool canAct = true;
        public static Dice dice = new Dice();
        public static bool looping = true;
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            rl.InitWindow(screenWidth, screenHeight, "Dungeons!");
            rl.SetTargetFPS(60);
            Font smallFont = rl.LoadFont("Resources/Fonts/romulus.png");
            Font bigFont = rl.LoadFont("Resources/Fonts/alagard.png");//rl.LoadFont("Resources/Fonts/alagard_by_pix3m-d6awiwp.ttf");
            Texture2D hero = rl.LoadTexture("Resources/Sprites/roguelikeChar_transparent.png");
            Texture2D uiTan = rl.LoadTexture("Resources/UI/Ancient/tan.png");
            Vector2 hero1Pos = new Vector2((screenWidth / 2) - 48, 300);
            Vector2 hero2Pos = new Vector2((screenWidth / 2) - 16, 300);
            Vector2 hero3Pos = new Vector2((screenWidth / 2) + 16, 300);
            Vector2 hero4Pos = new Vector2((screenWidth / 2) + 48, 300);
            Rectangle mainText = new Rectangle(200, 0, 400, 96);
            Vector2 textPlace = new Vector2((screenWidth / 2), 48);
            Font curFont = bigFont;
            int textScl = curFont.baseSize;
            
            

            Player hero1 = new Premade1();
            Player hero2 = new Premade2();
            Player hero3 = new Premade3();
            Player hero4 = new Premade4();
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------

                //string textStr = "Congrats! You rolled a " + dice.d20(1) + "\n"
                //+ GameText.HeroAtk("Jon","Goblin",dice.d8(1));
                if (canAct)
                { 
                    if (rl.IsKeyPressed(KeyboardKey.KEY_ONE))
                    {
                        GameText.SpitOut(GameText.HeroAtk("Jon", "Goblin", dice.d8(1)));
                    }
                }
                GameText.textLoc1 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).x / 2), 64);
                GameText.textLoc2 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 0f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y);
                GameText.textLoc3 = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, GameText.textLatest3, textScl, 0f).x / 2), 64 - rl.MeasureTextEx(curFont, GameText.textLatest1, textScl, 0f).y - rl.MeasureTextEx(curFont, GameText.textLatest2, textScl, 0f).y);
                //whereText = new Vector2((screenWidth / 2) - (rl.MeasureTextEx(curFont, textStr, textScl, 0f).x / 2), 48);
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);
                rl.DrawTextureNPatch(uiTan, UI.uiText, mainText, Vector2.Zero, 0f, Color.WHITE);
                rl.DrawTextEx(curFont, GameText.textLatest3, GameText.textLoc3, textScl, 0, Color.GRAY);
                rl.DrawTextEx(curFont, GameText.textLatest2, GameText.textLoc2, textScl, 0, Color.DARKGRAY);
                rl.DrawTextEx(curFont, GameText.textLatest1, GameText.textLoc1, textScl, 0, Color.BLACK);

                hero1.Draw(hero, hero1Pos);
                hero2.Draw(hero, hero2Pos);
                hero3.Draw(hero, hero3Pos);
                hero4.Draw(hero, hero4Pos);
                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
