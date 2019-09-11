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
            Rectangle infoRec = new Rectangle(rl.GetMouseX(), rl.GetMouseY() + 16, rl.MeasureTextEx(font, words, font.baseSize, 1f).x + 8, rl.MeasureTextEx(font, words, font.baseSize, 1f).y + 8);
            Vector2 getMouse = new Vector2(rl.GetMouseX(), rl.GetMouseY());
            rl.DrawTextureNPatch(uiBlock, uiText, infoRec, Vector2.Zero, 0f, Color.WHITE);
            rl.DrawTextEx(font, words, new Vector2(rl.GetMouseX() + (infoRec.width / 2) - (rl.MeasureTextEx(font, words, font.baseSize, 1f).x / 2), rl.GetMouseY() + 20), font.baseSize, 1f, Color.BLACK);
        }
        public static void MouseOverIcon(Texture2D uiBlock, string words, Font font, Icon icon)
        {
            Rectangle infoRec = new Rectangle(rl.GetMouseX(), rl.GetMouseY() + 16, rl.MeasureTextEx(font, words, font.baseSize, 1f).x + 12 + icon.spr.width, rl.MeasureTextEx(font, words, font.baseSize, 1f).y + 8);
            if (icon.spr.height > rl.MeasureTextEx(font, words, font.baseSize, 1f).y)
            {
                infoRec = new Rectangle(rl.GetMouseX(), rl.GetMouseY() + 16, rl.MeasureTextEx(font, words, font.baseSize, 1f).x + 12 + icon.spr.width, icon.spr.height + 8);
            }
            else
            {
                infoRec = new Rectangle(rl.GetMouseX(), rl.GetMouseY() + 16, rl.MeasureTextEx(font, words, font.baseSize, 1f).x + 12 + icon.spr.width, rl.MeasureTextEx(font, words, font.baseSize, 1f).y + 8);
            }
            Vector2 getMouse = new Vector2(rl.GetMouseX(), rl.GetMouseY());
            rl.DrawTextureNPatch(uiBlock, uiText, infoRec, Vector2.Zero, 0f, Color.WHITE);
            rl.DrawTextureRec(Sprites.tiles, icon.spr, new Vector2(rl.GetMouseX() + 4, rl.GetMouseY() + 20), icon.color);
            rl.DrawTextEx(font, words, new Vector2(rl.GetMouseX() + ((infoRec.width - icon.spr.width) / 2) - (rl.MeasureTextEx(font, words, font.baseSize, 1f).x / 2) + icon.spr.width, rl.GetMouseY() + 20), font.baseSize, 1f, Color.BLACK);

        }
    }
    class Button
    {
        public Icon i;
        public static Rectangle size;
        public string text;
        public string flavor;
        public Texture2D uiTex;
        public Texture2D uiTexClick;
        static Texture2D realTex;
        public Font font;
        bool selected = false;
        static Vector2 pos;
        static Rectangle realSize;
        public void Draw(Vector2 position)
        {
            pos = new Vector2(position.x - (size.y / 2), position.y - (size.y / 2));
            realSize = new Rectangle(pos.x, pos.y, size.x, size.y);
            if (rl.CheckCollisionPointRec(rl.GetMousePosition(), realSize))
            {
                Console.WriteLine("bruh");
                UI.MouseOver(UI.uiWhite2, flavor, UI.smallFont);
                if (rl.IsMouseButtonDown(0)) { selected = true; }
                else { selected = false; }
                if (rl.IsMouseButtonPressed(0)) { realTex = uiTexClick; }
                else if (rl.IsMouseButtonReleased(0)) { realTex = uiTex; }
            }
            rl.DrawTextureNPatch(realTex, UI.uiText, size, pos, 0f, Color.WHITE);
            rl.DrawTextureRec(Sprites.tiles, i.spr, new Vector2(pos.x + 4, pos.y + (size.height / 2) - (i.spr.height / 2)), Color.WHITE);
            rl.DrawTextEx(font, text, new Vector2(pos.x + 8 + i.spr.width, pos.y + (size.height / 2) - (rl.MeasureTextEx(font,text,font.baseSize,1f).y / 2)), font.baseSize, 1f, Color.BLACK);
        } 
    }
    class B_Attack : Button
    {
        public B_Attack()
        {
            i = new I_Attack();
            size = new Rectangle(0, 0, 128, 40);
            uiTex = UI.uiWhite;
            uiTexClick = UI.uiWhite2;
            text = "Attack";
            flavor = "Attack one enemy with your equipped weapon.";
            font = UI.bigFont;
        }
    }
}
