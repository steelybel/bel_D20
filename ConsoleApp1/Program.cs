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
            int screenWidth = 400;
            int screenHeight = 450;
            rl.InitWindow(screenWidth, screenHeight, "Dungeons!");
            rl.SetTargetFPS(60);
            Texture2D hero = rl.LoadTexture("Resources/Sprites/roguelikeChar_transparent.png");
            Vector2 hero1Pos = new Vector2((screenWidth / 2) - 48, 300);
            Vector2 hero2Pos = new Vector2((screenWidth / 2) - 16, 300);
            Vector2 hero3Pos = new Vector2((screenWidth / 2) + 16, 300);
            Vector2 hero4Pos = new Vector2((screenWidth / 2) + 48, 300);

            
            

            Player hero1 = new Player();
            hero1.pcClass = new Paladin();
            hero1.pcRace = new Human_m(2);
            Player hero2 = new Player();
            hero2.pcClass = new Wizard();
            hero2.pcRace = new Elf_f(0);
            Player hero3 = new Player();
            hero3.pcClass = new Barbarian();
            hero3.pcRace = new Dwarf_f(1);
            Player hero4 = new Player();
            hero4.pcClass = new Rogue();
            hero4.pcRace = new Elf_m(0);
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
