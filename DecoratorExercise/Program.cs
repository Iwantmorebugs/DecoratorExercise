using System;

namespace DecoratorExercise
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Hello Coffee lovers!");

            Coffee coffee = new Espresso();
            Console.WriteLine("We start with a basic "+ coffee.GetDescription() + " with a cost of: " + coffee.Cost());

            Coffee coffee2 = new DarkRoast();
            coffee2 = new Mocha(coffee2);
            coffee2 = new WhipCream(coffee2);

            Console.WriteLine("We continue with a " + coffee2.GetDescription() + " with a cost of: " + coffee2.Cost());

            Coffee coffee3 = new HouseBlend();
            coffee3 = new Cinnamon(coffee3);

            Console.WriteLine("We end up with a " + coffee3.GetDescription() + " with a cost of: " + coffee3.Cost());

            Console.ReadLine();
        }

        public abstract class Coffee
        {
            public string Description = "Unknown coffee";
            public string GetDescription()
            {
                return Description;
            }
            public abstract double Cost();
        }

        public abstract class CondimentDecorator : Coffee
        {
            public new abstract string GetDescription();
        }

        public class Espresso: Coffee
        {

            public Espresso()
            {
                Description = "Espresso";
            }
            public override double Cost()
            {
                return 1.99;
            }
        }

        public class HouseBlend : Coffee
        {
            public HouseBlend()
            {
                Description = "House Blend Coffee";
            }

            public override double Cost()
            {
                return 0.89;
            }
        }

        public class DarkRoast : Coffee
        {
            public DarkRoast()
            {
                Description = "Dark Roast Coffee";
            }

            public override double Cost()
            {
                return 0.99;
            }
        }

        public class Mocha : CondimentDecorator
        {
            private readonly Coffee _coffee;

            public Mocha(Coffee coffee)
            {
                _coffee = coffee;
            }

            public override string GetDescription()
            {
                return _coffee.GetDescription()+ ", Mocha";
            }

            public override double Cost()
            {
                return _coffee.Cost()+0.2;
            }
        }

        public class WhipCream : CondimentDecorator
        {
            private readonly Coffee _coffee;

            public WhipCream(Coffee coffee)
            {
                _coffee = coffee;
            }

            public override string GetDescription()
            {
                return _coffee.GetDescription() + ", Whip Cream";
            }

            public override double Cost()
            {
                return _coffee.Cost() + 0.3;
            }
        }

        public class Cinnamon : CondimentDecorator
        {
            private readonly Coffee _coffee;

            public Cinnamon(Coffee coffee)
            {
                _coffee = coffee;
            }

            public override string GetDescription()
            {
                return _coffee.GetDescription() + " Cinnamon";
            }

            public override double Cost()
            {
                return _coffee.Cost() + 0.15;
            }
        }
    }

}
