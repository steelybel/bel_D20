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
        public static Texture2D uiTan2 = rl.LoadTexture("Resources/UI/Ancient/tan_pressed.png");
        public static Texture2D uiWhite = rl.LoadTexture("Resources/UI/Ancient/white.png");
        public static Texture2D uiWhite2 = rl.LoadTexture("Resources/UI/Ancient/white_pressed.png");
        public static Font smallFont = rl.LoadFont("Resources/Fonts/romulus.png");
        public static Font bigFont = rl.LoadFont("Resources/Fonts/alagard.png");
        public static Rectangle uiRect = new Rectangle(0, 0, 48, 48);
        public static int uiTextSize;
        public static NPatchInfo uiText = new NPatchInfo
        {
            sourceRec = UI.uiRect,
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
        public static Rectangle size = new Rectangle(0, 0, 128, 40);
        public string text;
        public string flavor;
        //public Texture2D uiTex = new Texture2D();
        //public Texture2D uiTexClick = new Texture2D();
        Texture2D realTex = new Texture2D();
        public Font font;
        public Color fontColor = Color.BLACK;
        bool mouseOver = false;
        public bool clicked = false;
        //Vector2 pos;
        //Rectangle realSize;
        public void Draw(Vector2 v2)
        {
            Vector2 textSize = rl.MeasureTextEx(font, text, font.baseSize, 1f);
            Rectangle rect = new Rectangle(v2.x - (size.width / 2), v2.y - (size.height / 2), size.width, size.height);
            mouseOver = (rl.CheckCollisionPointRec(rl.GetMousePosition(), rect));
            clicked = (mouseOver && rl.IsMouseButtonPressed(0));
            if (clicked) { realTex = UI.uiWhite2; }
            else { realTex = UI.uiWhite; }
            rl.DrawTextureNPatch(UI.uiTan, UI.uiText, rect, Vector2.Zero, 0f, Color.WHITE);
            Vector2 sprLoc = new Vector2(v2.x - (size.width / 2) + 4, v2.y - (size.height / 2) + 4);
            rl.DrawTextureRec(Sprites.tiles,i.spr,sprLoc,i.color);
            rl.DrawTextEx(font, text, new Vector2(v2.x - (size.width / 2) + i.spr.width + 8, v2.y - (textSize.y /2)), font.baseSize, 1f, fontColor);
            if (mouseOver) { UI.MouseOver(UI.uiWhite2, flavor, UI.smallFont); }
        }
    }
    class B_Attack : Button
    {
        public B_Attack()
        {
            i = new I_Attack();
            //uiTex = UI.uiTan;
            //uiTexClick = UI.uiTan2;
            text = "Attack";
            flavor = "Attack one enemy with your\nequipped weapon.";
            font = UI.bigFont;
        }
    }

    class B_Spell : Button
    {
        public B_Spell()
        {
            i = new I_Spell();
            //uiTex = UI.uiTan;
            //uiTexClick = UI.uiTan2;
            text = "Skill";
            flavor = "Use a race or class specific\nskill against an enemy.";
            font = UI.bigFont;
        }
    }
    class B_Item : Button
    {
        public B_Item()
        {
            i = new I_Item();
            //uiTex = UI.uiTan;
            //uiTexClick = UI.uiTan2;
            text = "Item";
            flavor = "Use an item in this character's\ninventory.";
            font = UI.bigFont;
        }
    }
    class B_Flee : Button
    {
        public B_Flee()
        {
            i = new I_Flee();
            //uiTex = UI.uiTan;
            //uiTexClick = UI.uiTan2;
            text = "Flee";
            flavor = "Leave the battle. Ends the whole\nday. Only use as last resort.";
            font = UI.bigFont;
        }
    }
}
