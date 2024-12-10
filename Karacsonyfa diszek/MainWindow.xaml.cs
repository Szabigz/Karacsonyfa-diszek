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

namespace Karacsonyfa_diszek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Test();
        }
        void Test()
        {
            Disz disz = new Disz() { name = "Kolbasz", price = 2000, stock = 50000};
            CreateStoreOItem(disz);
            CreateStoreOItem(disz);

        }
        void CreateStoreOItem(Disz oneDisz)
        {
            Border oneBorder = new Border();
            oneBorder.Background = new SolidColorBrush(Colors.CadetBlue);
            oneBorder.CornerRadius = new CornerRadius(15);
            oneBorder.Margin = new Thickness(0, 0, 5, 0);
            oneBorder.Padding = new Thickness(10);
            Store.Children.Add(oneBorder);
            Grid oneGrid = new Grid();
            oneBorder.Child = oneGrid;
            RowDefinition firstRow = new RowDefinition();
            RowDefinition secondRow = new RowDefinition();
            RowDefinition thirdRow = new RowDefinition();
            RowDefinition fourthRow = new RowDefinition();
            oneGrid.RowDefinitions.Add(firstRow);
            oneGrid.RowDefinitions.Add(secondRow);
            oneGrid.RowDefinitions.Add(thirdRow);
            oneGrid.RowDefinitions.Add(fourthRow);
            TextBlock name = new TextBlock();
            TextBlock price = new TextBlock();
            Grid count = new Grid();
            Button buy = new Button();
            oneGrid.Children.Add(name);
            oneGrid.Children.Add(price);
            oneGrid.Children.Add(count);
            oneGrid.Children.Add(buy);
            Grid.SetRow(price, 1);
            Grid.SetRow(count, 2);
            Grid.SetRow(buy, 3);

            TextBlock countText = new TextBlock();
            TextBlock countBox = new TextBlock();
            count.Children.Add(countText);
            count.Children.Add(countBox);

            ColumnDefinition gridOne = new ColumnDefinition();
            ColumnDefinition gridTwo = new ColumnDefinition();

            count.ColumnDefinitions.Add(gridOne);
            count.ColumnDefinitions.Add(gridTwo);

            Grid.SetColumn(countBox, 1);

            name.Text = "Disz neve: "+oneDisz.name;
            price.Text = "Ar: " + oneDisz.price;
            countText.Text = "Darabszam:";
            countBox.Text= "1";
            buy.Content ="Vasarlas";

            buy.Click += (s, e) => {
                CreateCartOItem(oneDisz,countBox.Text);
            };

            name.TextAlignment = TextAlignment.Center;
            price.TextAlignment = TextAlignment.Center;
            countText.TextAlignment = TextAlignment.Center;
            countBox.TextAlignment = TextAlignment.Center;

            countBox.Margin = new Thickness(5, 0, 5, 5);
        }
        void CreateCartOItem(Disz oneDisz, string num)
        {
            Border oneBorder = new Border();
            oneBorder.Background = new SolidColorBrush(Colors.CadetBlue);
            oneBorder.CornerRadius = new CornerRadius(15);
            oneBorder.Margin = new Thickness(0, 0, 5, 0);
            oneBorder.Padding = new Thickness(10);
            Cart.Children.Add(oneBorder);
            Grid oneGrid = new Grid();
            oneBorder.Child = oneGrid;
            RowDefinition firstRow = new RowDefinition();
            RowDefinition secondRow = new RowDefinition();
            RowDefinition thirdRow = new RowDefinition();
            RowDefinition fourthRow = new RowDefinition();
            RowDefinition fifthRow = new RowDefinition();
            oneGrid.RowDefinitions.Add(firstRow);
            oneGrid.RowDefinitions.Add(secondRow);
            oneGrid.RowDefinitions.Add(thirdRow);
            oneGrid.RowDefinitions.Add(fourthRow);
            oneGrid.RowDefinitions.Add(fifthRow);
            TextBlock name = new TextBlock();
            TextBlock price = new TextBlock();  
            Grid count = new Grid();
            Button more = new Button();
            Button less = new Button();
            oneGrid.Children.Add(name);
            oneGrid.Children.Add(price);
            oneGrid.Children.Add(count);
            oneGrid.Children.Add(more);
            oneGrid.Children.Add(less);
            Grid.SetRow(price, 1);
            Grid.SetRow(count, 2);
            Grid.SetRow(more, 3);
            Grid.SetRow(less, 4);

            TextBlock countText = new TextBlock();
            TextBlock countBox = new TextBlock();
            count.Children.Add(countText);
            count.Children.Add(countBox);

            ColumnDefinition gridOne = new ColumnDefinition();
            ColumnDefinition gridTwo = new ColumnDefinition();

            count.ColumnDefinitions.Add(gridOne);
            count.ColumnDefinitions.Add(gridTwo);

            Grid.SetColumn(countBox, 1);

            name.Text = "Disz neve: " + oneDisz.name;
            price.Text = "Ar: " + oneDisz.price;
            countText.Text = "Darabszam:";
            countBox.Text = num;
            more.Content = "Tobb";
            less.Content = "Kevesebb";

            more.Click += (s, e) => {
                int currentValue = int.Parse(countBox.Text);
                currentValue++;
                countBox.Text = currentValue.ToString();
            };
            less.Click += (s, e) => {
                int currentValue = int.Parse(countBox.Text);
                currentValue--;
                if (currentValue<1)
                {
                    Cart.Children.Remove(oneBorder);
                }
                countBox.Text = currentValue.ToString();
            };
            name.TextAlignment = TextAlignment.Center;
            price.TextAlignment = TextAlignment.Center;
            countText.TextAlignment = TextAlignment.Center;
            countBox.TextAlignment = TextAlignment.Center;

            countBox.Margin = new Thickness(5, 0, 5, 5);
        }

    }
}
