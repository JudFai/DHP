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
    public class FlyGridViewControl : Control
    {
        #region Fields

        public static DependencyProperty MenuContentProperty;
        public static DependencyProperty MainContentProperty;
        public static DependencyProperty IsPinnedProperty;

        #endregion

        #region Properties

        [Category("FlyGridView property")]
        public object MenuContent
        {
            get { return (object)GetValue(MenuContentProperty); }
            set
            {
                SetValue(MenuContentProperty, value);
            }
        }

        [Category("FlyGridView property")]
        public object MainContent
        {
            get { return (object)GetValue(MainContentProperty); }
            set
            {
                SetValue(MainContentProperty, value);
            }
        }

        [Category("FlyGridView property")]
        public bool IsPinned
        {
            get { return (bool)GetValue(IsPinnedProperty); }
            set
            {
                SetValue(IsPinnedProperty, value);
            }
        }

        #endregion

        #region Constructors

        static FlyGridViewControl()
        {
            MenuContentProperty = DependencyProperty.Register("MenuContent", typeof(object), typeof(FlyGridViewControl), new PropertyMetadata("Menu Items"));
            MainContentProperty = DependencyProperty.Register("MainContent", typeof(object), typeof(FlyGridViewControl), new PropertyMetadata("Main Content"));
            IsPinnedProperty = DependencyProperty.Register("IsPinned", typeof(bool), typeof(FlyGridViewControl), new PropertyMetadata(true));
        }

        #endregion
    }
}
