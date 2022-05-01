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

        private Image _antImage;
        private int _chessIndex=-1;
        private BitmapImage _bitmapImage;
        private Ant _ant;
        private Map _map;
        private Grid _chessGrid;
        private readonly SolidColorBrush _solidWhite = new SolidColorBrush(Colors.White);
        private readonly SolidColorBrush _solidBlack = new SolidColorBrush(Colors.Black);
        private readonly IGame _game;
        private int _numberOfRightDirectionStrokes = 0;
        //public MainWindow(IGame game, IGamer gamer)
        public MainWindow(IGame game)
        {
            _game = game;
            
            InitializeComponent();
            CreateImage();
        }

        private void PrepareChessGrid(int numberOfSquares)
        {

            if (_chessGrid!=null)
            {
                _chessGrid.Children.Clear();
                MainGrid.Children.Remove(_chessGrid);
            }

            _chessGrid = new Grid
            {
                Width = MainGrid.ColumnDefinitions[0].Width.Value,
                Height = MainGrid.RowDefinitions[0].Height.Value,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                ShowGridLines = true,
                Opacity = 0.5
            };


            for (int i = 0; i <= numberOfSquares; i++)
            {
                _chessGrid.ColumnDefinitions.Add(new ColumnDefinition());
                _chessGrid.RowDefinitions.Add(new RowDefinition());
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
            //TextBlock txt1 = new TextBlock();
            //txt1.Text = "2005 Products Shipped";
            //txt1.FontSize = 20;
            //txt1.FontWeight = FontWeights.Bold;
            //Grid.SetColumnSpan(txt1, 3);
            //Grid.SetRow(txt1, 0);

            //// Add the second text cell to the Grid
            //TextBlock txt2 = new TextBlock();
            //txt2.Text = "Quarter 1";
            //txt2.FontSize = 12;
            //txt2.FontWeight = FontWeights.Bold;
            //Grid.SetRow(txt2, 1);
            //Grid.SetColumn(txt2, 0);

            //// Add the third text cell to the Grid
            //TextBlock txt3 = new TextBlock();
            //txt3.Text = "Quarter 2";
            //txt3.FontSize = 12;
            //txt3.FontWeight = FontWeights.Bold;
            //Grid.SetRow(txt3, 1);
            //Grid.SetColumn(txt3, 1);

            //// Add the fourth text cell to the Grid
            //TextBlock txt4 = new TextBlock();
            //txt4.Text = "Quarter 3";
            //txt4.FontSize = 12;
            //txt4.FontWeight = FontWeights.Bold;
            //Grid.SetRow(txt4, 1);
            //Grid.SetColumn(txt4, 2);

            //// Add the sixth text cell to the Grid
            //TextBlock txt5 = new TextBlock();
            //Double db1 = new Double();
            //db1 = 50000;
            //txt5.Text = db1.ToString();
            //Grid.SetRow(txt5, 2);
            //Grid.SetColumn(txt5, 0);

            //// Add the seventh text cell to the Grid
            //TextBlock txt6 = new TextBlock();
            //Double db2 = new Double();
            //db2 = 100000;
            //txt6.Text = db2.ToString();
            //Grid.SetRow(txt6, 2);
            //Grid.SetColumn(txt6, 1);

            // Add the final text cell to the Grid
            //_antImage = CreateImage();

            //SolidColorBrush solidBG = new SolidColorBrush(Colors.Aqua);
            //Border borderBG = new Border();
            //borderBG.Background = solidBG;


            Grid.SetRow(_antImage, _ant.Coordinate.X);
            Grid.SetColumn(_antImage, _ant.Coordinate.Y);


            //Grid.SetRow(borderBG, 2);
            //Grid.SetColumn(borderBG, 2);

            //_chessGrid.Children.Add(borderBG);
            
            //borderBG = new Border();
            //borderBG.Background = solidBG;

            //Grid.SetRow(borderBG, 4);
            //Grid.SetColumn(borderBG, 4);

            //_chessGrid.Children.Add(borderBG);

            // Total all Data and Span Three Columns
            //TextBlock txt8 = new TextBlock();
            //txt8.FontSize = 16;
            //txt8.FontWeight = FontWeights.Bold;
            //txt8.Text = "Total Units: " + (db1 + db2).ToString();
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
            _chessGrid.Children.Add(_antImage);
           // _chessGrid.Children.Add(borderBG);
            
            //TransformedBitmap transformBmp = new TransformedBitmap();

            //transformBmp.BeginInit();

            ////transformBmp.Source = antImage;

            //RotateTransform transform = new RotateTransform(90);

            //transformBmp.Transform = transform;

            //transformBmp.EndInit();

            // Add the Grid as the Content of the Parent Window Object

            _chessIndex = MainGrid.Children.Add(_chessGrid);
            
            Show();


            //    grid_Main.Height = 350;
            //    grid_Main.Width = 525;

            //    grid_Main.Background = Brushes.GreenYellow;

            //    CreateImage();

        }

        private void RenderChessGrid()
        {
            _chessGrid.Children.Clear();

            foreach (var cell in _map.Cells)
            {
                if (cell.Color == Color.White)
                {

                    var whiteBorder = new Border { Background = _solidWhite };
                    Grid.SetRow(whiteBorder, cell.Coordinate.X);
                    Grid.SetColumn(whiteBorder, cell.Coordinate.Y);
                    _chessGrid.Children.Add(whiteBorder);
                }

                if (cell.Color == Color.Black)
                {
                    var blackBorder = new Border { Background = _solidBlack };
                    Grid.SetRow(blackBorder, cell.Coordinate.X);
                    Grid.SetColumn(blackBorder, cell.Coordinate.Y);
                    _chessGrid.Children.Add(blackBorder);
                }
            }

            Grid.SetRow(_antImage, _ant.Coordinate.X);
            Grid.SetColumn(_antImage, _ant.Coordinate.Y);

            switch(_ant.Direction)
            {
                case Direction.Right: RotateImageClockwise(1); break;
                case Direction.Up: RotateImageClockwise(0); break;
                case Direction.Left: RotateImageClockwise(3); break;
                case Direction.Down: RotateImageClockwise(2); break;
            };

            _chessGrid.Children.Add(_antImage);
        }

        //private Image CreateImage()
        //{

        //    BitmapImage bi = new BitmapImage();

        //    bi.BeginInit();
        //    bi.UriSource = new Uri(@"Image/ant.jpg", UriKind.RelativeOrAbsolute);
        //    bi.EndInit();


        //    Image bmp = new Image();
        //    bmp.Source = bi;



        //    return bmp;
        //}

        

        private void PrepareButton_Click(object sender, RoutedEventArgs e)
        {
            var numberOfSquares = NumberOfSquaresTextBox.Text;

            if (!int.TryParse(numberOfSquares, out int numberOfSquaresParsedResult))
                
                numberOfSquaresParsedResult = 10;

            _map = new Map(new Coordinate(0,0), new Coordinate(numberOfSquaresParsedResult, numberOfSquaresParsedResult), new List<Tuple<Coordinate, Color>>());

            _ant = new Ant(new Coordinate(Convert.ToInt32(AntX.Text), Convert.ToInt32(AntY.Text)), Direction.Up);

            PrepareChessGrid(numberOfSquaresParsedResult);

        }

        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            var numberOfIterations = NumberOfIterationsTextBox.Text;

            if (!int.TryParse(numberOfIterations, out int numberOfIterationsParsedResult))

                numberOfIterationsParsedResult = 10;

            _game.Run(numberOfIterationsParsedResult, _ant,_map);
            
            RenderChessGrid();
        }

        private void CreateImage()
        {
            _bitmapImage = new BitmapImage(new Uri(@"Image/ant.jpg", UriKind.RelativeOrAbsolute));

            _antImage = new Image { Source = _bitmapImage };
        }

        private void RotateImageClockwise(int numberOfQuarters)
        {
            TransformedBitmap transformBmp = new TransformedBitmap();

            transformBmp.BeginInit();

            transformBmp.Source = _bitmapImage;

            RotateTransform transform = new RotateTransform(numberOfQuarters * 90);

            transformBmp.Transform = transform;

            transformBmp.EndInit();

            _antImage.Source = transformBmp;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right && _ant!=null)
            {
                _numberOfRightDirectionStrokes++;
                _ant.TurnRight();
                RotateImageClockwise(_numberOfRightDirectionStrokes);
            }
        }
    }
}
