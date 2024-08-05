using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Core.Logs
{
    public abstract class BaseLog : IDisposable
    {
        public event Action<ItemMessage> OnNewMessage;
        private ConcurrentQueue<ItemMessage> _messages = new ConcurrentQueue<ItemMessage>();

        private readonly string _root;
        private string _fullPath => Path.Combine(_root, DateTime.UtcNow.ToString("yyyy.MM.dd_HH") + "-00.log");

        public bool IsActive { get; private set; }

        private Thread _thread;

        public BaseLog(string folder)
        {
            _root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data", "Logs", folder);
            if (!Directory.Exists(_root)) Directory.CreateDirectory(_root);
            Start();
        }


        public void Error(string text, [CallerMemberName] string memberName = "")
        {
            ChangeProperties(text, TypeMessage.Error, memberName);
        }

        public void Error(Exception e, [CallerMemberName] string memberName = "")
        {
            if (e == null) return;

            StringBuilder sb = new StringBuilder();
            var exception = e;
            int counter = 7;

            do
            {
                sb.Append(exception.ToString() + "\r\n");
                exception = exception.InnerException;

            } while (exception != null && exception.InnerException != exception && --counter > 0);

            ChangeProperties(sb.ToString(), TypeMessage.Error, memberName);
        }

        public void Message(string text, [CallerMemberName] string memberName = "")
        {
            ChangeProperties(text, TypeMessage.Message, memberName);
        }

        public void MultyMessage(Dictionary<string, string> pairs, [CallerMemberName] string memberName = "")
        {
            var text = pairs.Aggregate(string.Empty,
                (current, pair) => current + "\r\n" + pair.Key + ": " + pair.Value);
            ChangeProperties(text.Trim(), TypeMessage.Message, memberName);
        }

        public void Debug(string text, [CallerMemberName] string memberName = "")
        {
            ChangeProperties(text, TypeMessage.Debug, memberName);
        }

        public void Request(string text, [CallerMemberName] string memberName = "")
        {
            ChangeProperties(text, TypeMessage.Request, memberName);
        }

        public void Warning(string text, [CallerMemberName] string memberName = "")
        {
            ChangeProperties(text, TypeMessage.Warning, memberName);
        }

        public void Success(string text, [CallerMemberName] string memberName = "")
        {
            ChangeProperties(text, TypeMessage.Success, memberName);
        }

        private void ChangeProperties(string text, TypeMessage typeMessage, string memberName)
        {
            var userName = Thread.CurrentPrincipal?.Identity?.Name;
            var message = new ItemMessage
            {
                Message = text,
                MemberName = memberName,
                Type = typeMessage,
                NameUser = userName,
                Time = DateTime.UtcNow
            };

            _messages.Enqueue(message);
        }

        public void ForceSuccess(string text, [CallerMemberName] string memberName = "")
        {
            var userName = Thread.CurrentPrincipal?.Identity?.Name;
            var message = new ItemMessage
            {
                Message = text,
                MemberName = memberName,
                Type = TypeMessage.Success,
                NameUser = userName,
                Time = DateTime.UtcNow
            };
            File.AppendAllText(_fullPath, $"{message.ToString()}\r\n");
        }

        public void ForceError(string text, [CallerMemberName] string memberName = "")
        {
            var userName = Thread.CurrentPrincipal?.Identity?.Name;
            var message = new ItemMessage
            {
                Message = text,
                MemberName = memberName,
                Type = TypeMessage.Error,
                NameUser = userName,
                Time = DateTime.UtcNow
            };
            File.AppendAllText(_fullPath, $"{message.ToString()}\r\n");
        }


        private void Process()
        {
            while (IsActive)
            {
                try
                {
                    if (_messages.TryDequeue(out ItemMessage message))
                    {
                        File.AppendAllText(_fullPath, $"{message.ToString()}\r\n");
                        OnNewMessage?.Invoke(message);
                        continue;
                    }
                    Thread.Sleep(500);
                }
                catch (Exception e)
                {

                }
            }
        }



        private void Start()
        {
            if (IsActive) return;
            IsActive = true;

            _thread = new Thread(Process);
            _thread.IsBackground = true;
            _thread.Start();
        }

        private void Stop()
        {
            IsActive = false;
        }

        public void Dispose()
        {
            Stop();
        }
    }


    public struct ItemMessage
    {
        public DateTime Time;
        public TypeMessage Type;
        public string Message;
        public string NameUser;
        public string MemberName { get; set; }

        public override string ToString()
        {
            return $"{Time:HH:mm:ss.ffff} <{NameUser}> [{Type.ToString().ToUpperInvariant()}][{MemberName}] {Message}";
        }
    }

    public enum TypeMessage
    {
        Default = 0,
        Proxy = 1,
        Message = 2,
        Warning = 3,
        Error = 4,
        Request = 5,
        Success = 6,
        TestMessage = 7,
        Debug = 8
    }

}
