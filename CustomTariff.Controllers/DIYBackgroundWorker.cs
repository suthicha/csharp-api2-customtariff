using System.ComponentModel;

namespace CustomTariff.Controllers
{
    public class DIYBackgroundWorker : BackgroundWorker
    {
        public object Tag { get; set; }
        public object UserState { get; set; }
    }
}