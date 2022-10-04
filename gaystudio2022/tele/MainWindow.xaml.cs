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



namespace tele
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pass;

        


        public MainWindow()
        {
            InitializeComponent();

           
        }


        public string CreateCode(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }

            return res.ToString();
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox1.Text.Length >= 10){ //дописать тут условие: если этот номер есть в базе данных
                textBox2.IsReadOnly = false;
                button2.IsEnabled = true;
            }

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            //1 ОКНО С КОДОМ
            pass = CreateCode(4);

            

            if (textBox2.Text.Length == 8) {  
               
                textBox3.IsReadOnly = false;
               
                MessageBox.Show(pass);
                
            }

            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {
            //5 сек для отсталых
            
            
             load_image.IsEnabled = false;
            
             var fooTimer = new System.Timers.Timer(5000);


            
                fooTimer.Elapsed += (fooTimer_s, fooTimer_e) =>
                {
                    
                    Dispatcher.Invoke(() =>
                    {
                        if (textBox3.Text.Length < 8) { 
                            load_image.IsEnabled = true;
                            fooTimer.Dispose();
                        }
                    });
                    
                };
                fooTimer.Start();


            load_image.IsEnabled = false;


        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //clear textboxes

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            pass = CreateCode(2);
            MessageBox.Show(pass);
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //we should check wheather or not the text, that users put into the textbox3 is similar to the generated code (проверка условия кода) 
            if (textBox3.Text == pass){
                MessageBox.Show("дОСТУП РАЗРЕШЕН");
            }
            else
            {
                MessageBox.Show("КОД НЕПРАВИЛЬНЫЙ ВЫЙДИ ОТСЮДА");
            }
        }

        
    }
}
//подключть базу данных и отредактировать остатки кода 
// прочитать телеграмм  Кк подключить базу данных Загрузить на гитхаб
