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


namespace ClipboardManager.Controls
{
    /// <summary>
    /// Логика взаимодействия для IntegerUpDown.xaml
    /// </summary>
    public partial class DoubleUpDown : UserControl
    {
        
        static DoubleUpDown()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = CoerceValue;
            metadata.DefaultValue = 0d;
            ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(DoubleUpDown), metadata);
            
        }
        public DoubleUpDown()
        {
            DataContext = this;
            InitializeComponent();
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty;
        private static object CoerceValue(DependencyObject d, object value)
        {
            var baseType = (DoubleUpDown)d;
            var num = (double)value;
            if(num< baseType.MinValue)
            {
                return baseType.MinValue;
            }
            else if (num > baseType.MaxValue)
            {
                return baseType.MaxValue;
            }
            else
            {
                return num;
            }
        }

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(DoubleUpDown), new PropertyMetadata(0d));


        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }
        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(DoubleUpDown), new PropertyMetadata(0d));



        public double UpStep
        {
            get { return (double)GetValue(UpStepProperty); }
            set { SetValue(UpStepProperty, value); }
        }
        public static readonly DependencyProperty UpStepProperty =
            DependencyProperty.Register("UpStep", typeof(double), typeof(DoubleUpDown), new PropertyMetadata(1D));

        public double DownStep
        {
            get { return (double)GetValue(DownStepProperty); }
            set { SetValue(DownStepProperty, value); }
        }
        public static readonly DependencyProperty DownStepProperty =
            DependencyProperty.Register("DownStep", typeof(double), typeof(DoubleUpDown), new PropertyMetadata(1D));


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Value += UpStep;
        }

        private void Substruct_Click(object sender, RoutedEventArgs e)
        {
            Value -= DownStep;
        }
    }
}
