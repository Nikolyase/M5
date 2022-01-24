using System;

namespace M5
{
    class Program
    {


        static (string name, string surName, int age, bool hasPet, int numPets, string[] petName, int numFavColors, string[] favColors) FillUserQuestionnaire()
        {
            (string name, string surName, int age, bool hasPet, int numPets, string[] petName, int numFavColors, string[] favColors) list = (null, null, 0, false, 0, null, 0, null);

            consWrite("Введите Ваше имя:");
            list.name = consRead();
            Console.Clear();
            consWrite("Введите Вашу фамилию:");
            list.surName = consRead();
            Console.Clear();
            var isAgeCorrect = false;
            while (!isAgeCorrect)
            {
                consWrite("Введите Ваш возраст (цифрами):");
                isAgeCorrect = checkEnterValue(consRead(), out list.age);
                Console.Clear();
            }
            var isHasPetCorrenct = false;
            list.hasPet = false;
            while (!isHasPetCorrenct)
            {
                consWrite("У Вас есть питомец? (да/нет)");

                switch (consRead().ToLower().Trim())
                {
                    case "да": case "yes": list.hasPet = true; isHasPetCorrenct = true; break;
                    case "нет": case "no": list.hasPet = false; isHasPetCorrenct = true; break;
                    default: Console.Clear(); continue;
                }
            }
            Console.Clear();
            if (list.hasPet)
            {
                var isnumPetsCorrect = false;
                do
                {
                    consWrite("Сколько у Вас питомцев?");
                    isnumPetsCorrect = checkEnterValue(consRead(), out list.numPets);
                    Console.Clear();
                }
                while (!isnumPetsCorrect);
                list.petName = EnterPetsNames(list.numPets);
            }
            Console.Clear();
            bool isNumFavColorsCorrect = false;
            list.numFavColors = 0;
            for (; !isNumFavColorsCorrect;)
            {
                consWrite("Сколько у Вас любимых цветов?");
                isNumFavColorsCorrect = checkEnterValue(consRead(), out list.numFavColors);
                Console.Clear();
            }
            EnterFavColors(list.numFavColors, out list.favColors);
            Console.Clear();




            consWrite("Имя: " + list.name);
            consWrite("Фамилия: " + list.surName);
            consWrite("Возраст: " + list.age);
            var petsExit = (list.hasPet) ? "да" : "нет";
            consWrite("Домашние питомцы: " + petsExit);
            if (list.hasPet)
            {
                if (list.numPets > 1)
                {
                    consWrite("Клички питомцев:");
                }
                else
                {
                    consWrite("Кличка питомца:");
                }

                foreach (string pet in list.petName)
                {
                    consWrite(pet);
                }
            }

            consWrite("Любимые цвета:");
            for (int i = 0; i < list.numFavColors; i++)
            {
                consWrite(list.favColors[i]);
            }

            return list;
        }

        static bool checkEnterValue(string value, out int result)
        {
            var isCorrect = int.TryParse(value, out result);
            if (result <= 0) isCorrect = false;
            return isCorrect;
        }

        static void consWrite(string value)
        {
            Console.WriteLine(value);
        }
        static string consRead()
        {
            return Console.ReadLine();
        }

        static void EnterFavColors(int num, out string[] colors)
        {
            colors = new string[num];
            for (int i = 0; i < colors.Length; i++)
            {
                consWrite("Введите любимый цвет №" + (i + 1));
                colors[i] = consRead();
                Console.Clear();
            }
        }
        static string[] EnterPetsNames(int num)
        {
            string[] petsNames = new string[num];
            for (int i = 0; i < petsNames.Length; i++)
            {
                consWrite("Введите кличку питомца №" + (i + 1));
                petsNames[i] = consRead();
                Console.Clear();
            }
            return petsNames;
        }

        static void Main(string[] args)
        {
            FillUserQuestionnaire();




        }

    }
}