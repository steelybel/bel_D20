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
            Rectangle skin1f = new Rectangle(17, 0, 16, 16);
            Rectangle skin2 = new Rectangle(0, 17, 16, 16);
            Rectangle skin2f = new Rectangle(17, 17, 16, 16);
            Rectangle skin3 = new Rectangle(0, 34, 16, 16);
            Rectangle skin3f = new Rectangle(17, 34, 16, 16);
            Rectangle skin4 = new Rectangle(0, 51, 16, 16);
            Rectangle skin4f = new Rectangle(17, 51, 16, 16);
            Rectangle hairElf = new Rectangle(358, 85, 16, 16);
            Rectangle shirt1 = new Rectangle(103, 0, 16, 16);
            Rectangle TopElf = new Rectangle(120, 119, 16, 16);
            Rectangle TopWiz = new Rectangle(256, 119, 16, 16);
            Rectangle mTopBarb = new Rectangle(103, 17, 16, 16);
            Rectangle fTopBarb = new Rectangle(120, 17, 16, 16);
            Rectangle hatWiz = new Rectangle(494, 136, 16, 16);
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
            Rectangle sword1 = new Rectangle(749, 102, 16, 16);
            Rectangle knife1 = new Rectangle(749, 119, 16, 16);
            Rectangle staff1 = new Rectangle(715, 17, 16, 16);
            Rectangle axe1 = new Rectangle(800, 17, 16, 16);
            Vector2 hero1Pos = new Vector2(352, 300);
            Vector2 hero2Pos = new Vector2(384, 300);
            Vector2 hero3Pos = new Vector2(416, 300);
            Vector2 hero4Pos = new Vector2(448, 300);

            
            

            Player hero1 = new Player();

            Player hero2 = new Player();

            Player hero3 = new Player();

            Player hero4 = new Player();
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
