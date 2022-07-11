

abstract class phoneBook
{
    public string phoneNumber { get; set; }
    public string address { get; set; }
    public string surname { get; set; }
    public string name { get; set; }
    public string fax { get; set; }
    public string birtdayDate { get; set; }
    public abstract void ShowInfo();

}

class person : phoneBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("Фамилия: "+surname);
        Console.WriteLine("Адресс: "+address);
        Console.WriteLine("Номер телефона: "+phoneNumber);
    }
}

class organization : phoneBook
{
    public override void ShowInfo()
    {
        Console.WriteLine("Фамилия: " + name);
        Console.WriteLine("Адресс: " + address);
        Console.WriteLine("Номер телефона: " + phoneNumber);
        Console.WriteLine("Факс: " + fax);
        Console.WriteLine("Контактное лицо: " +surname);
        
    }

}

class friend : phoneBook
{
    
    public void setBirtdayDate(string birtdayDate)
    {
        this.birtdayDate = birtdayDate;
    }
    public override void ShowInfo()
    {
        Console.WriteLine("Фамилия: " + surname);
        Console.WriteLine("Адресс: " + address);
        Console.WriteLine("Номер телефона: " + phoneNumber);
        Console.WriteLine("Дата рождения: "+birtdayDate);
    }

}



class Program {

    static void printPhoneBook(phoneBook[] pb)
    {
        Console.WriteLine("Телефонная книга\n--------------------\n");
        foreach (var phonebook in pb)
        {
            phonebook.ShowInfo();
            Console.WriteLine("--------------------\n");
        }
        return;
    }

    static void printPhoneBook(phoneBook[] pb, string surname)
    {
        Console.WriteLine("Телефонная книга\n--------------------\n");
        foreach (var phonebook in pb)
        {
            if (phonebook.surname == surname)
            {
                phonebook.ShowInfo();
                Console.WriteLine("--------------------\n");
            }
        }
        return;
    }

    public static void Main(string[] args)
    {
        string[] surnames = new string[] { "Грибоедов", "Пушкин", "Заболоцкий", "Булгаков", "Платонов","Лермонтов","Уэлс","Васильев","Андреев" };
        string[] names = new string[] { "Стальплав", "Кафе мороженное", "МойкаАвто","Salon svyazi","Отелье мотелье","Нефтянка","Гудронстрой" };
        string[] streetNames = new string[] { "Советская", "Карла Маркса", "Комсомольская","Чичерина","Мичуринская" };
        Random rnd = new Random();
        phoneBook[] pbook = new phoneBook[15];
        for (int i = 0; i < pbook.Length; i++)
        {
            for (int j = 0; j < 5; j++,i++)
            {
                pbook[i] = new person();
                pbook[i].surname = surnames[rnd.Next(surnames.Length)];
                pbook[i].address = ("ул. " + streetNames[rnd.Next(streetNames.Length)] + " д. " + rnd.Next(50).ToString());
                pbook[i].phoneNumber=rnd.Next(100000,999999).ToString();
                
            }

            for (int j = 0; j < 5; j++,i++)
            {
                pbook[i] = new organization();
                pbook[i].name=names[rnd.Next(0,names.Length)];
                pbook[i].address = ("ул. " + streetNames[rnd.Next(streetNames.Length)] + " д. " + rnd.Next(50).ToString());
                pbook[i].phoneNumber = rnd.Next(100000, 999999).ToString();
                pbook[i].fax = rnd.Next(999999).ToString();
                pbook[i].surname = surnames[rnd.Next(surnames.Length)];

            }

            for (int j = 0; j < 5; j++,i++)
            {
                pbook[i] = new friend();
                pbook[i].surname = surnames[rnd.Next(surnames.Length)];
                pbook[i].address = ("ул. " + streetNames[rnd.Next(streetNames.Length)] + " д. " + rnd.Next(50).ToString());
                pbook[i].phoneNumber = rnd.Next(100000, 999999).ToString();
                pbook[i].birtdayDate = rnd.Next(30).ToString()+"."+rnd.Next(12).ToString()+"."+rnd.Next(1950,2000).ToString();
            }
        }
        string c = "";
        printPhoneBook(pbook);
        while (true)
        {
            Console.WriteLine("Введите фамилию для поиска:\nДля выхода введите 'ex'\nЧтобы вывести всё — 'all'");
            c = Console.ReadLine();
            if (c == "ex")
            {
                return;
            }
            if (c == "all")
            {
                printPhoneBook(pbook);
                continue;
            }
            Console.Clear();
            printPhoneBook(pbook,c);
        }
    }
}
