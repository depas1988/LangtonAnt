using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using System.Windows.Controls;
using LangtonAnt.DataModel;
using LangtonAnt.Interface;
using Color = LangtonAnt.DataModel.Color;

namespace LangtonAntUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    ///
    /// 
    public partial class MainWindow : Window
    {

        private Image antImage;
        private int _chessIndex=-1;
        private readonly IGame _game;
        private readonly IGamer _gamer;
        public MainWindow(IGame game, IGamer gamer)
        {
            _game = game;
            _gamer = gamer;
            
            InitializeComponent();
            
        }

        private void GridMain(int numberOfSquares)
        {
            if(_chessIndex>=0)
                MainGrid.Children.RemoveAt(_chessIndex);
            
            Grid myGrid = new Grid();
            myGrid.Width = MainGrid.ColumnDefinitions[0].Width.Value;
            myGrid.Height = MainGrid.RowDefinitions[0].Height.Value;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.ShowGridLines = true;

            for (int i = 0; i <= numberOfSquares; i++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
                myGrid.RowDefinitions.Add(new RowDefinition());
            }
            ;

            //ColumnDefinition colDef1 = new ColumnDefinition();
            //ColumnDefinition colDef2 = new ColumnDefinition();
            //ColumnDefinition colDef3 = new ColumnDefinition();
            //myGrid.ColumnDefinitions.Add(colDef1);
            //myGrid.ColumnDefinitions.Add(colDef2);
            //myGrid.ColumnDefinitions.Add(colDef3);

            // Define the Rows
            //RowDefinition rowDef1 = new RowDefinition();
            //RowDefinition rowDef2 = new RowDefinition();
            //RowDefinition rowDef3 = new RowDefinition();
            //RowDefinition rowDef4 = new RowDefinition();
            //myGrid.RowDefinitions.Add(rowDef1);
            //myGrid.RowDefinitions.Add(rowDef2);
            //myGrid.RowDefinitions.Add(rowDef3);
            //myGrid.RowDefinitions.Add(rowDef4);

            // Add the first text cell to the Grid
            TextBlock txt1 = new TextBlock();
            txt1.Text = "2005 Products Shipped";
            txt1.FontSize = 20;
            txt1.FontWeight = FontWeights.Bold;
            Grid.SetColumnSpan(txt1, 3);
            Grid.SetRow(txt1, 0);

            // Add the second text cell to the Grid
            TextBlock txt2 = new TextBlock();
            txt2.Text = "Quarter 1";
            txt2.FontSize = 12;
            txt2.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt2, 1);
            Grid.SetColumn(txt2, 0);

            // Add the third text cell to the Grid
            TextBlock txt3 = new TextBlock();
            txt3.Text = "Quarter 2";
            txt3.FontSize = 12;
            txt3.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt3, 1);
            Grid.SetColumn(txt3, 1);

            // Add the fourth text cell to the Grid
            TextBlock txt4 = new TextBlock();
            txt4.Text = "Quarter 3";
            txt4.FontSize = 12;
            txt4.FontWeight = FontWeights.Bold;
            Grid.SetRow(txt4, 1);
            Grid.SetColumn(txt4, 2);

            // Add the sixth text cell to the Grid
            TextBlock txt5 = new TextBlock();
            Double db1 = new Double();
            db1 = 50000;
            txt5.Text = db1.ToString();
            Grid.SetRow(txt5, 2);
            Grid.SetColumn(txt5, 0);

            // Add the seventh text cell to the Grid
            TextBlock txt6 = new TextBlock();
            Double db2 = new Double();
            db2 = 100000;
            txt6.Text = db2.ToString();
            Grid.SetRow(txt6, 2);
            Grid.SetColumn(txt6, 1);

            // Add the final text cell to the Grid
            antImage = CreateImage();

            SolidColorBrush solidBG = new SolidColorBrush(Colors.Aqua);
            Border borderBG = new Border();
            borderBG.Background = solidBG;


            Grid.SetRow(antImage, 1);
            Grid.SetColumn(antImage, 1);


            Grid.SetRow(borderBG, 2);
            Grid.SetColumn(borderBG, 2);

            // Total all Data and Span Three Columns
            TextBlock txt8 = new TextBlock();
            txt8.FontSize = 16;
            txt8.FontWeight = FontWeights.Bold;
            txt8.Text = "Total Units: " + (db1 + db2).ToString();
            //txt8
            //Grid.SetRow(txt8, 3,);
            //Grid.
            //Grid.SetColumnSpan(txt8, 3);
            ////Grid.SetRow();
            


            // Add the TextBlock elements to the Grid Children collection
            //myGrid.Children.Add(txt1);
            //myGrid.Children.Add(txt2);
            //myGrid.Children.Add(txt3);
            //myGrid.Children.Add(txt4);
            //myGrid.Children.Add(txt5);
            //myGrid.Children.Add(txt6);
            myGrid.Children.Add(antImage);
            myGrid.Children.Add(borderBG);

            // Add the Grid as the Content of the Parent Window Object
            
            
            _chessIndex=MainGrid.Children.Add(myGrid);
            this.Show();


            //    grid_Main.Height = 350;
            //    grid_Main.Width = 525;

            //    grid_Main.Background = Brushes.GreenYellow;

            //    CreateImage();

        }
        private Image CreateImage()
        {
            
            BitmapImage bi = new BitmapImage();
            
            bi.BeginInit();
            bi.UriSource = new Uri(@"Image/ant.jpg", UriKind.RelativeOrAbsolute);
            bi.EndInit();


            Image bmp = new Image();
            bmp.Source = bi;
            bmp.Width = 200;
            
            return bmp;
        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            var numberOfSquares = new TextRange(NumberOfSquaresRichTextBox.Document.ContentStart, NumberOfSquaresRichTextBox.Document.ContentEnd).Text;
            GridMain(int.TryParse(numberOfSquares, out int numberOfSquaresRichText) ? numberOfSquaresRichText : 10);

            var map = new Map(new Coordinate(0,0), new Coordinate(numberOfSquaresRichText, numberOfSquaresRichText));

            var ant = new Ant(new Coordinate(5,5), Direction.Up);


            _game.Run(5);
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
            }
        }
    }
}
