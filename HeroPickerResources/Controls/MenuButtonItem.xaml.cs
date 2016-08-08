using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using System.ComponentModel;
using HeroPickerResources.Resources;

namespace HeroPickerResources.Controls
{
    /// <summary>
    /// Interaction logic for AppBarButton.xaml
    /// </summary>
    public partial class MenuButtonItem : Button
    {
        public MenuButtonItem()
        {
            InitializeComponent();
        }

        static MenuButtonItem()
        {
            IconProperty = DependencyProperty.Register("Icon", typeof(IconEnum), typeof(MenuButtonItem),
                new PropertyMetadata(IconEnum.Default, Icon_Changed));
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MenuButtonItem),
                new PropertyMetadata("Test",Title_Changed));
            ImagePathProperty = DependencyProperty.Register("ImagePath", typeof(string), typeof(MenuButtonItem),
                new PropertyMetadata(string.Empty, Image_Changed));
        }

        public static DependencyProperty IconProperty;
        public static DependencyProperty TitleProperty;
        public static DependencyProperty ImagePathProperty;

        [Category("MyProperty")]
        public IconEnum Icon
        {
            get { return (IconEnum)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        [Category("MyProperty")]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        [Category("MyProperty")]
        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }
        private static void Title_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var titleValue = (string)e.NewValue;
            var thisUserControl = (MenuButtonItem)sender;
            thisUserControl.TitleTextBlock.Text = titleValue;
        }

        private static void Icon_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var iconValue = (IconEnum)e.NewValue;
            var thisUserControl = (MenuButtonItem)sender;
            thisUserControl.TextIconTextBlock.Text = (string)thisUserControl.FindResource("Symbol" + iconValue);
            thisUserControl.ImageIconControl.Visibility = Visibility.Collapsed;
            thisUserControl.TextIconTextBlock.Visibility = Visibility.Visible;
        }

        private static void Image_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var imagePathValue = (string)e.NewValue;
            if (imagePathValue != null)
            {
                var thisUserControl = (MenuButtonItem) sender;
                thisUserControl.ImageIconControl.OpacityMask =
                    new ImageBrush(new BitmapImage(new Uri(@imagePathValue)));
                thisUserControl.ImageIconControl.Visibility = Visibility.Visible;
                thisUserControl.TextIconTextBlock.Visibility = Visibility.Collapsed;
            }
        }
    }
}