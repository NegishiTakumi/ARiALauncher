using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

using CsStMT;

namespace CsStMT
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegistStoryBoard();
            //Topmost = true;
        }

        public void RegistStoryBoard()
        {
            var storyboard = (Storyboard) FindResource("RingFillStoryBoard");
            storyboard.Completed += (s, e) =>
                {
                    var parts1StoryBoard = (Storyboard)FindResource("Parts1boundStoryBoard");
                    parts1StoryBoard.Begin();
                    var buttonArrangeStoryBoard = (Storyboard)FindResource("ButtonArrangeStoryBoard");
                    buttonArrangeStoryBoard.Begin();
                    
                };
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
                Close();
            //if(e.Key == Key.Right)
                
        }

        private void Image1_MouseEnter(object sender, MouseEventArgs e)
        {
            var cpuCalcWindow = new CPUCalcWindow();
            
         }



        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OnMouseLeftButtonDown(e);
            try
            {
                DragMove();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ConfigOKButton_Click(object sender, RoutedEventArgs e)
        {
            UsernameTextBox.Text ="UserName:"+ UserNameInputTextBox.Text;
        }

    }
}
