using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class DiceRoller
    {
        private Random random = new Random();
        private int seed = 0;
        
        // for a future date...
        // private float time = 0.0f;

        public DiceRoller()
        {
            seed = random.Next();
            random = new Random();
        }

        public DiceRoller(int seed)
        {
            random = new Random(seed);
        }

        // 4d6 - numOfTimes = 4, numOfFaces = 6
        public int RollDice(int numOfFaces, int numOfTimes = 1)
        {
            int total = 0;
            
            for (int i = 0; i < numOfTimes; i++)
            {
                total += random.Next(1, numOfFaces + 1);
            }

            return total;
        }

        public int RollWithAdvantage(int numOfFaces, int numOfTimes = 1)
        {
            int total1 = RollDice(numOfFaces, numOfTimes);
            int total2 = RollDice(numOfFaces, numOfTimes);

            if (total1 > total2)
                return total1;
            else
                return total2;
        }

        public int RollWithDisadvantage(int numOfFaces, int numOfTimes = 1)
        {
            int total1 = RollDice(numOfFaces, numOfTimes);
            int total2 = RollDice(numOfFaces, numOfTimes);

            if (total1 < total2)
                return total1;
            else
                return total2;
        }
    }
}
