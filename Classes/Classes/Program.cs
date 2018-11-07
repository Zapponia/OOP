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
                    Console.Clear();
                    Engine engine = new Engine();
                    bool isEngineRunning = true;
                    while (isEngineRunning)
                    {
                        Console.WriteLine("What do you want to do? \n" +
                            "If you want to start the engine write start \n" +
                            "If you want to move the engine write move \n" +
                            "If you want to see if the engine needs cleaning write clean \n" +
                            "If you want to fill the engine with fuel write fuel \n" +
                            "If you want information about the engine write info");
                        input = Console.ReadLine();

                        switch (input.ToLower())
                        {
                            case "start":
                                engine.EngineStart(engine);
                                break;
                            case "move":
                                engine.Movable();
                                break;
                            case "clean":
                                engine.NeedCleaning();
                                break;
                            case "fuel":
                                engine.FillWithFuel(engine);
                                break;
                            case "info":
                                engine.InformationAboutEngine();
                                break;
                            default:
                                Console.WriteLine("I'm sorry I don't understand");
                                break;
                        }
                        Console.Clear();
                    }
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
    class Engine
    {
        public string brand = "Volvo";
        public int cylinders = 6;
        public double engineCapacity = 2.4;
        public string onStandWithWheel;
        public bool fuelInEngine;
        public bool engineRunning;
        public string input = " ";


        public void FillWithFuel(Engine engine)
        {
            if (fuelInEngine == false)
            {
                Console.WriteLine("You filled the engine with fuel");
                fuelInEngine = true;
            }
            else
            {
                Console.WriteLine("The engine is already filled with fuel");
            }
        }

        public void EngineStart(Engine engine)
        {
            
                if (fuelInEngine == true)
                {
                    Console.WriteLine("Engine is running");
                    engineRunning = true;
                }
                else
                {
                    engineRunning = false;
                    Console.WriteLine("The engine needs fuel to start");
                    Console.ReadKey();
                }

            
            
        }
        public void Movable()
        {

            Console.WriteLine("Do you want to move the engine?");
            if (onStandWithWheel == "yes")
            {
                Console.WriteLine("You can change the location of the engine using the wheels");
            }
            else
            {
                Console.WriteLine("It is too heavy to move wihtout wheels. Go find some");
            }
        }
        public void NeedCleaning()
        {
            Console.WriteLine("the engine could use some cleaning");

        }
        public void InformationAboutEngine()
        {
            Console.WriteLine("looking at the engine you see that its a " + cylinders + "cylinders, " + engineCapacity + " liters " + "and its made by " + brand);

        }
    }
    class PottedPlant
    {
        public int numberOfLeaves;
        public int[] plantColor;
        public bool isReal;
        public bool isInPot;
        public string isPlantWatered;

        bool pottedPlantIsRunning = true;

        public void Lookatplant()
        {
            Console.WriteLine("You look at the potted plant. It is very beautiful... You think atleast");
            Console.ReadKey();
        }
        public void CountNumberOfLeaves(PottedPlant pottedPlant)
        {
            Console.WriteLine("You look at the plant, and start counting the leaves: 1..2..3..4..5.. /n " +
                "After counter for what feels like hours you determine the plant to have around " + numberOfLeaves);
            Console.ReadKey();
        }
        public void IsReal()
        {
            bool checkIfReal = true;
            while (checkIfReal)
            {
                Console.WriteLine("You're having a hard time trying to figure out if the plant is real or not. Do you think it's real?");
                string input = Console.ReadLine();
                if (input == "yes")
                {
                    isReal = true;
                    checkIfReal = false;
                    Console.WriteLine("You made up your mind, and decided the plant was real. You think to yourself (What am i doing with my life?)");
                    Console.ReadKey();
                }
                else if (input == "no")
                {
                    isReal = false;
                    checkIfReal = false;
                    Console.WriteLine("You decide for yourself that the plant is fake, and move on with your life. /n" +
                        "After a few weeks the plant has died. Horribly. I guess the plant was real after all. You spend the rest of the day mourning the plant");
                    Console.ReadKey();
                }
                else Console.WriteLine("You need to decide if the plant is real or not. You have a weird feeling that someone forces you to do it");
                Console.ReadKey();
            }
        }
        public void IsInPot()
            {
            Console.WriteLine("This one surely is easy to see. The plant IS in a pot");
            Console.ReadKey();
            }
        public void IsPlantWatered()
        {
            Console.WriteLine("You look at the plant. The plant is very dry. Do you want to water it?");
            string input = Console.ReadLine();
            if (input == "yes")
            {
                Console.WriteLine("You water the plant. The plant is now a little moist. Do you wanna continue to water the plant?");
                input = Console.ReadLine();
                if (input == "yes")
                {
                    Console.WriteLine("");
                }
            }
        }
    }
}