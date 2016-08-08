using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HeroPickerResources.Controls
{
    public class PanelWithToolTipControl : Panel
    {
        #region Fields

        private Popup _popup;

        public static readonly DependencyProperty PopupContentProperty = DependencyProperty.Register("PopupContent", typeof(UIElement), typeof(PanelWithToolTipControl), new PropertyMetadata(null, OnPopupChanged));

        #endregion

        #region Properties

        public UIElement PopupContent
        {
            get { return (UIElement)GetValue(PopupContentProperty); }
            set { SetValue(PopupContentProperty, value); }
        }

        #endregion

        #region Constructors

        public PanelWithToolTipControl()
        {
            Background = Brushes.Transparent;
            MouseEnter += OnMouseEnter;
            MouseMove += OnMouseMove;
            MouseLeave += OnMouseLeave;
        }

        #endregion

        #region Private Methods

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("OnMouseEnter");
#endif
            if (PopupContent != null)
                _popup.IsOpen = true;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (PopupContent != null)
            {
                var point = e.GetPosition(this);
                SetPopupPosition(point);
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
#if DEBUG
            Console.WriteLine("OnMouseLeave");
#endif
            if (PopupContent != null)
                _popup.IsOpen = false;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size maxSize = new Size();

            foreach (UIElement child in Children)
            {
                child.Measure(availableSize);
                maxSize.Height = Math.Max(child.DesiredSize.Height, maxSize.Height);
                maxSize.Width = Math.Max(child.DesiredSize.Width, maxSize.Width);
            }

            return maxSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            foreach (UIElement child in Children)
            {
                child.Arrange(new Rect(finalSize));
            }

            return finalSize;
        }

        private static void OnPopupChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as PanelWithToolTipControl;
            if (control == null)
                return;

            control.PopupContent = dependencyPropertyChangedEventArgs.NewValue as UIElement;
            if (control.PopupContent != null)
            {
                control._popup = new Popup
                {
                    Child = control.PopupContent,
                    Placement = PlacementMode.Relative,
                    PopupAnimation = PopupAnimation.Fade,
                    AllowsTransparency = true,
                    PlacementTarget = control
                };
            }
        }

        private void SetPopupPosition(Point p)
        {
            _popup.HorizontalOffset = p.X + 20;
            _popup.VerticalOffset = p.Y + 20;
        }

        #endregion
    }
}
