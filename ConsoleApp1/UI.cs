using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class UI
    {
        public static Texture2D uiTan = rl.LoadTexture("Resources/UI/Ancient/tan.png");
        public static Texture2D uiWhite = rl.LoadTexture("Resources/UI/Ancient/white.png");
        public static Texture2D uiWhite2 = rl.LoadTexture("Resources/UI/Ancient/white_pressed.png");
        public static Font smallFont = rl.LoadFont("Resources/Fonts/romulus.png");
        public static Font bigFont = rl.LoadFont("Resources/Fonts/alagard.png");
        public static Rectangle uiRect = new Rectangle(0, 0, 48, 48);
        public static int uiTextSize;
        public static NPatchInfo uiText = new NPatchInfo
        {
            sourceRec = uiRect,
            left = 16,
            top = 16,
            right = 16,
            bottom = 16,
            type = 0
        };
        //public static Rectangle[] choiceButton = new Rectangle
        public static void MouseOver(Texture2D uiBlock, string words, Font font)
        {
            Rectangle infoRec = new Rectangle(rl.GetMouseX(), rl.GetMouseY()+16, rl.MeasureTextEx(font, words, font.baseSize, 0f).x + 8, rl.MeasureTextEx(font, words, font.baseSize, 0f).y + 8);
            Vector2 getMouse = new Vector2(rl.GetMouseX(), rl.GetMouseY());
            rl.DrawTextureNPatch(uiBlock, uiText, infoRec, Vector2.Zero, 0f, Color.WHITE);
            rl.DrawTextEx(font, words, new Vector2(rl.GetMouseX() + (infoRec.width / 2) - (rl.MeasureTextEx(font, words, font.baseSize,0f).x/2), rl.GetMouseY() + 20), font.baseSize, 0, Color.BLACK);
        }
    }
}
