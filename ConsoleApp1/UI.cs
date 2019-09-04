using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class UI
    {
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
    }
}
