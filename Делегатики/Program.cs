using System;

namespace Делегатики
{
    class Program
    {
        // Делегаты это что-то на подобии переменной, только для методов.
        // Если делегату не присвоить никакого метода, выдаст ошибку.
        public delegate int ValueDelegate(int i);

        public delegate void MyDelegate();

        public delegate bool Predicate(int value); /* Такой тип делегата возвращающий булевое значение и
        принимает 1 аргумент.*/
        // Эта запись Predicate эквивалентна той, что записана в методе Main.


        public delegate int Func(string value); // Эквивалентен тому Func, что в Main.


        /*public delegate void Action(int i);*/

        public event MyDelegate Event;

        public event Action EventAction;

        static void Main(string[] args)
        {
            #region Работа с делегатами.
            /*MyDelegate myDelegate = Method1;
            myDelegate += Method4;
            myDelegate();


            MyDelegate myDelegate2 = new MyDelegate(Method4);
            myDelegate2 += Method4;
            myDelegate2 -= Method4;
            myDelegate2.Invoke();


            MyDelegate myDelegate3 = myDelegate + myDelegate2;
            myDelegate3.Invoke();


            var ValueDelegate = new ValueDelegate(MethodValue);
            ValueDelegate += MethodValue;
            ValueDelegate += MethodValue;
            ValueDelegate += MethodValue;
            ValueDelegate += MethodValue;

            ValueDelegate((new Random()).Next(10, 50));


            Action action = Method1; // Делегат который не возвращает никакого значения.
            action(); // Одним словом синтаксический сахар и принимает от 0 до 16 аргументов.

            *//*Action<int, int, string> action2 = Method1;
            action2();*//*



            Predicate<int> predicate; // Обязан принимать 1 тип.


            Func<string, int> func; // Возрвращаемое значение пишется последним. В данном случае это int.


            *//*public delegate int Func2(string value, char i);   Полная запись Func2  *//*

            Func<string, char, int> Func2;

            Func<int, int> func3 = MethodValue;
            if (func3 != null)
                func3(5);
            // Или иная запись
            func3?.Invoke(5); // Проверки на наличие присвоенного метода делегату func3.*/


            #endregion

            Person person = new Person
            {
                Name = "Владимир"
            };
            person.GoToSleep += Person_GoToSleep;
            person.DoWork += Person_DoWork;
            person.TakeTime(DateTime.Parse("28.03.2021 21:13:05"));
            person.TakeTime(DateTime.Parse("28.03.2021 4:13:05"));


            // Каррирование в действии:

            Console.WriteLine(Sum(5, 5, calc1));
            Console.WriteLine(Sum(5, 5, calc2));
            Console.ReadLine();

        }

        private static void Person_DoWork(object sender, EventArgs e)
        {
            if (sender is Person)
            {
            Console.WriteLine($"{((Person)sender).Name} Пора на работу");
            }
        }

        private static void Person_GoToSleep()
        {
            Console.WriteLine("Человек пошел спать");
            Console.ReadLine();
        }

        //Пример с Каррированием

        private static int Sum(int a, int b, Func<int, int, int> calc)
        {
            return calc(a, b);
        }

        private static int calc1(int i, int j)
        {
            return i * j;
        }
        private static int calc2(int i, int j)
        {
            return i + j;
        }




        #region Работа с делегатами их методы.
        public static int MethodValue(int i)
        {
            Console.WriteLine(i);
            return i;
        }
        public static void Method1()
        {
            Console.WriteLine("Method1");
            Console.ReadLine();
        }
        public static int Method2()
        {
            Console.WriteLine("Method2");
            return 0;
        }
        public static void Method3(int i)
        {
            Console.WriteLine("Method3");
        }
        public static void Method4()
        {
            Console.WriteLine("Method4");
        }
        #endregion


    }
}
