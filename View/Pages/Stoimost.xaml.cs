using Akropol.Models;
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

namespace Akropol.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для Stoimost.xaml
    /// </summary>
    public partial class Stoimost : Page
    {
        public Stoimost()
        {
            InitializeComponent();
            GridUchet.ItemsSource = AppData.ModelHelper.entities.JilFond.ToList();
            AppData.ModelHelper.entities = new Models.AcropolEntities();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbPrice1.Text))
                mes += "Введите рыночную стоимость\n";
            if (string.IsNullOrWhiteSpace(TbPrice2.Text))
                mes += "Введите арендную плату\n";
            if (string.IsNullOrWhiteSpace(TbPrice3.Text))
                mes += "Выберите кол-во этажей\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Models.JilFond jilFond = new Models.JilFond()
            {
                StoimostPoKadastru = TbPrice1.Text,
                RinochStoimost = TbPrice2.Text,
                ArendnayaStoimost = TbPrice3.Text
            };

            AppData.ModelHelper.entities.JilFond.Add(jilFond);
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Изменено");
            TbPrice1.Text = "";
            TbPrice2.Text = "";
            TbPrice3.Text = "";


        }

        private void BtnFiltr_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(DP1.Text))
                mes += "Выберите начало периода\n";
            if (string.IsNullOrWhiteSpace(DP2.Text))
                mes += "Выберите конец периода\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }
            var a = (DateTime)DP1.SelectedDate;
            var b = (DateTime)DP2.SelectedDate;

            var query = AppData.ModelHelper.entities.JilFond.Where(x => x.GodPostroyki >= a && x.GodPostroyki <= b);
            GridUchet.ItemsSource = query.ToList();

        }

        private void Sbros_Click(object sender, RoutedEventArgs e)
        {
            GridUchet.ItemsSource = AppData.ModelHelper.entities.JilFond.ToList();
            DP1.Text = "";
            DP2.Text = "";
        }
    }
}
