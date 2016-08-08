using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace DotaHeroPickerUI.Helpers.DragDrop
{
    class DragDropAdorner : Adorner
    {
        #region Fields

        private AdornerLayer _adornerLayer;
        private Point _point;

        #endregion

        #region Constrcutors

        public DragDropAdorner(UIElement element, AdornerLayer adornerLayer)
            : base(element)
        {
            _adornerLayer = adornerLayer;
            _adornerLayer.Add(this);
        }

        #endregion

        #region Private Methods

        protected override void OnRender(DrawingContext drawingContext)
        {
            var vb = new VisualBrush(AdornedElement);
            vb.Opacity = 0.7;
            drawingContext.DrawRectangle(vb, null, new Rect(0, 0, AdornedElement.RenderSize.Width, AdornedElement.RenderSize.Height));
        }

        #endregion

        #region Public Methods

        public void SetPosition(double x, double y)
        {
            _point.X = x;
            _point.Y = y;
            _adornerLayer.Update(AdornedElement);
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            var result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(_point.X, _point.Y));

            return result;
        }

        public void Detach()
        {
            Console.WriteLine("Detach");
            _adornerLayer.Remove(this);
        }

        #endregion
    }
}
