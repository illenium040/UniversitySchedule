using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI.MVP
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        TPresenter GetPresenter<TPresenter>()
            where TPresenter : class, IPresenter;

        TPresenter GetPresenter<TPresenter, TArgumnent>()
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}
