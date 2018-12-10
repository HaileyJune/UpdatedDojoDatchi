using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UpdatedLogReg.Models;

namespace UpdatedDojoDatchi.Models
{
    public class MonsterObject
    {
        public int MonsterObjectId {get;set;}
        public int Fullness {get;set;}
        public int Happiness {get;set;}
        public int Meals {get;set;}
        public int Energy {get;set;}
        public string Reaction {get;set;}
        public bool isAlive {get;set;}
        public string img {get;set;}
        public int UserId {get;set;}
        public UserObject Owner {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;



        public MonsterObject()
        {
            Fullness = 20;
            Happiness = 20;
            Energy = 50;
            Meals = 3;
            Reaction = "This is your new Monster! Take good care of it.";
            img = "~/images/rollyimg.gif";
            isAlive = true;
        }

        public void Feed()
        {
            if (Meals < 1)
            {
                Reaction = "You don't have anything to feed your Monster.";
                img = "~/images/hungryimg.gif";
            }
            else
            {
                Meals--;
                Random rand = new Random();
                int chances = rand.Next(4);
                if (chances ==  0)
                {
                    Reaction = "Your Monster didn't like their meal. Meals -1";
                img = "~/images/feedimg2.gif";
                }
                else
                {
                    int amount = rand.Next(5, 11);
                    Fullness += amount;
                    if (Fullness > 100)
                    {
                        Fullness = 100;
                    }
                    Reaction = $"You fed your Monster! Fullness +{amount}, Meals -1";
                    img = "~/images/feedimg.gif";
                }
            }
            checkAlive();
        }

        public void Play()
        {
            Energy -= 5;
            Random rand = new Random();
            int chances = rand.Next(4);
            if (chances ==  0)
            {
                Reaction = "Your Monster didn't like playing. Energy -5";
                img = "~/images/unhappyimg4.gif";
            }
            else
            {
                int amount = rand.Next(5, 11);
                Happiness += amount;
                if (Happiness > 100)
                {
                    Happiness = 100;
                }
                if (amount < 8)
                {
                    img = "~/images/playimg2.gif";
                }
                else
                {
                    img = "~/images/playimg3.gif";
                }
                Reaction = $"You played with your Monster! Happiness +{amount}, Energy -5";
            }
            checkAlive();
        }

        public void Work()
        {
            Energy -= 5;
            Random rand = new Random();
            int amount = rand.Next(1, 4);
            Meals += amount;
            Reaction = $"Your Monster worked! Meals +{amount}, Energy-5";
                if (amount > 3)
                {
                    img = "~/images/workimg.gif";
                }
                else
                {
                    img = "~/images/workimg2.gif";
                }
            checkAlive();
        }
        
        public void Sleep()
        {
            Random rand = new Random();
            Energy += 15;
            if (Energy > 100)
            {
                Energy = 100;
            }
            Happiness -= 5;
            Fullness -= 5;
            Reaction = "Your Monster slept! Energy +15, Happiness -5, Fullness -5";
            int src = rand.Next(0,2);
            if (src == 0)
            {
                img = "~/images/sleepimg.gif";
            }
            else
            {
                img = "~/images/sleepimg2.gif";
            }
            checkAlive();
        }

        public void checkAlive()
        {
            if (Fullness <= 0 || Happiness <= 0 || Energy <= 0)
            {
                isAlive = false;
                Random rand = new Random();
            int src = rand.Next(0,2);
    
            if (src == 0)
            {
                img = "~/images/unhappyimg2.gif";                
            }
            else
            {
                img = "~/images/unhappyimg3.gif";                
            }
                Reaction = "Your Monster has died. You had one job.";
            }
        }
        public void reset()
        {
            Fullness = 20;
            Happiness = 20;
            Energy = 50;
            Meals = 3;
            img = "~/images/rollyimg.gif";
            Reaction = "This is your new Monster! Take good care of it.";
            isAlive = true;
        }
    }
}