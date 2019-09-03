using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bel_D20
{
    class Dice
    {
        public Random rng = new Random();
        public int d20 (int numDice)
        {
            int d = 0;
            for (int i = 0; i < numDice; i++)
            {
                d += rng.Next(1, 21);
            }
            return d;
        }
        public int d12(int numDice)
        {
            int d = 0;
            for (int i = 0; i < numDice; i++)
            {
                d += rng.Next(1, 13);
            }
            return d;
        }
        public int d10(int numDice)
        {
            int d = 0;
            for (int i = 0; i < numDice; i++)
            {
                d += rng.Next(1, 11);
            }
            return d;
        }
        public int d8(int numDice)
        {
            int d = 0;
            for (int i = 0; i < numDice; i++)
            {
                d += rng.Next(1, 9);
            }
            return d;
        }
        public int d6(int numDice)
        {
            int d = 0;
            for (int i = 0; i < numDice; i++)
            {
                d += rng.Next(1, 7);
            }
            return d;
        }
        public int d4(int numDice)
        {
            int d = 0;
            for (int i = 0; i < numDice; i++)
            {
                d += rng.Next(1, 5);
            }
            return d;
        }

    }
}
