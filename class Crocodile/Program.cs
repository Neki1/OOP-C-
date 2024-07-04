class Program
{
    class Crocodile
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }

        public Crocodile(string name, int weight, int length, int age, char gender)
        {
            Name = name;
            Weight = weight;
            Length = length;
            Age = age;
            Gender = gender;
        }

        public string ToString()
        {
            return $"Имя: {Name}, Масса: {Weight} кг, Длина: {Length} м, Возраст: {Age} лет, Пол: {Gender}";
        }
    }

    class CrocodileService
    {
      private List<Crocodile> animal = new List<Crocodile>();
      
      public void CreateCrocodile(string name, int weight, int length, int age, char genre)
        {
            Crocodile crocodile = new Crocodile(name, weight, length, age, genre);
            animal.Add(crocodile);
        }

        public void PrintInfo()
        {
            foreach(var animal in animal)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        public void SearchLongLength(int length)
        {
            foreach(var animal in animal)
            {
                if(animal.Length > length)
                {
                    Console.WriteLine(animal.ToString());
                }
            }
        }

        public void SearchOldCroc()
        {
            int maxAge = 0;
            Crocodile croc = null;

            foreach(var animal in animal) 
            { 
                if(animal.Age > maxAge)
                {
                   maxAge = animal.Age;
                   croc = animal;
                }
            }

            if (croc != null)
            {
                Console.WriteLine(croc.ToString());
            }
            else
            {
                Console.WriteLine("Нет крокодилов в списке.");
            }
           
        }

        public void SearchHeavyCroc()
        {
            int maxHeavy = 0;
            Crocodile crocheavy = null;

            foreach (var animal in animal)
            {
                if (animal.Weight > maxHeavy)
                {
                    maxHeavy = animal.Weight;
                    crocheavy = animal;
                }
            }

            if (crocheavy != null)
            {
                Console.WriteLine(crocheavy.ToString());
            }
            else
            {
                Console.WriteLine("Нет крокодилов в списке.");
            }
        }


    }

    static void Main()
    {
        CrocodileService service = new CrocodileService();

        bool finish = true;
        int input = new();
        int age, length, weight;
        char gender;
        string name;

        while (finish)
        {
            Console.Clear();
            Console.WriteLine("""
                              ====================================================
                              Выберите действие
                              ====================================================
                              1.Добавить крокодила
                              ====================================================
                              2.Вывести всех крокодилов
                              ====================================================
                              3.Вывести всех крокодилов длинее какого-то значения
                              ====================================================
                              4.Вывести самого старого крокодила
                              ====================================================
                              5.Вывести самого тяжелого крокодила
                              ====================================================
                              6.Закончить работу
                              ====================================================
                              """);
            while (true)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Не верный ввод необходимо ввести число");
                }
            }

            switch (input)
            {
                case 1:
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Введите имя крокодила:");
                        name = Console.ReadLine();
                        if (name.Length > 0)
                        {
                            break;
                        }
                        Console.WriteLine("Данные введены не верно");
                    }

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Введите пол крокодила(М/Ж):");
                            gender = Convert.ToChar(Console.ReadLine());
                            if (gender != '\n' & gender != ' ' & gender == 'М' | gender == 'Ж')
                            {
                                break;
                            }
                            Console.WriteLine("Данные введены не верно");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Данные введены не верно");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите возрост крокодила:");
                        try
                        {
                            age = Convert.ToInt32(Console.ReadLine());
                            if (age > 0)
                            {
                                break;
                            }
                            Console.WriteLine("Данные введены не верно");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Возрост может быть только целым числом и больше нуля");
                        }

                    }
                    while (true)
                    {
                        Console.WriteLine("Введите длину крокодила:");
                        try
                        {
                            length = Convert.ToInt32(Console.ReadLine());
                            if (length > 0)
                            {
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Длина может быть только целым числом и больше нуля");
                        }
                    }
                    while (true)
                    {
                        Console.WriteLine("Введите вес крокодила:");
                        try
                        {
                            weight = Convert.ToInt32(Console.ReadLine());
                            if (weight > 0)
                            {
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Возрост может быть только числом и больше нуля");
                        }
                    }
                    service.CreateCrocodile(name, gender, age, weight, (char)length);
                    break;

                case 2:
                    Console.Clear();
                    service.PrintInfo();
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("Введите длину больше которой должены быть крокодилы:");
                        try
                        {
                            length = Convert.ToInt32(Console.ReadLine());
                            if (length >= 0)
                                break;
                            Console.WriteLine("Число не может быть отрицательным");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Длина может быть только целым числом");
                        }
                    }
                    service.SearchLongLength(length);
                    Console.ReadKey();
                    break;

                case 4:
                    Console.Clear();
                    service.SearchOldCroc();
                    Console.ReadKey();
                    break;

                case 5:
                    Console.Clear();
                    service.SearchHeavyCroc();
                    Console.ReadKey();
                    break;

                case 6:
                    Console.Clear();
                    finish = false;
                    break;
            }
        }
    }
}
