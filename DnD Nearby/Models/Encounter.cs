using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Nearby.Models
{
    public class Encounter
    {
        public struct DifficultyRatings
        {
            public int Easy;
            public int Medium;
            public int Hard;
            public int Deadly;
        }

        DifficultyRatings[] Thresholds = new DifficultyRatings[20];

        public int ID { get; private set; }
        // uncomment all lines once creatures are created.
        //public List<Creature> Creatures { get; private set; }

        public Encounter()
        {
            setThesholds();
            //Creatures = new List<Creature>;
        }

        public Encounter(int id)
        {
            setThesholds();
            ID = id;
            LoadFromDB(ID);
        }

        private void setThesholds()
        {
            Thresholds[0].Easy = 25; Thresholds[0].Medium = 50; Thresholds[0].Hard = 75; Thresholds[0].Deadly = 100;
            Thresholds[1].Easy = 50; Thresholds[1].Medium = 100; Thresholds[1].Hard = 150; Thresholds[1].Deadly = 200;
            Thresholds[2].Easy = 75; Thresholds[2].Medium = 150; Thresholds[2].Hard = 225; Thresholds[2].Deadly = 400;
            Thresholds[3].Easy = 125; Thresholds[3].Medium = 250; Thresholds[3].Hard = 375; Thresholds[3].Deadly = 500;
            Thresholds[4].Easy = 250; Thresholds[4].Medium = 500; Thresholds[4].Hard = 750; Thresholds[4].Deadly = 1100;
            Thresholds[5].Easy = 300; Thresholds[5].Medium = 600; Thresholds[5].Hard = 900; Thresholds[5].Deadly = 1400;
            Thresholds[6].Easy = 350; Thresholds[6].Medium = 750; Thresholds[6].Hard = 1100; Thresholds[6].Deadly = 1700;
            Thresholds[7].Easy = 450; Thresholds[7].Medium = 900; Thresholds[7].Hard = 1400; Thresholds[7].Deadly = 2100;
            Thresholds[8].Easy = 550; Thresholds[8].Medium = 1100; Thresholds[8].Hard = 1600; Thresholds[8].Deadly = 2400;
            Thresholds[9].Easy = 600; Thresholds[9].Medium = 1200; Thresholds[9].Hard = 1900; Thresholds[9].Deadly = 2800;
            Thresholds[10].Easy = 800; Thresholds[10].Medium = 1600; Thresholds[10].Hard = 2400; Thresholds[10].Deadly = 3600;
            Thresholds[11].Easy = 1000; Thresholds[11].Medium = 2000; Thresholds[11].Hard = 3000; Thresholds[11].Deadly = 4500;
            Thresholds[12].Easy = 1100; Thresholds[12].Medium = 2200; Thresholds[12].Hard = 3400; Thresholds[12].Deadly = 5100;
            Thresholds[13].Easy = 1250; Thresholds[13].Medium = 2500; Thresholds[13].Hard = 3800; Thresholds[13].Deadly = 5700;
            Thresholds[14].Easy = 1400; Thresholds[14].Medium = 2800; Thresholds[14].Hard = 4300; Thresholds[14].Deadly = 6400;
            Thresholds[15].Easy = 1600; Thresholds[15].Medium = 3200; Thresholds[15].Hard = 4800; Thresholds[15].Deadly = 7200;
            Thresholds[16].Easy = 2000; Thresholds[16].Medium = 3900; Thresholds[16].Hard = 5900; Thresholds[16].Deadly = 8800;
            Thresholds[17].Easy = 2100; Thresholds[17].Medium = 4200; Thresholds[17].Hard = 6300; Thresholds[17].Deadly = 9500;
            Thresholds[18].Easy = 2400; Thresholds[18].Medium = 4900; Thresholds[18].Hard = 7300; Thresholds[18].Deadly = 10900;
            Thresholds[19].Easy = 2800; Thresholds[19].Medium = 5700; Thresholds[19].Hard = 8500; Thresholds[19].Deadly = 12700;
        }

        public void AddCreature(/*Creature creature*/)
        {
            //Creatures.Add(creature);
        }

        public void RemoveCreature(/*Creature creature*/)
        {
            //Creatures.Remove(creature);
        }

        public int CalcDifficulty()
        {
            /*  int partyXP;
                foreach (Playercharacter player in Creatures)
                {
                    partyXP += Thresholds[player.Level]
                }
             */

            return -1;
        }

        private DifficultyRatings CalcPartyXPThreshold()
        {
            DifficultyRatings DR = new DifficultyRatings();

            /*foreach (PlayerCharacter player in Creatures)
            {
                player.Level;
            }*/

            return DR;
        }

        public void SaveToDB()
        {

        }

        public void LoadFromDB(int id)
        {

        }
    }
}
