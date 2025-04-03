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

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileManager fm;
        int si;
        public MainWindow()
        {
            InitializeComponent();
            fm = new FileManager("data.txt");
            start();
        }
        List<Cars> all;
        void start()
        {
            all = fm.ReadFile();
            everything.Children.Clear();
            foreach(Cars item in all)
            {
                Label onelabel = new Label() { Content = item.Model, FontSize = 20, Tag = item };
                onelabel.MouseLeftButtonUp += CarClick;
                onelabel.MouseRightButtonUp += EditClick;
                everything.Children.Add(onelabel);
            }
        }
        void masik()
        {
            List<epitoanyag> asd = new List<epitoanyag>();
            asd.Add(new fa {nev = "Tölgy Fa", kemenyseg= 5f, suly = 30.25, ar=54900, anyag = "Tölgy"});
            asd.Add(new vas { vtipus = "Rozsdamentes Acél", suruseg = 5f, ar = 249000, suly = 2400, nev = "BMW" });
            asd.Add(new tegla { ttipus = "Piros Tégla", nev = "Tégla", ar=24000, suly=500, szin="Piros" });

            //foreach (epitoanyag item in asd)
            //{
            //    if (item is fa)
            //    {

            //        MessageBox.Show((item as fa).anyag);
            //    }
            //    else if(item is vas){
            //        MessageBox.Show((item as vas).vtipus);
            //    }
            //    else if(item is tegla)
            //    {
            //        MessageBox.Show((item as tegla).ttipus);
            //    }
            //    item.ar += 50;
            //}

            List<object> l = new List<object>();
            l.Add(10);
            l.Add("Kolbasz");
            l.Add(true);
            l.Add('c');
            l.Add(55.555);
            l.Add(new TextBox());
            l.Add(new Label() { Content = "kolbasz finom" });
            foreach (object item in l)
            {

            }
        }
        void EditClick(object s, EventArgs e)
        {
            Label ol = s as Label;
            Cars oc = ol.Tag as Cars;
            makerInput.Text = oc.Manufacturer;
            ModelInput.Text = oc.Model;
            PowerInput.Text = oc.Power.ToString();
            WeightInput.Text = oc.Weight.ToString();
            si = everything.Children.IndexOf(ol);
            Editbtn.IsEnabled = true;
        }
        void CarClick(object s, EventArgs e)
        {
            Label ol = s as Label;
            Cars oc = ol.Tag as Cars;
            MessageBox.Show($"{oc.Manufacturer}, Modell: {oc.Model}, Teljesítmény: {oc.Power}, Súly: {oc.Weight}");
        }
        void CreateEvent(object s, EventArgs e)
        {
            if (Editbtn.IsEnabled)
            {
                Editbtn.IsEnabled = false;
                makerInput.Text = "";
                ModelInput.Text = "";
                PowerInput.Text = "";
                WeightInput.Text = "";
                return;
            }
            string manufacturer = makerInput.Text;
            string model = ModelInput.Text;
            int power = -1;
            int weight = -1;
            if (!checkeverything(manufacturer, model, ref power, ref weight)) return;
            Cars onecar = new Cars(manufacturer, model, power, weight);
            fm.WriteOneLine(onecar);
            start();
        }
        bool checkeverything(string manufacturer, string model,ref int power,ref int weight)
        {
            string powerstring = PowerInput.Text;
            string weightstring = WeightInput.Text;


            if (manufacturer.Length < 2)
            {
                MessageBox.Show("Kérlek helyesen add meg a gyártó nevét!", "Sikertelen", MessageBoxButton.OKCancel);
                return false;
            }
            if (model.Length < 2)
            {
                MessageBox.Show("Kérlek helyesen add meg a modellt!", "Sikertelen", MessageBoxButton.OKCancel);
                return false;
            }
            if (powerstring.Length < 1)
            {
                MessageBox.Show("Kérlek helyesen add meg a teljesítményt!", "Sikertelen", MessageBoxButton.OKCancel);
                return false;
            }
            if (!int.TryParse(powerstring, out power))
            {
                MessageBox.Show("A teljesítménynek számnak kell lenni", "Sikertelen", MessageBoxButton.OKCancel);
                return false;
            }
            if (weightstring.Length < 3)
            {
                MessageBox.Show("Add meg helyesen az autó súlyát", "Sikertelen", MessageBoxButton.OKCancel);
                return false;
            }
            if (!int.TryParse(weightstring, out weight))
            {
                MessageBox.Show("A súlynak számnak kell lenni", "Sikertelen", MessageBoxButton.OKCancel);
                return false;
            }
            return true;
        }
        void EditEvent(object s, EventArgs e)
        {
            all[si].Manufacturer = makerInput.Text;
            all[si].Model = ModelInput.Text;
            all[si].Power = int.Parse(PowerInput.Text);
            all[si].Weight = int.Parse(WeightInput.Text);
            fm.we(all);
            start();
        }
    }
}
