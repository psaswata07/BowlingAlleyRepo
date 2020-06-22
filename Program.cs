using System;
using BowlingAlleyRepo.Model;

namespace BowlingAlleyRepo
{
    class Program
    {
        //Entry Point of Console App.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Enter Number Of Games to Be Played");
            var numberOfGamesToBePlayed = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Number Of Lanes");
            var numberOfLanes = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 1 For Spare And Strike Bonus Strategy");
            Console.WriteLine("Enter 2 For Lucky Seven Bonus Strategy");

            var optionChosen = Convert.ToInt32(Console.ReadLine());

            IBonusStrategy bonusStrategy;
            if(optionChosen == 1)
            {
                bonusStrategy = new SpareAndStrikeBonusStrategy();
            }
            else{
                bonusStrategy = new LuckySevenStrategy();
            }


            AlleyManager.SimulateBowlingArena(numberOfLanes, numberOfGamesToBePlayed, bonusStrategy);


        }
    }
}
