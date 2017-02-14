using System.ComponentModel;
using System.Windows;
using WPF.MDI;

namespace MyWpfMDIApp
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /******************************/
        /*       Button Events        */
        /******************************/
        #region Button Events

        #endregion
        /******************************/
        /*      Menu Events           */
        /******************************/
        #region Menu Events

        /// <summary>
        /// MenuItem_Click_NewMDIWindow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_NewMDIWindow(object sender, RoutedEventArgs e)
        {
            double AcParentWindoHeight = ActualHeight;
            double AcParentWindoWidth = ActualWidth;
            
            MdiChild MdiChild = new MdiChild()
            {
                Height = (AcParentWindoHeight - MainMenu.ActualHeight - MainToolBar.ActualHeight) * 0.6,
                Width = AcParentWindoWidth * 0.6,
                Content = new UserControlMDIChild()
            };
            MainMdiContainer.Children.Add(MdiChild);
        }

        /// <summary>
        /// MenuItem_Click_Tideled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_Tideled(object sender, RoutedEventArgs e)
        {
            double whh  = SystemParameters.WindowCaptionHeight + SystemParameters.ResizeFrameHorizontalBorderHeight;
            double wf = SystemParameters.ResizeFrameVerticalBorderWidth;
            double sy = ActualHeight - MainMenu.ActualHeight - MainToolBar.ActualHeight - 2*MainStatusBar.Height;
            double sx = ActualWidth;
            double anzW = MainMdiContainer.Children.Count;

            for (int i = 0; i < MainMdiContainer.Children.Count; i++)
            {
                MainMdiContainer.Children[i].Width = sx - 4*wf;
                MainMdiContainer.Children[i].Height = sy/anzW;
                MainMdiContainer.Children[i].Position = new Point(0, sy/anzW * i);
            }
        }

        /// <summary>
        /// MenuItem_Click_Cascade
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>MenuItem_Click_CloseAll
        private void MenuItem_Click_Cascade(object sender, RoutedEventArgs e)
        {
            double whh = SystemParameters.WindowCaptionHeight + SystemParameters.ResizeFrameHorizontalBorderHeight;
            double sy = ActualHeight - MainMenu.ActualHeight - MainToolBar.ActualHeight;
            double sx = ActualWidth;
            int anzW = MainMdiContainer.Children.Count;

            for (int i = 0; i < MainMdiContainer.Children.Count; i++)
            {
                MainMdiContainer.Children[i].Width = sx * 0.6;
                MainMdiContainer.Children[i].Height = sy * 0.6;
                MainMdiContainer.Children[i].Position = new Point(whh * i, whh * i);
            }
        }

        /// <summary>
        /// MenuItem_Click_CloseAll
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_CloseAll(object sender, RoutedEventArgs e)
        {
            for (int i = MainMdiContainer.Children.Count-1; i >= 0; i--)
                MainMdiContainer.Children[i].Close();
        }

        /// <summary>
        /// MenuItem_Click_About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_About(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("About MyWpfMDIApp", "MyWpfMDIApp", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// MenuItem_Click_Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>MenuItem_Click_NewMDIWindow
        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion
        /******************************/
        /*      Other Events          */
        /******************************/
        #region Other Events

        #endregion
        /******************************/
        /*      Other Functions       */
        /******************************/
        #region Other Functions

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="p"></param>
        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        #endregion
    }
}
