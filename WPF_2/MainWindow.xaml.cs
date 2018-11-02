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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool CLock_flag = true;
        private int Text_Lenght = 105;
        private int Up_Text_Lenght = 90;
        private int Difficulty_Level = 1;
        private int fails = 0;
        private bool BSpace_flag = true;
        private bool Correct_flag = true;
        private DateTime dateTime;
        Random random;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            Text_To_Print.Text = null;
            Difficulty_Range.IsEnabled = false;
            Shift_CBox.IsEnabled = false;
            Speed.Text = $"Speed: {0} chars/min";
            fails = 0;
            Fails.Text = $"Fails: {fails}";
            Stop_Button.IsEnabled = true;
            Start_Button.IsEnabled = false;
            Text_Printed.IsReadOnly = false;
            dateTime = DateTime.Now;
            KB_Trainer();
            Text_Printed.Text = null;
            Text_Printed.Focus();
        }

        private void Stop_Button_Click(object sender, RoutedEventArgs e)
        {
            Stop();
        }
        private void Stop()
        {
            Difficulty_Range.IsEnabled = true;
            Shift_CBox.IsEnabled = true;
            Stop_Button.IsEnabled = false;
            Start_Button.IsEnabled = true;
            Text_Printed.IsReadOnly = true;
        }
        private void Difficulty_Range_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Difficulty_Level = (int)Difficulty_Range.Value;
            Text_Block_Slognost.Text = $"Difficulty: {Difficulty_Level.ToString()}";
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            foreach (var i in grid_global.Children)
            {
                if (i is Grid)
                {
                    foreach (var j in (i as Grid).Children)
                    {
                        if (j is Grid)
                        {
                            foreach (var item in (j as Grid).Children)
                            {
                                if (item is Button)
                                {
                                    if ((item as Button).Name == e.Key.ToString())
                                    {
                                        (item as Button).Opacity = 0.5;
                                        if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                        {
                                            To_Upper_Numbers();
                                            if (CLock_flag) {To_Upper();}
                                            else {To_Lower();}
                                        }
                                        else if (e.Key.ToString() == "Capital")
                                        {
                                            if (CLock_flag) {To_Upper(); CLock_flag = false;}
                                            else {To_Lower(); CLock_flag = true;}
                                        }
                                        else if (e.Key.ToString() == "Back")
                                        {
                                            BSpace_flag = false;
                                        }
                                        else {BSpace_flag = true;}
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            foreach (var i in grid_global.Children)
            {
                if (i is Grid)
                {
                    foreach (var j in (i as Grid).Children)
                    {
                        if (j is Grid)
                        {
                            foreach (var item in (j as Grid).Children)
                            {
                                if (item is Button)
                                {
                                    if ((item as Button).Name == e.Key.ToString())
                                    {
                                        (item as Button).Opacity = 1;
                                        if (e.Key.ToString() == "LeftShift" || e.Key.ToString() == "RightShift")
                                        {
                                            To_Lower_Numbers();
                                            if (!CLock_flag) {To_Upper();}
                                            else {To_Lower();}
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void To_Upper()
        {
            Q.Content = "Q";
            W.Content = "W";
            E.Content = "E";
            R.Content = "R";
            T.Content = "T";
            Y.Content = "Y";
            U.Content = "U";
            I.Content = "I";
            O.Content = "O";
            P.Content = "P";
            A.Content = "A";
            S.Content = "S";
            D.Content = "D";
            F.Content = "F";
            G.Content = "G";
            H.Content = "H";
            J.Content = "J";
            K.Content = "K";
            L.Content = "L";
            Z.Content = "Z";
            X.Content = "X";
            C.Content = "C";
            V.Content = "V";
            B.Content = "B";
            N.Content = "N";
            M.Content = "M";
        }

        private void To_Lower()
        {
            Q.Content = "q";
            W.Content = "w";
            E.Content = "e";
            R.Content = "r";
            T.Content = "t";
            Y.Content = "y";
            U.Content = "u";
            I.Content = "i";
            O.Content = "o";
            P.Content = "p";
            A.Content = "a";
            S.Content = "s";
            D.Content = "d";
            F.Content = "f";
            G.Content = "g";
            H.Content = "h";
            J.Content = "j";
            K.Content = "k";
            L.Content = "l";
            Z.Content = "z";
            X.Content = "x";
            C.Content = "c";
            V.Content = "v";
            B.Content = "b";
            N.Content = "n";
            M.Content = "m";
        }

        private void To_Upper_Numbers()
        {
            Oem3.Content = "~";
            D1.Content = "!";
            D2.Content = "@";
            D3.Content = "#";
            D4.Content = "$";
            D5.Content = "%";
            D6.Content = "^";
            D7.Content = "&";
            D8.Content = "*";
            D9.Content = "(";
            D0.Content = ")";
            OemMinus.Content = "_";
            OemPlus.Content = "+";
            OemOpenBrackets.Content = "{";
            Oem6.Content = "}";
            Oem5.Content = "|";
            Oem1.Content = ":";
            OemQuotes.Content = "\"";
            OemComma.Content = "<";
            OemPeriod.Content = ">";
            OemQuestion.Content = "?";
        }
        private void To_Lower_Numbers()
        {
            Oem3.Content = "`";
            D1.Content = "1";
            D2.Content = "2";
            D3.Content = "3";
            D4.Content = "4";
            D5.Content = "5";
            D6.Content = "6";
            D7.Content = "7";
            D8.Content = "8";
            D9.Content = "9";
            D0.Content = "0";
            OemMinus.Content = "-";
            OemPlus.Content = "=";
            OemOpenBrackets.Content = "[";
            Oem6.Content = "]";
            Oem5.Content = "\\";
            Oem1.Content = ";";
            OemQuotes.Content = "'";
            OemComma.Content = ",";
            OemPeriod.Content = ".";
            OemQuestion.Content = "/";
        }

        private void KB_Trainer()
        {
            random = new Random();
            List<char> Lower_Symbols = new List<char> { '`','1','2','q','a','z','9','i','k',',',' ','3','w','s','x',
            '0','o','l','.',' ','4','e','d','c','-','=','p','[',']','\\',';','\'','/',' ','5','6','r','t','f','g','v','b',
            ' ','7','8','y','u','h','j','n','m',' '};
            List<char> Upper_Symbols = new List<char> { '~','!','@','Q','A','Z','(','I','K','<',' ','#','W','S','X',
            ')','O','L','>',' ','$','E','D','C','_','+','P','{','}','|',':','\"','?',' ','%','^','R','T','F','G','V','B',
            ' ','&','*','Y','U','H','J','N','M',' '};
            List<char> Rand_String = new List<char> { };
            if (Difficulty_Level == 1)
            {
                for (int i = 0; i < 11; i++)
                {
                    Rand_String.Add(Lower_Symbols[i]);
                }
                if (Shift_CBox.IsChecked == true)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        Rand_String.Add(Upper_Symbols[i]);
                    }
                }
            }
            else if (Difficulty_Level == 2)
            {
                for (int i = 0; i < 20; i++)
                {
                    Rand_String.Add(Lower_Symbols[i]);
                }
                if (Shift_CBox.IsChecked == true)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        Rand_String.Add(Upper_Symbols[i]);
                    }
                }
            }
            else if (Difficulty_Level == 3)
            {
                for (int i = 0; i < 34; i++)
                {
                    Rand_String.Add(Lower_Symbols[i]);
                }
                if (Shift_CBox.IsChecked == true)
                {
                    for (int i = 0; i < 34; i++)
                    {
                        Rand_String.Add(Upper_Symbols[i]);
                    }
                }
            }
            else if (Difficulty_Level == 4)
            {
                for (int i = 0; i < 43; i++)
                {
                    Rand_String.Add(Lower_Symbols[i]);
                }
                if (Shift_CBox.IsChecked == true)
                {
                    for (int i = 0; i < 43; i++)
                    {
                        Rand_String.Add(Upper_Symbols[i]);
                    }
                }
            }
            else if (Difficulty_Level == 5)
            {
                for (int i = 0; i < 52; i++)
                {
                    Rand_String.Add(Lower_Symbols[i]);
                }
                if (Shift_CBox.IsChecked == true)
                {
                    for (int i = 0; i < 52; i++)
                    {
                        Rand_String.Add(Upper_Symbols[i]);
                    }
                }
            }
            String str = "";
            if (Shift_CBox.IsChecked == true)
            {
                for (int i = 0; i < Up_Text_Lenght; i++)
                {
                    str += Rand_String[random.Next(Rand_String.Count)];
                }
            }
            else
            {
                for (int i = 0; i < Text_Lenght; i++)
                {
                    str += Rand_String[random.Next(Rand_String.Count)];
                }
            }
            Text_To_Print.Text = str;
        }
        private void Text_Printed_TextChanged(object sender, TextChangedEventArgs e)
        {
            int start = 0;
            int Text_Lengt = Text_Printed.Text.Length;
            String str = Text_To_Print.Text.Substring(start, Text_Lengt);
            if (Text_Printed.Text.Equals(str))
            {
                if (BSpace_flag)
                {
                    Speed.Text = "Speed: " + Math.Round(Text_Printed.Text.Length / (DateTime.Now - dateTime).TotalMinutes).ToString() + " chars/min";
                }
                Text_Printed.Foreground = new SolidColorBrush(Colors.Black);
                Correct_flag = true;
            }
            else
            {
                if (BSpace_flag) {fails++;}
                Text_Printed.Foreground = new SolidColorBrush(Colors.Red);
                Fails.Text = $"Fails: {fails}";
                Correct_flag = false;
            }

            if (!Correct_flag || Text_To_Print.Text.Length != Text_Printed.Text.Length) return;
            Speed.Text = "Speed: " + Math.Round(Text_Printed.Text.Length / (DateTime.Now - dateTime).TotalMinutes).ToString() + " chars/min";
            MessageBox.Show("Вы - молодец!!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            Stop();
        }
    }
}
