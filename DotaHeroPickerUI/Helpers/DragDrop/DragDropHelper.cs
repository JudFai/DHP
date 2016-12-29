using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using DotaHeroPicker;
using DotaHeroPickerUI.ViewModel;

namespace DotaHeroPickerUI.Helpers.DragDrop
{
    public class DragDropHelper
    {
        #region Fields

        private static readonly object _lockerInstance = new object();
        private static DragDropHelper _instance;

        private readonly string _dataName;
        private DotaHeroObservableCollection _senderItemCollection;
        private AdornerLayer _adornerLayer;
        private DragDropAdorner _draggedAdorner;
        private Border _draggedElement;
        private Point _startPosition;
        public Visual VisualControlSource;

        public static readonly DependencyProperty IsDragSourceProperty =
            DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDragSourceChanged));
        public static readonly DependencyProperty IsDropTargetProperty =
            DependencyProperty.RegisterAttached("IsDropTarget", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDropTargetChanged));

        #endregion

        #region Constructors

        public DragDropHelper()
        {
            _dataName = "DataName";
        }

        #endregion

        #region Private Methods

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                try
                {
                    var items = sender as ItemsControl;
                    var fe = e.OriginalSource as FrameworkElement;
                    var draggedElement = FindParent<Border>(fe);
                    //var test = e.OriginalSource as Border;
                    if ((draggedElement != null) && (items != null))
                    {
                        _draggedElement = draggedElement;
                        _senderItemCollection = items.ItemsSource as DotaHeroObservableCollection;
                        if (_senderItemCollection == null)
                            return;

                        var dc = draggedElement.DataContext;
                        var senderItem = dc as DotaHeroViewModel;
                        if ((senderItem == null) || senderItem.IsEmpty || !senderItem.IsEnabledHero)
                            return;

                        var window = Window.GetWindow(items);

                        _startPosition = e.GetPosition(window);
                        _adornerLayer = AdornerLayer.GetAdornerLayer(draggedElement);
                        _draggedAdorner = new DragDropAdorner(draggedElement, _adornerLayer);

                        var dataObject = new DataObject(_dataName, dc);
                        System.Windows.DragDrop.DoDragDrop((DependencyObject) sender, dataObject, DragDropEffects.Move);

                        _draggedAdorner.Detach();
                        _draggedAdorner = null;
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            var rec = e.OriginalSource as FrameworkElement;
            var recCol = sender as ItemsControl;
            if ((rec != null) && (recCol != null))
            {
                var receiverItemCollection = recCol.ItemsSource as DotaHeroObservableCollection;
                if (receiverItemCollection == null)
                    return;

                var receiverItem = rec.DataContext as DotaHeroViewModel;
                var senderItem = e.Data.GetData(_dataName) as DotaHeroViewModel;
                if ((receiverItem == senderItem) || 
                    ((receiverItemCollection.HeroCollectionCharacteristic != HeroCharacteristic.None) && 
                    (receiverItemCollection.HeroCollectionCharacteristic != senderItem.Hero.MainCharacteristic)) ||
                    ((receiverItem.Hero != null) && (_senderItemCollection.HeroCollectionCharacteristic != HeroCharacteristic.None) &&
                    (_senderItemCollection.HeroCollectionCharacteristic != receiverItem.Hero.MainCharacteristic)))
                    return;

                var receiverIndex = receiverItemCollection.IndexOf(receiverItem);
                var senderIndex = _senderItemCollection.IndexOf(senderItem);

                // Swap elements
                var val = receiverItemCollection[receiverIndex];
                receiverItemCollection[receiverIndex] = _senderItemCollection[senderIndex];
                _senderItemCollection[senderIndex] = val;
            }
        }

        private void OnGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            //Console.WriteLine("OnGiveFeedback");
            var point = System.Windows.Forms.Control.MousePosition;

            var pointToScreen = VisualControlSource.PointToScreen(_startPosition);
            var t = _draggedElement.PointToScreen(new Point());
            ShowDraggedAdorner(point.X - t.X + 10, point.Y - t.Y + 10, _draggedElement);
            Mouse.SetCursor(Cursors.Arrow);
            e.Handled = true;
        }

        private void ShowDraggedAdorner(double x, double y, object draggerElement)
        {
            if (_draggedAdorner == null)
            {
                var fe = draggerElement as FrameworkElement;
                var draggedElement = FindParent<Border>(fe);
                var visual = draggerElement as Visual;
                if ((draggedElement == null) || (visual == null))
                    return;

                var adornerLayer = AdornerLayer.GetAdornerLayer(visual);
                _draggedAdorner = new DragDropAdorner(draggedElement, adornerLayer);
            }

            _draggedAdorner.SetPosition(x, y);
        }

        private static T FindParent<T>(FrameworkElement fromElement) where T : FrameworkElement
        {
            if (fromElement == null)
                return null;

            var parent = fromElement as T;
            if (parent != null)
                return parent;

            var fe = fromElement.Parent as FrameworkElement;
            return FindParent<T>(fe);
        }

        private static DragDropHelper GetInstance()
        {
            lock (_lockerInstance)
            {
                return _instance ??
                       (_instance = new DragDropHelper());
            }
        }

        private static void IsDragSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dragSource = d as ItemsControl;
            var instance = GetInstance();
            if (dragSource != null)
            {
                //instance.VisualControlSource = Window.GetWindow(dragSource);
                instance.VisualControlSource = FindParent<UserControl>(dragSource);
                if (Equals(e.NewValue, true))
                {
                    dragSource.GiveFeedback += instance.OnGiveFeedback;
                    dragSource.PreviewMouseMove += instance.OnMouseMove;
                }
                else
                {
                    dragSource.GiveFeedback -= instance.OnGiveFeedback;
                    dragSource.PreviewMouseMove -= instance.OnMouseMove;
                }
            }
        }

        private static void IsDropTargetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dropTarget = d as ItemsControl;
            var instance = GetInstance();
            if (dropTarget != null)
            {
                if (Equals(e.NewValue, true))
                {
                    dropTarget.AllowDrop = true;
                    dropTarget.Drop += instance.OnDrop;
                }
                else
                {
                    dropTarget.AllowDrop = false;
                    dropTarget.Drop -= instance.OnDrop;
                }
            }
        }

        #endregion

        #region Public Methods

        public static bool GetIsDropTarget(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDropTargetProperty);
        }
        public static void SetIsDropTarget(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDropTargetProperty, value);
        }
        public static bool GetIsDragSource(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragSourceProperty);
        }
        public static void SetIsDragSource(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragSourceProperty, value);
        }

        #endregion
    }
}
