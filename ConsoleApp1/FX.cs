using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace bel_D20
{
    class FX
    {
        public Texture2D sprite;
        public Color color;
        public bool active = false;
        public Vector2 size;
        public Rectangle frame = new Rectangle(224, 640, 32, 32);
        public int numFrames = 0;
        public int numLines = 0;
        int currentFrame = 0;
        int currentLine = 0;
        int framesCounter = 0;
        public Vector2 pos;
        public void Draw()
        {
            framesCounter++;
            if (framesCounter > 1)
            {
                currentFrame++;
                if (currentFrame >= numFrames)
                {
                    currentFrame = 0;
                    currentLine++;
                    if (currentLine >= numLines)
                    {
                        currentLine = 0;
                        active = false;
                    }

                }

                framesCounter = 0;
            }
            Vector2 newPos = new Vector2(pos.x - (size.x / 2), pos.y - (size.y / 2));
            frame = new Rectangle(size.x * currentFrame, size.y * currentLine, size.x, size.y);
            if (active) rl.DrawTextureRec(sprite, frame, newPos, color);
        }
        public void Reset()
        {
            currentFrame = 0;
        }
    }
    class Blunt : FX
    {
        public Blunt()
        {
            sprite = Sprites.blunt;
            color = Color.WHITE;
            size = new Vector2(64, 64);
            numFrames = 10;
            numLines = 0;
        }
    }
    class Blunt2 : FX
    {
        public Blunt2()
        {
            sprite = Sprites.blunt2;
            color = Color.WHITE;
            size = new Vector2(64, 64);
            numFrames = 4;
            numLines = 2;
        }
    }
    class Slash : FX
    {
        public Slash()
        {
            sprite = Sprites.slash;
            color = Color.WHITE;
            size = new Vector2(64, 64);
            numFrames = 4;
            numLines = 2;
        }
    }
    class Pierce : FX
    {
        public Pierce()
        {
            sprite = Sprites.pierce;
            color = Color.WHITE;
            size = new Vector2(64, 64);
            numFrames = 4;
            numLines = 2;
        }
    }
    class MagMis : FX
    {
        public MagMis()
        { 
            sprite = Sprites.magMis;
            color = new Color(155, 255, 205, 255);
            size = new Vector2(64, 64);
            numFrames = 10;
        }
    }
}
