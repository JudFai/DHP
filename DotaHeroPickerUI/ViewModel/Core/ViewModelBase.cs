using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotaHeroPickerUI.ViewModel.Core
{
    public abstract class ViewModelBase : Microsoft.TeamFoundation.MVVM.ViewModelBase, IDisposable
    {
        #region Properties

        public HostViewModel Parent { get; private set; }

        #endregion

        #region Constructors

        public ViewModelBase()
            : this(null) { }

        public ViewModelBase(HostViewModel parent)
        {
            Parent = parent;
        }

        #endregion

        #region Protected Methods

        protected void RaisePropertyChanged<T>(Expression<Func<T>> expr)
        {
            var memberExprBody = expr.Body as MemberExpression;
            if (memberExprBody != null)
            {
                var property = memberExprBody.Member.Name;
                RaisePropertyChanged(property);
            }
        }

        #endregion

        #region IDisposable Members

        public abstract void Dispose();

        #endregion

    }
}
