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
    /// Логика взаимодействия для Arenda.xaml
    /// </summary>
    public partial class Arenda : Page
    {
        public Arenda()
        {
            InitializeComponent();
            GridUchet.ItemsSource = AppData.ModelHelper.entities.JilFond.ToList();
            AppData.ModelHelper.entities = new Models.AcropolEntities();

            CmbKomnat.SelectedValuePath = "id";
            CmbKomnat.DisplayMemberPath = "Kolichestvo";
            CmbKomnat.ItemsSource = AppData.ModelHelper.entities.Komnati.ToList();

            CmbSanuzl.SelectedValuePath = "id";
            CmbSanuzl.DisplayMemberPath = "Kolichestvo";
            CmbSanuzl.ItemsSource = AppData.ModelHelper.entities.Sanuzli.ToList();

            CmbKond.SelectedValuePath = "id";
            CmbKond.DisplayMemberPath = "Nalichie";
            CmbKond.ItemsSource = AppData.ModelHelper.entities.Kondicioner.ToList();

            CmbFiltr.SelectedValuePath = "id";
            CmbFiltr.DisplayMemberPath = "Kolichestvo";
            CmbFiltr.ItemsSource = AppData.ModelHelper.entities.Komnati.ToList();




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(TbEtagi.Text))
                mes += "Введите колчиество этажей\n";
            if (string.IsNullOrWhiteSpace(DtPick.Text))
                mes += "Выберите дату поставки\n";
            if (string.IsNullOrWhiteSpace(CmbKomnat.Text))
                mes += "Выберите количество комнат\n";
            if (string.IsNullOrWhiteSpace(CmbSanuzl.Text))
                mes += "Выберите количество санузлов\n";
            if (string.IsNullOrWhiteSpace(CmbKond.Text))
                mes += " Выберите наличие кондиционера\n";
            if (string.IsNullOrWhiteSpace(TbAdres.Text))
                mes += "Введите адресь\n";
            //if (string.IsNullOrWhiteSpace(TbPrice2.Text))
            //    mes += "Введите арендную плату\n";
            //if (string.IsNullOrWhiteSpace(TbPrice3.Text))
            //    mes += "Выберите кол-во этажей\n";

            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Models.JilFond jilFond = new Models.JilFond()
            {
                Etaj = TbEtagi.Text,
                GodPostroyki = DtPick.SelectedDate,
                Komnati = CmbKomnat.SelectedItem as Models.Komnati,
                Sanuzli = CmbSanuzl.SelectedItem as Models.Sanuzli,
                Kondicioner = CmbKond.SelectedItem as Models.Kondicioner,
                Adress = TbAdres.Text,

                //StoimostPoKadastru = TbPrice1.Text,
                //RinochStoimost = TbPrice2.Text,
                //ArendnayaStoimost = TbPrice3.Text
            };

            AppData.ModelHelper.entities.JilFond.Add(jilFond);
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Добавлено");
            TbEtagi.Text = "";
            DtPick.Text = "";
            CmbKomnat.Text = "";
            CmbSanuzl.Text = "";
            CmbKond.Text = "";
            TbAdres.Text = "";
            //TbPrice1.Text = "";
            //TbPrice2.Text = "";
            //TbPrice3.Text = "";
            GridUchet.ItemsSource = AppData.ModelHelper.entities.JilFond.ToList();


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //AppData.ModelHelper.entities.JilFond.Remove();
            AppData.ModelHelper.entities.SaveChanges();
            MessageBox.Show("Удалено");
            GridUchet.ItemsSource = AppData.ModelHelper.entities.JilFond.ToList();

        }

        private void CbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectSotr = Convert.ToInt32(CmbFiltr.SelectedValue);
            GridUchet.ItemsSource = AppData.ModelHelper.entities.JilFond.Where(i => i.idKolKomnat == SelectSotr).ToList();

        }
    }
}
