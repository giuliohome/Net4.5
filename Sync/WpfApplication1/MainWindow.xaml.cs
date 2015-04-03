using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AnimationInSequence();
        }

        public async void AnimationInSequence()
        {
            await stor_Completed("3", 'L').BeginAsync();
            await stor_Completed("2", 'D').BeginAsync();
            await stor_Completed("1", 'R').BeginAsync();
        }

        public Storyboard stor_Completed(string num, char direction)
        {
            Button butt = (Button)this.FindName("butt" + num);
            Storyboard stor = (Storyboard)this.FindName("stor" + num);
            ThicknessAnimation thic = (ThicknessAnimation)this.FindName("thic" + num);
            thic.From = butt.Margin;
            thic.To = null;
            //thic.By = null;
            TranslateTransform tt = new TranslateTransform();
            tt.X = butt.RenderTransform.Value.OffsetX;
            tt.Y = butt.RenderTransform.Value.OffsetY;

            if (direction == 'U')
            {
                thic.By = new Thickness(0, -80, 0, 0);
            }
            else if (direction == 'D')
            {
                thic.By = new Thickness(0, 80, 0, 0);
            }
            else if (direction == 'R')
            {
                thic.By = new Thickness(80, 0, 0, 0);
            }
            else if (direction == 'L')
            {
                thic.By = new Thickness(-80, 0, 0, 0);
            }
            stor.Children.Add(thic);
            return stor;
        }

        public void OriginalAnimationInSequence()
        {
            original_stor_Completed("3", 'L');
            original_stor_Completed("2", 'D');
            original_stor_Completed("1", 'R');
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Thread.Sleep(1000);
            OriginalAnimationInSequence();
        }
        public async void original_stor_Completed(string num, char direction)
        {
            Button butt = (Button)this.FindName("butt" + num);
            Storyboard stor = (Storyboard)this.FindName("stor" + num);
            ThicknessAnimation thic = (ThicknessAnimation)this.FindName("thic" + num);
            thic.From = butt.Margin;
            thic.To = null;
            //thic.By = null;
            TranslateTransform tt = new TranslateTransform();
            tt.X = butt.RenderTransform.Value.OffsetX;
            tt.Y = butt.RenderTransform.Value.OffsetY;

            if (direction == 'U')
            {
                thic.By = new Thickness(0, -80, 0, 0);
            }
            else if (direction == 'D')
            {
                thic.By = new Thickness(0, 80, 0, 0);
            }
            else if (direction == 'R')
            {
                thic.By = new Thickness(80, 0, 0, 0);
            }
            else if (direction == 'L')
            {
                thic.By = new Thickness(-80, 0, 0, 0);
            }
            stor.Children.Add(thic);

            await stor.BeginAsync();        //or tow next line
            //Task tcs = StoryboardExtensions.BeginAsync(stor);
            //await tcs;
        }


    }
}
