using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    static class Program
    {
        public static Dice dice = new Dice();
        public static bool looping = true;
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            rl.SetTargetFPS(60);
            Texture2D hero = rl.LoadTexture("Resources/Sprites/roguelikeChar_transparent.png");
            Rectangle tile = new Rectangle(0, 0, 16, 16);
            Rectangle skin1 = new Rectangle(0, 0, 16, 16);
            Rectangle skin2 = new Rectangle(0, 17, 16, 16);
            Rectangle skin3 = new Rectangle(0, 34, 16, 16);
            Rectangle skin4 = new Rectangle(0, 51, 16, 16);
            Rectangle shirt1 = new Rectangle(103, 0, 16, 16);
            Rectangle mBarbTop = new Rectangle(103, 17, 16, 16);
            Rectangle fBarbTop = new Rectangle(120, 17, 16, 16);
            Rectangle pants1 = new Rectangle(52, 0, 16, 16);
            Rectangle pants2 = new Rectangle(52, 17, 16, 16);
            Rectangle pants3 = new Rectangle(52, 34, 16, 16);
            Rectangle pants4 = new Rectangle(52, 51, 16, 16);
            Rectangle pants5 = new Rectangle(52, 85, 16, 16);
            Rectangle pants6 = new Rectangle(52, 102, 16, 16);
            Rectangle pants7 = new Rectangle(52, 119, 16, 16);
            Rectangle pants8 = new Rectangle(52, 136, 16, 16);
            Rectangle shoe1 = new Rectangle(69, 0, 16, 16);
            Rectangle shoe2 = new Rectangle(69, 17, 16, 16);
            Rectangle shoe3 = new Rectangle(69, 34, 16, 16);
            Rectangle shoe4 = new Rectangle(69, 51, 16, 16);
            Rectangle shoe5 = new Rectangle(69, 85, 16, 16);
            Rectangle shoe6 = new Rectangle(69, 102, 16, 16);
            Rectangle shoe7 = new Rectangle(69, 119, 16, 16);
            Rectangle shoe8 = new Rectangle(69, 136, 16, 16);
            Vector2 playerPos = new Vector2(400, 300);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);

                rl.DrawText("Congrats! You rolled a " + dice.d20(1), 190, 200, 20, Color.LIGHTGRAY);
                rl.DrawTextureRec(hero, skin1, playerPos, Color.WHITE);
                rl.DrawTextureRec(hero, mBarbTop, playerPos, Color.WHITE);
                //rl.DrawTextureRec(hero, pants8, playerPos, Color.WHITE);
                rl.DrawTextureRec(hero, shoe1, playerPos, Color.WHITE);
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
