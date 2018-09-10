using Chapter24.CustomerMaintenance.Perspectives;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public class Controller<T> : IController<T> where T : IView
    {
        private T _view;

        protected Controller(IModuleController moduleController)
        {
            ModuleController = moduleController;
        }

        public T View
        {
            get
            {
                return _view;
            }
            set
            {
                OnBeforeViewSet();
                _view = value;
                OnViewSet();
            }
        }

        protected IModuleController ModuleController { get; }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing) { }

        protected virtual void OnBeforeViewSet() { }

        protected virtual void OnViewSet() { }
    }
}
