using System;
using System.Collections.Generic;
using System.Text;
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
using Microsoft.Expression.Shapes;

//using Microsoft.Expression.Shapes;

namespace HeroPickerResources.Controls
{
    /// <summary>
    /// Interaction logic for ProgressRing.xaml
    /// </summary>
    public partial class ProgressRing : UserControl
    {

        public double PrRadius
        {
            get { return (double)GetValue(PrRadiusProperty); }
            set { SetValue(PrRadiusProperty, value); }
        }

        public static readonly DependencyProperty PrRadiusProperty =
            DependencyProperty.Register("PrRadius", typeof(double),
                typeof(ProgressRing),
                new PropertyMetadata((double)100, PrRadiusChanged));

        private static void PrRadiusChanged(DependencyObject depObj,
         DependencyPropertyChangedEventArgs args)
        {
            var s = (ProgressRing)depObj;
            s.ProgressRingBar.StrokeThickness = (double)args.NewValue;
            s.ProgressRingBar_Path.StrokeThickness = (double)args.NewValue;

        }

        public double PrMaximum
        {
            get { return (double)GetValue(PrMaximumProperty); }
            set { SetValue(PrMaximumProperty, value); }
        }

        public static readonly DependencyProperty PrMaximumProperty =
           DependencyProperty.Register("PrMaximum", typeof(double), 
               typeof(ProgressRing), 
               new FrameworkPropertyMetadata((double)100, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
                

        private static void PrMaximumChanged(DependencyObject depObj,
           DependencyPropertyChangedEventArgs args)
        {
            var s = (ProgressRing)depObj;
        }


        public double PrPercent
        {
            get { return (double)GetValue(PrPercentProperty); }
            set { SetValue(PrPercentProperty, value); }
        }

        public static readonly DependencyProperty PrPercentProperty =
            DependencyProperty.Register("PrPercent", typeof(double),
                typeof(ProgressRing),
                new PropertyMetadata((double)0, PrPercentChanged));

        private static void PrPercentChanged(DependencyObject depObj,
           DependencyPropertyChangedEventArgs args)
        {
            var s = (ProgressRing)depObj;
            if (s.PrMaximum != 0)
            {
                var change = (double) args.NewValue/s.PrMaximum*360;
                if (change > 360) change = 360;
                var da = new DoubleAnimation
                {
                    To = change,
                    Duration = TimeSpan.FromMilliseconds(s.PrSpeed)
                };
                s.ProgressRingBar.BeginAnimation(Arc.EndAngleProperty, da);
            }
        }

        public double PrSpeed
        {
            get { return (double)GetValue(PrSpeedProperty); }
            set { SetValue(PrSpeedProperty, value); }
        }

        public static readonly DependencyProperty PrSpeedProperty =
            DependencyProperty.Register("PrSpeed", typeof(double),
                typeof(ProgressRing),
                new PropertyMetadata((double)100));

        private static void PrSpeedChanged(DependencyObject depObj,
           DependencyPropertyChangedEventArgs args)
        {
            var s = (ProgressRing)depObj;
            s.PrSpeed = (double)args.NewValue;
        }

        public Brush PrBackground
        {
            get { return (Brush)GetValue(PrBackgroundProperty); }
            set { SetValue(PrBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PrBackgroundProperty =
            DependencyProperty.Register("PrBackground", typeof(Brush),
                typeof(ProgressRing),
                new PropertyMetadata(Brushes.Transparent, PrBackgroundChanged));

        private static void PrBackgroundChanged(DependencyObject depObj,
           DependencyPropertyChangedEventArgs args)
        {
            var s = (ProgressRing)depObj;
            s.ProgressRingBar_Path.Stroke = (Brush)args.NewValue;
        }

        public ProgressRing()
        {
            InitializeComponent();
        }
    }
}