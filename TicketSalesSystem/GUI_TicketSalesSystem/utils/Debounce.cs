using System;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem.utils
{
    /// <summary>
    /// Debounce đơn giản dùng WinForms Timer.
    /// Gọi Execute(action) liên tục, chỉ chạy action 1 lần sau khi người dùng ngừng gõ X ms.
    /// </summary>
    public sealed class Debounce : IDisposable
    {
        private readonly Timer _timer;
        private Action _action;

        public Debounce(int intervalMs = 500)
        {
            _timer = new Timer { Interval = intervalMs };
            _timer.Tick += (s, e) =>
            {
                _timer.Stop();
                _action?.Invoke();
            };
        }

        public void Execute(Action action)
        {
            _action = action;
            _timer.Stop();
            _timer.Start();
        }

        public void Dispose()
        {
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}
