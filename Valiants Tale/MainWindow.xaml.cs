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
using Valiants_Tale.Resources.Controls;
using Valiants_Tale.Resources.Data;

namespace Valiants_Tale
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow ui;
        public MainWindow()
        {
            InitializeComponent();
            ui = this;

            Humanoid player = new Humanoid(50);
            player.Name = "Gracz";

            //player.Describe();
            //player.Describe(30);

            Humanoid a = new Humanoid(30);
            a.Name = "Mietek";
            Humanoid b = new Humanoid(30);
            b.Name = "Wiesiek";
            Humanoid c = new Humanoid(30);
            c.Name = "Bartek";
            Humanoid d = new Humanoid(30);
            d.Name = "Wojtek";

            VocalChat.AddMemory(d.CurrentHP.ToString() + "/"+ d.StatPage.GetStat(Statistics.Type.Health).ToString());

            d.ChangeHealthStatus(new DamageEventArgs(20, a, DamageEventArgs.DamageType.Astral, true, true, true));

            VocalChat.AddMemory(d.CurrentHP.ToString() + "/" + d.StatPage.GetStat(Statistics.Type.Health).ToString());

            Place Inn = new Place(5000, Place.Prefix.Inside, Place.Sturdiness.Sturdy, false);
            Inn.Name = "Oakheart Tavern";
            
            Place Table = new Place(50, Place.Prefix.At, Place.Sturdiness.Flimsy, true);
            Table.Name = "Table";

            Table.Enter(a);
            Table.Enter(b);
            Table.Enter(c);
            Inn.Enter(d);
            Inn.Enter(Table);

            Inn.DescribeContents();


            //create new equipable item that gives the player 150 hp when worn
            Item i = new Item("Hat", 0.1f, Unit.SizeEnum.Small, 150, Item.MaterialEnum.Stone);
            //Change the type to a hat
            i.equipType = Item.EquipType.Head;
            d.Equip(i);
            VocalChat.AddMemory(d.CurrentHP.ToString() + "/" + d.StatPage.GetStat(Statistics.Type.Health).ToString());

            d.Unequip(i.equipType);
            i.StatPage = new Statistics(300, 10, 5, 5, 5, 5, 5, 5);
            d.Equip(i);
            VocalChat.AddMemory(d.CurrentHP.ToString() + "/" + d.StatPage.GetStat(Statistics.Type.Health).ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionWindow a = new ActionWindow();
            a.Show();
            a.Activate();
        }
    }
}
