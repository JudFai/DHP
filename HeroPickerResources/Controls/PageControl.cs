using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HeroPickerResources.Controls
{

    // TODO: привести в порядок контрол
    [TemplatePart(Name = PART_HeaderTextBlock, Type = typeof(UIElement))]
    public class PageControl : ContentControl
    {
        private const string PART_HeaderTextBlock = "PART_HeaderTextBlock";
        private string _header;
        static PageControl()
        {
            ShowAnimationProperty = DependencyProperty.Register("ShowAnimation", typeof(bool),
              typeof(PageControl), new PropertyMetadata(false, ShowAnimation_Changed));
            HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(PageControl),
                new PropertyMetadata("Header Text"));
            OneAnimationProperty = DependencyProperty.Register("OneAnimation", typeof(bool),
              typeof(PageControl), new PropertyMetadata(true));
        }


        public static DependencyProperty ConditionProperty;




        public static DependencyProperty HeaderTextProperty;

        [Category("Page Property")]
        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set
            {
                SetValue(HeaderTextProperty, value);
            }
        }



        public static DependencyProperty ShowAnimationProperty;
        public static DependencyProperty OneAnimationProperty;

        [Category("Page Property")]
        public bool ShowAnimation
        {
            get { return (bool)GetValue(ShowAnimationProperty); }
            set
            {

                SetValue(ShowAnimationProperty, value);
            }
        }

        [Category("Page Property")]
        public bool OneAnimation
        {
            get { return (bool)GetValue(OneAnimationProperty); }
            set
            {
                SetValue(OneAnimationProperty, value);
            }

        }

        private bool _oneOnimationCompleted = false;
        private static void ShowAnimation_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            var conditionValue = (bool)e.NewValue;
            //Console.WriteLine(conditionValue);
            var thisUserControl = (PageControl)sender;
            if (thisUserControl.OneAnimation && !thisUserControl._oneOnimationCompleted)
            {
                if (conditionValue)
                {
                    thisUserControl.RaiseShowEvent();
                    thisUserControl._oneOnimationCompleted = true;
                }

            }
            if (!thisUserControl.OneAnimation)
            {
                if (conditionValue)
                    thisUserControl.RaiseShowEvent();
                else
                    thisUserControl.RaiseHiddenEvent();
            }


        }


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...

        public static DependencyProperty HeaderStyleProperty;
        private TextBlock _headerTb;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _headerTb = GetTemplateChild(PART_HeaderTextBlock) as TextBlock;
            if (_headerTb != null)
                try
                {
                    _headerTb.Style = new Style(typeof(TextBlock), (Style)this.FindResource(_header + "TextBlockStyle"));

                }
                catch (Exception)
                {


                }
            if (ShowAnimation)
                RaiseShowEvent();
            else
                RaiseHiddenEvent();

        }


        public static readonly RoutedEvent ShowEvent = EventManager.RegisterRoutedEvent("Show", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PageControl));


        public event RoutedEventHandler Show
        {
            add { AddHandler(ShowEvent, value); }
            remove { RemoveHandler(ShowEvent, value); }
        }


        void RaiseShowEvent()
        {
            var newEventArgs = new RoutedEventArgs(PageControl.ShowEvent);
            {
                try
                {
                    RaiseEvent(newEventArgs);
                }
                catch (Exception)
                {


                }
            }

        }


        public static readonly RoutedEvent HiddenEvent = EventManager.RegisterRoutedEvent("Hidden", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PageControl));


        public event RoutedEventHandler Hidden
        {
            add { AddHandler(HiddenEvent, value); }
            remove { RemoveHandler(HiddenEvent, value); }
        }


        void RaiseHiddenEvent()
        {
            var newEventArgs = new RoutedEventArgs(PageControl.HiddenEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
