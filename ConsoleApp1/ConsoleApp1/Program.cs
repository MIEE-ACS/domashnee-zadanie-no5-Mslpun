public class MyDateTime
{
    int Hour;
    int Minute;
    int Second;

    public void SetHour(int hour)
    {
        Hour = hour;
    }

    public void SetMinute(int minute)
    {
        Minute = minute;
    }

    public void SetSecond(int second)
    {
        Second = second;
    }

    public void SetTime(int hour, int minute, int second)
    {
        SetHour(hour);
        SetMinute(minute);
        SetSecond(second);
    }

    public string ShowTime()
    {
        return "Сейчас время: " + Hour + ":" + Minute + ":" + Second;
    }
}
internal class Program
{

    private static void Main(string[] args)
    {
        string s = "";
        Console.WriteLine("Программа 'Время'");
        var myTime = new MyDateTime();
        while (s != "0")
        {
            Console.WriteLine();
            Console.WriteLine("1. Вывести текущее время");
            Console.WriteLine("2. Ввод времени");
            Console.WriteLine("3. Показать время");
            Console.WriteLine("0. Выход");
            Console.Write("Введите цифру: ");

            s = Console.ReadLine();
            if (s != "1" && s != "2" && s != "3" && s != "0")
            {
                Console.Write("Неправильный ввод");
                continue;
            }

            Console.WriteLine();

            int n = int.Parse(s);
            switch (n)
            {
                case 1:
                    String current_time_str = DateTime.Now.ToString("HH:mm:ss");
                    Console.WriteLine("Текущее время " + current_time_str);
                    break;
                case 2:
                    Console.WriteLine("Введите новое время в формате hh:mm:ss");
                    var newTime = Console.ReadLine();
                    var newTimeArray = newTime.Split(':'); // возможен null

                    // Можно все проверить на корректность через TryParse
                    var hour = Int32.Parse(newTimeArray[0]);
                    var minute = Int32.Parse(newTimeArray[1]);
                    var second = Int32.Parse(newTimeArray[2]);

                    if (hour <= 24 & minute <= 59 & second <= 59)
                    {
                        myTime.SetTime(hour, minute, second);
                        Console.WriteLine("Записал");
                    }
                    else
                        Console.WriteLine("Такого времени не бывает!");

                    break;
                case 3:
                    Console.WriteLine(myTime.ShowTime());
                    break;
            }
        }
    }
}