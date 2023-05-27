using System.Windows;


namespace lab11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Tasks(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(N.Text);
            int k = int.Parse(K.Text);

            NewtonCalc newtonCalc = new NewtonCalc();
            TasksOtp.Text = (newtonCalc.NewtonTask(n, k)).ToString();
        }

        public void Delegates(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(N.Text);
            int k = int.Parse(K.Text);

            NewtonCalc newtonCalc = new NewtonCalc();
            DelegatesOtp.Text = (newtonCalc.NewtonDelegate(n, k)).ToString();
        }


        public void Async(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(N.Text);
            int k = int.Parse(K.Text);

            NewtonCalc newtonCalc = new NewtonCalc();
            AsyncOtp.Text = (newtonCalc.NewtonAsync(n, k).Result).ToString();
        }

        public void Fibbonacci(object sender, RoutedEventArgs e)
        {
            FibonacciCalc fibonacciCalc = new FibonacciCalc();
            fibonacciCalc.FibonacciInput = FibonacciInput;
            fibonacciCalc.FibonacciOtp = FibonacciOtp;
            fibonacciCalc.Progress = FibonacciProgress;
            FibonacciOtp.Text = fibonacciCalc.calc(int.Parse(FibonacciInput.Text)).ToString();
        }

        public void Compress(object sender, RoutedEventArgs e)
        {
            Zipper zipper = new Zipper();
            System.Windows.Forms.FolderBrowserDialog browser = new System.Windows.Forms.FolderBrowserDialog();
            browser.ShowDialog();
            string folder = browser.SelectedPath;
            zipper.ZipFolder(folder);

        }

        public void Decompress(object sender, RoutedEventArgs e)
        {
            Zipper zipper = new Zipper();
            System.Windows.Forms.FolderBrowserDialog browser = new System.Windows.Forms.FolderBrowserDialog();
            browser.ShowDialog();
            string folder = browser.SelectedPath;
            zipper.UnzipFolder(folder);

        }
    }
}
