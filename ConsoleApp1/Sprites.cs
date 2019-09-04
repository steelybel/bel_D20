﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class Sprites
    {
        public static Rectangle skin1 = new Rectangle(0, 0, 16, 16);
        public static Rectangle skin1f = new Rectangle(17, 0, 16, 16);
        public static Rectangle skin2 = new Rectangle(0, 17, 16, 16);
        public static Rectangle skin2f = new Rectangle(17, 17, 16, 16);
        public static Rectangle skin3 = new Rectangle(0, 34, 16, 16);
        public static Rectangle skin3f = new Rectangle(17, 34, 16, 16);
        public static Rectangle skin4 = new Rectangle(0, 51, 16, 16);
        public static Rectangle skin4f = new Rectangle(17, 51, 16, 16);
        public static Rectangle topPal = new Rectangle(171, 68, 16, 16);
        public static Rectangle topWar = new Rectangle(154, 51, 16, 16);
        public static Rectangle topRog = new Rectangle(239, 85, 16, 16);
        public static Rectangle topWiz = new Rectangle(120, 119, 16, 16);
        public static Rectangle topBrb = new Rectangle(222, 119, 16, 16);
        public static Rectangle hatClr = new Rectangle(222, 68, 16, 16);
        public static Rectangle hatWiz = new Rectangle(528, 136, 16, 16);
        public static Rectangle hatWar = new Rectangle(477, 102, 16, 16);
        public static Rectangle pants1 = new Rectangle(52, 0, 16, 16);
        public static Rectangle pants2 = new Rectangle(52, 17, 16, 16);
        public static Rectangle pants3 = new Rectangle(52, 34, 16, 16);
        public static Rectangle pants4 = new Rectangle(52, 51, 16, 16);
        public static Rectangle pants5 = new Rectangle(52, 85, 16, 16);
        public static Rectangle pants6 = new Rectangle(52, 102, 16, 16);
        public static Rectangle pants7 = new Rectangle(52, 119, 16, 16);
        public static Rectangle pants8 = new Rectangle(52, 136, 16, 16);
        public static Rectangle shoe1 = new Rectangle(69, 0, 16, 16);
        public static Rectangle shoe2 = new Rectangle(69, 17, 16, 16);
        public static Rectangle shoe3 = new Rectangle(69, 34, 16, 16);
        public static Rectangle shoe4 = new Rectangle(69, 51, 16, 16);
        public static Rectangle shoe5 = new Rectangle(69, 85, 16, 16);
        public static Rectangle shoe6 = new Rectangle(69, 102, 16, 16);
        public static Rectangle shoe7 = new Rectangle(69, 119, 16, 16);
        public static Rectangle shoe8 = new Rectangle(69, 136, 16, 16);
        public static Rectangle shield1 = new Rectangle(613, 51, 16, 16);
        public static Rectangle sword1 = new Rectangle(732, 102, 16, 16);
        public static Rectangle sword2 = new Rectangle(749, 102, 16, 16);
        public static Rectangle sword3 = new Rectangle(766, 102, 16, 16);
        public static Rectangle sword4 = new Rectangle(783, 102, 16, 16);
        public static Rectangle knife1 = new Rectangle(732, 119, 16, 16);
        public static Rectangle knife2 = new Rectangle(749, 119, 16, 16);
        public static Rectangle knife3 = new Rectangle(766, 119, 16, 16);
        public static Rectangle knife4 = new Rectangle(783, 119, 16, 16);
        public static Rectangle mace1 = new Rectangle(800, 0, 16, 16);
        public static Rectangle mace2 = new Rectangle(800, 68, 16, 16);
        public static Rectangle mace3 = new Rectangle(800, 102, 16, 16);
        public static Rectangle mace4 = new Rectangle(800, 136, 16, 16);
        public static Rectangle staff1 = new Rectangle(715, 0, 16, 16);
        public static Rectangle staff2 = new Rectangle(715, 51, 16, 16);
        public static Rectangle staff3 = new Rectangle(715, 17, 16, 16);
        public static Rectangle staff4 = new Rectangle(715, 34, 16, 16);
        public static Rectangle axe1 = new Rectangle(800, 17, 16, 16);
        public static Rectangle axe2 = new Rectangle(800, 51, 16, 16);
        public static Rectangle axe3 = new Rectangle(800, 85, 16, 16);
        public static Rectangle axe4 = new Rectangle(800, 153, 16, 16);
        public static Rectangle bow1 = new Rectangle(885, 0, 16, 16);
        public static Rectangle bow2 = new Rectangle(902, 34, 16, 16);
        public static Rectangle bow3 = new Rectangle(902, 17, 16, 16);
        public static Rectangle bow4 = new Rectangle(902, 68, 16, 16);
        public static List<Rectangle> knife = new List<Rectangle> { knife1, knife2, knife3, knife4 };
        public static List<Rectangle> sword = new List<Rectangle> { sword1, sword2, sword3, sword4 };
        public static List<Rectangle> mace = new List<Rectangle> { mace1, mace2, mace3, mace4 };
        public static List<Rectangle> bow = new List<Rectangle> { bow1, bow2, bow3, bow4 };
        public static List<Rectangle> axe = new List<Rectangle> { axe1, axe2, axe3, axe4 };
        public static List<Rectangle> staff = new List<Rectangle> { staff1, staff2, staff3, staff4 };
    }
}
