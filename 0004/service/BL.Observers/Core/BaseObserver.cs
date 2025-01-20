using BL.Observers.Interfaces;
using Core.Logs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Observers
{
    public abstract class BaseObserver : IBaseObserver
    {
        private Thread _thread;

        protected int _timeoutMS;
        protected readonly string _name;

        public bool IsStarted { get; private set; }

        public BaseObserver(int timeoutMs, string observerName)
        {
            _name = observerName;
            _timeoutMS = timeoutMs;
        }

        public void Start()
        {
            if (_thread != null && _thread.IsAlive) throw new Exception($"Observer {_name} is already started");

            IsStarted = true;
            _thread = new Thread(ProcessMethod);
            _thread.IsBackground = true;
            _thread.Start();
            Log.Current.Message($"Observer process \"{_name}\" started");
        }

        public void Stop()
        {
            IsStarted = false;
            Log.Current.Message($"Observer process \"{_name}\" stopped");

            _thread?.Abort();
        }

        protected virtual async void ProcessMethod()
        {
            while (IsStarted)
            {
                try
                {
                    await OperationMethod();
                }
                catch (Exception er)
                {
                    Log.Current.Error(er, _name);
                }
                finally
                {
                    Thread.Sleep(GetTimeoutMs());
                }
            }
        }

        protected virtual int GetTimeoutMs()
        {
            return _timeoutMS;
        }

        protected abstract Task OperationMethod();
    }
}
