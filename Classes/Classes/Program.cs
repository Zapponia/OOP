using System;
using System.Text;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {

            bool coffeeMachineIsRunning = false;
            bool pottedPlantIsRunning = false;
            bool engineIsRunning = false;
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("To enter the coffee machine, type cm \n" +
                    "To enter the potted plant, type pp \n" +
                    "To enter the engine, type e \n" +
                    "Or type exit to quit");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "cm":
                        coffeeMachineIsRunning = true;
                        break;
                    case "pp":
                        pottedPlantIsRunning = true;
                        break;
                    case "e":
                        engineIsRunning = true;
                        break;
                    case "exit":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("I didn't understand, please try again.");
                        break;
                }


                while (pottedPlantIsRunning)
                {

                }
                while (engineIsRunning)
                {

                }

                while (coffeeMachineIsRunning)
                {
                    Coffemachine coffemachine = new Coffemachine();
                    coffemachine.width = 50;
                    coffemachine.heigth = 180;
                    coffemachine.depth = 60;
                    coffemachine.priceOfCoffee = 5;

                    bool isRunningCM = true;
                    while (isRunningCM)
                    {
                        if (coffemachine.amountOfCoffeeInPercent < 15)
                        {
                            Console.WriteLine("You need to refill the machine, type in fill before you take a cup");
                            Console.ReadKey();
                        }

                        if (coffemachine.buttonPressed)
                        {
                            coffemachine = coffemachine.CupOfCoffee(coffemachine);
                            coffemachine.buttonPressed = false;
                        }
                        Console.Clear();
                        Console.WriteLine("Do you want a cup of coffee? Then write coffee \n" +
                            "Do you want to know how much coffee is currently in the machine? Then write status \n" +
                            "Do you want to fill up the machine? Then write fill \n" +
                            "");
                        input = Console.ReadLine();

                        switch (input.ToLower())
                        {
                            case "coffee":
                                coffemachine = coffemachine.ButtonPress(coffemachine);
                                break;
                            case "status":
                                coffemachine.CurrentAmountOfCoffee(coffemachine);
                                break;
                            case "fill":
                                coffemachine = coffemachine.FillMachine(coffemachine);
                                break;
                            case "hit":
                                coffemachine.Hit();
                                break;
                            default:
                                Console.WriteLine("I'm sorry I didn't understand that. Please try again.");
                                break;
                        }
                        Console.Clear();
                    }
                }
            }
        }
    }

    class Coffemachine
    {
        //Variable declaration
        public int moneyInMachine;
        public int priceOfCoffee;
        public int depth;
        public int heigth;
        public int width;
        public int amountOfCoffeeInPercent;
        public bool buttonPressed = false;

        /// <summary>
        /// If machine is hit
        /// </summary>
        public void Hit()
        {
            Console.WriteLine("What could you possibly gain from that???");
            Console.ReadKey();
        }

        /// <summary>
        /// Bressing button to buy coffee
        /// </summary>
        /// <param name="coffemachine"></param>
        /// <returns></returns>
        public Coffemachine ButtonPress(Coffemachine coffemachine)
        {
            if (coffemachine.amountOfCoffeeInPercent < 5)
            {
                Console.WriteLine("There's no more coffee in the machine, please fill it first");
                Console.ReadKey();
                return coffemachine;
            }
            bool run = true;
            while (run)
            {

                Console.WriteLine("Please insert {0} coins per cup of coffee you want:", coffemachine.priceOfCoffee);
                string input = Console.ReadLine();
                try
                {
                    int money = Convert.ToInt32(input);
                    coffemachine.moneyInMachine = money;
                    Console.WriteLine("You have successfully entered {0} into the machine", money);
                    Console.ReadKey();
                    run = false;
                    coffemachine.buttonPressed = true;
                }
                catch
                {
                    Console.WriteLine("Please insert real money \n" +
                        "(Type a number)");
                }
            }
            return coffemachine;
        }

        /// <summary>
        /// Cups of coffee being dispensed
        /// </summary>
        /// <param name="coffemachine"></param>
        /// <returns></returns>
        public Coffemachine CupOfCoffee(Coffemachine coffemachine)
        {
            int counter = 0;
            while (coffemachine.moneyInMachine >= 5)
            {
                if (coffemachine.amountOfCoffeeInPercent < 5)
                {
                    Console.WriteLine("There's no more coffee in the machine, please fill it first");
                    Console.ReadKey();
                    coffemachine = coffemachine.PayMoneyBack(coffemachine);
                    return coffemachine;
                }
                coffemachine.amountOfCoffeeInPercent = coffemachine.amountOfCoffeeInPercent - 5;
                counter += 1;
                coffemachine.moneyInMachine = coffemachine.moneyInMachine - coffemachine.priceOfCoffee;
                if (coffemachine.moneyInMachine < coffemachine.priceOfCoffee && coffemachine.moneyInMachine != 0)
                {
                    coffemachine = coffemachine.PayMoneyBack(coffemachine);
                }
            }
            Console.WriteLine("You have taken {0} cups of coffee", counter);
            Console.ReadKey();
            return coffemachine;
        }

        /// <summary>
        /// Money being repaid
        /// </summary>
        /// <param name="coffemachine"></param>
        /// <returns></returns>
        public Coffemachine PayMoneyBack(Coffemachine coffemachine)
        {
            Console.WriteLine("You have {0} left, I will dispense them now", coffemachine.moneyInMachine);
            Console.ReadKey();
            coffemachine.moneyInMachine = 0;
            return coffemachine;

        }

        /// <summary>
        /// Filling machine with coffee
        /// </summary>
        /// <param name="coffemachine"></param>
        /// <returns></returns>
        public Coffemachine FillMachine(Coffemachine coffemachine)
        {
            coffemachine.amountOfCoffeeInPercent = 100;
            return coffemachine;
        }

        /// <summary>
        /// Check how much coffee is left in the machine
        /// </summary>
        /// <param name="coffemachine"></param>
        public void CurrentAmountOfCoffee(Coffemachine coffemachine)
        {
            Console.WriteLine("There is currently {0} percent of coffee in the machine", coffemachine.amountOfCoffeeInPercent);
            Console.ReadKey();
        }
    }
    class engine
    {
        public string brand;
        public string primaryMaterial;
        public int cylinders;
        public double EngineCapacity;
        public bool onStandWithWheel;
        public bool fuelInEngine;
        public bool engineRunning;

        public void engineStart()
        {
            if (fuelInEngine = true)
            {
                engineRunning = true;
            }
            else
            {
                engineRunning = false;
            }
        }
        public void Movable()
        {
            
        }
        public void Stealable()
        {

        }
        public void Brand()
        {

        }
        public void Material()
        {

        }
        public void NumberOfCylinders()
        {


        }
    }
    class PottedPlant
    {
        public int numberOfLeaves;
        public int[] plantColor;
        public bool isReal;
        public bool isInPot;
        public string isPlantWatered;


        public void Lookatplant()
        {

        }
        public void Photosynthesis()
        {

        }
        public void Removeleaves()
        {

        }
        public void Waterplant()
        {

        }


    }
}


