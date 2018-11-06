﻿using System;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffemachine coffemachine = new Coffemachine();

            bool isRunning = true;
            while(isRunning)
            {
                if (coffemachine.amountOfCoffeeInPercent < 15)
                {
                    coffemachine.amountOfCoffeeInPercent = coffemachine.FillMachine(coffemachine.amountOfCoffeeInPercent);
                    Console.WriteLine(coffemachine.amountOfCoffeeInPercent);
                }

                if(coffemachine.buttonPressed)
                {
                    coffemachine.amountOfCoffeeInPercent = coffemachine.CupOfCoffee(coffemachine.amountOfCoffeeInPercent);
                    coffemachine.buttonPressed = false;
                }
                Console.WriteLine("Do you want a cup of coffee? Then write coffee \n" +
                    "Do you want to know how much coffee is currently in the machine? Then write status \n" +
                    "");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "coffee":
                        coffemachine.buttonPressed = coffemachine.ButtonPress();
                        break;
                    case "status":
                        coffemachine.CurrentAmountOf(coffemachine.amountOfCoffeeInPercent);
                        break;
                }
                Console.Clear();
            }
        }
    }

    class Coffemachine
    {
        public int heigth;
        public int width;
        public int amountOfCoffeeInPercent;
        public bool buttonPressed = false;

        public bool ButtonPress()
        {
            return true;
        }

        public int CupOfCoffee(int cupOfCoffee)
        {
            Console.WriteLine("You have taken a cup of coffee");
            cupOfCoffee = cupOfCoffee - 5;
            return cupOfCoffee;
        }
        public int FillMachine(int currentAmountOfCoffee)
        {
            currentAmountOfCoffee = 100;
            return currentAmountOfCoffee;
        }
        public void CurrentAmountOf(int currentAmountOfCoffee)
        {
            Console.WriteLine(currentAmountOfCoffee);
            Console.ReadKey();
        }
    }
}
