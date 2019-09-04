using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class GameText
    {
        public static Vector2 textLoc1 = new Vector2();
        public static Vector2 textLoc2 = new Vector2();
        public static Vector2 textLoc3 = new Vector2();
        public static string textLatest1 = "";
        public static string textLatest2 = "";
        public static string textLatest3 = "";

        public static void SpitOut(string txt)
        {
            textLatest3 = textLatest2;
            textLatest2 = textLatest1;
            textLatest1 = txt;
        }

        public static string HeroAtk(string chrName, string enemyName, int dmg)
        {
            string a = chrName + " attacks! " + enemyName + " takes " + dmg + " damage.";
            return a;
        }
    }
}
