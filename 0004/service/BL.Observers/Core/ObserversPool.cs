using BL.Observers.Interfaces;
using Core.Logs;
using System.Collections.Generic;

namespace BL.Observers
{
    public class ObserversPool : IObserversPool
    {
        protected readonly List<IBaseObserver> _observers;

        public ObserversPool()
        {
            _observers = new List<IBaseObserver>()
            {
                // Write observers here
            };
        }

        ~ObserversPool()
        {
            Log.Main.Debug("Observers management service destruct");
        }

        public void Start()
        {
            foreach (var item in _observers)
            {
                try
                {
                    item.Start();
                }
                catch (System.Exception er)
                {
                    Log.Main.Error(er);
                }
            }
        }

        public void Stop()
        {
            foreach (var item in _observers)
            {
                try
                {
                    item.Stop();
                }
                catch (System.Exception er)
                {
                    Log.Main.Error(er);
                }
            }
        }
    }
}

