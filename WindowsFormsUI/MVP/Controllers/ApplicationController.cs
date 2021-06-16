namespace WindowsFormsUI.MVP.Controllers
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;

        public ApplicationController(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IApplicationController RegisterInstance<TInstance>(TInstance instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IApplicationController RegisterService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>();
            return this;
        }

        public TPresenter GetPresenter<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();

            return _container.Resolve<TPresenter>();
        }

        public TPresenter GetPresenter<TPresenter, TArgumnent>()
            where TPresenter : class, IPresenter<TArgumnent>
        {
            if (!_container.IsRegistered<TPresenter>())
                _container.Register<TPresenter>();

            return _container.Resolve<TPresenter>();
        }

        public TService GetService<TService>()
            where TService : class
        {
            return _container.Resolve<TService>();
        }
    }
}
