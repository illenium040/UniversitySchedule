using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run(TArg argument);
    }

    public abstract class BasePartialPresenter<TView> : IPresenter
        where TView : IPartialView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePartialPresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run();
    }

    public abstract class BasePartialPresenter<TView, TArg> : IPresenter<TArg>
        where TView : IPartialView
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePartialPresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run(TArg argument);
    }
}
