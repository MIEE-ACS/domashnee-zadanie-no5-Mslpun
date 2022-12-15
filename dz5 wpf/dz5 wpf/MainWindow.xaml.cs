using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dz5_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
                string h = "" + Hour;
                string m = "" + Minute;
                string s = "" + Second;
                if (Hour < 10)
                    h = "0" + Hour;
                if(Minute < 10)
                    m = "0" + Minute;
                if(Second < 10)
                    s = "0" + Second;

                return h + ":" + m + ":" + s;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            tb2.IsReadOnly = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int h = 0;
            string g = tb1.Text;
            var myTime = new MyDateTime();
            var newTimeArray = tb1.Text.Split(':'); // возможен null
            // Можно все проверить на корректность через TryParse
            for(int i = 0;i < g.Length; i++)
            {
                if (g[i] == ':')
                {
                    h++;
                }
            }
            if (h != 2)
            {
                MessageBox.Show("Ошибка ввода времени.");
            }
            else
            {
                if (int.TryParse(newTimeArray[0], out var hour) == true)
                { hour = Int32.Parse(newTimeArray[0]); }
                else
                { MessageBox.Show("Ошибка ввода времени. Заменим часы на 0."); hour = 0; }
                if (int.TryParse(newTimeArray[1], out var minute) == true)
                { minute = Int32.Parse(newTimeArray[1]); }
                else
                { MessageBox.Show("Ошибка ввода времени. Заменим минуты на 0."); minute = 0; }
                if (int.TryParse(newTimeArray[2], out var second) == true)
                { second = Int32.Parse(newTimeArray[2]); }
                else
                { MessageBox.Show("Ошибка ввода времени. Заменим секунды на 0."); second = 0; }
                if (hour <= 24 & minute <= 59 & second <= 59)
                {
                    myTime.SetTime(hour, minute, second);
                    MessageBox.Show("Записал");
                }
                else
                {
                    MessageBox.Show(" Должно быть так. Часы <= 24 Минуты <= 59 Секунды <= 59.");
                }
                tb2.Text = myTime.ShowTime();
            }
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void rb1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rb3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void tb2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var myTime = new MyDateTime();
            var newTimeArray = tb2.Text.Split(':');
            string h = tb3.Text;
            var hour = Int32.Parse(newTimeArray[0]);
            var minute = Int32.Parse(newTimeArray[1]);
            var second = Int32.Parse(newTimeArray[2]);
            if (int.TryParse(h, out int hh) == true)
            {
                hh = Int32.Parse(h);
            }
            else
            {
                MessageBox.Show("Ошибка ввода времени. Нельзя увеличить часы."); hour = 0;
            }
            if (rb1.IsChecked == true)
            {
                hour = hour + hh;
                MessageBox.Show(hour.ToString());
                myTime.SetHour(hour);
            }
            else if (rb2.IsChecked == true)
            {
                minute = minute + hh;
                myTime.SetMinute(minute);
            }
            else if (rb3.IsChecked == true)
            {
                second = second + hh;
                myTime.SetSecond(second);
            }
            else
            {
                MessageBox.Show("Вы не выбрали что увеличить.)");
            }
            if (hour <= 24 & minute <= 59 & second <= 59)
            {
                myTime.SetTime(hour, minute, second);
                MessageBox.Show("Записал");
            }
            else
            {
                MessageBox.Show(" Должно быть так. Часы <= 24 Минуты <= 59 Секунды <= 59.");
                myTime.SetTime(0, 0, 0);
            }
            tb2.Text = myTime.ShowTime();
        }
    }
}
