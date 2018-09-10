using Chapter24.CustomerMaintenance.Perspectives;
using System;

namespace Chapter24.CustomerMaintenance.Controllers
{
    public interface IController<T> : IDisposable where T : IView
    {
        T View { get; set; }
    }
}
