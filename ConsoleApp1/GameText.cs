using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class GameText
    {
        public static StreamWriter txtLog = new StreamWriter("textLog.txt");
        public static Vector2 textLoc1 = new Vector2();
        public static Vector2 textLoc2 = new Vector2();
        public static Vector2 textLoc3 = new Vector2();
        public static Vector2 textLoc4 = new Vector2();
        public static string textLatest1 = "";
        public static string textLatest2 = "";
        public static string textLatest3 = "";
        public static string textLatest4 = "";

        public static void SpitOut(string txt)
        {
            textLatest4 = textLatest3;
            textLatest3 = textLatest2;
            textLatest2 = textLatest1;
            textLatest1 = txt;
            txtLog.WriteLine(txt);
        }
        public static void Clear()
        {
            textLatest1 = "";
            textLatest2 = "";
            textLatest3 = "";
            textLatest4 = "";
        }
        public static string battleAction(string chrName)
        {
            string a = "What will " + chrName + " do?";
            return a;
        }
        public static string HeroAtk(string chrName, string enemyName, int dmg)
        {
            string a = $"{chrName} attacks! {enemyName} takes {dmg} damage.";
            return a;
        }
        public static string HeroHeal(string chrName, string chrName2, int dmg)
        {
            string a = $"{chrName} heals {chrName2}, recovering {dmg*-1} health.";
            return a;
        }
        public static string HeroMiss(string chrName, string enemyName)
        {
            string a = $"{chrName} attempts to attack {enemyName}, but fails.";

            return a;
        }
        public static string WeaponShow(Player chara)
        {
            string a = $"Attack one enemy with your\nequipped weapon.\nEquipped: {chara.weapon.name}";
            return a;
        }
        public static string EnemyEntry(string name)
        {
            string a = name + " approaches!";
            return a;
        }
        public static string DrawHP(string name, int hp)
        {
            string a = name + "\nHP - " + hp;
            return a;
        }
        public static string HeroStats(Player hero)
        {
            string a = $"{hero.name}\nHP {hero.hitPoints}/{hero.maxHP} AC {hero.AC}" +
                $"\nSTR {hero.finScore[0]} ({hero.scoreMod(0)})" +
                $"\nDEX {hero.finScore[1]} ({hero.scoreMod(1)})" +
                $"\nCON {hero.finScore[2]} ({hero.scoreMod(2)})" +
                $"\nINT {hero.finScore[3]} ({hero.scoreMod(3)})" +
                $"\nWIS {hero.finScore[4]} ({hero.scoreMod(4)})" +
                $"\nCHA {hero.finScore[5]} ({hero.scoreMod(5)})" +
                $"";
            return a;
        }
    }
}
