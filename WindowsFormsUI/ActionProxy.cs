using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsUI
{
    public class ActionProxy
    {
        private readonly SemaphoreSlim _semaphore;
        private readonly int _count;
        public ActionProxy(int threadsInCount = 1)
        {
            _semaphore = new SemaphoreSlim(threadsInCount);
            _count = threadsInCount;
        }

        public void Invoke(Action action, bool cancelActionIfBusy = true)
        {
            if (cancelActionIfBusy && _semaphore.CurrentCount == 0) return;
            _semaphore.Wait();
            action?.Invoke();
            _semaphore.Release();
        }

        public async Task InvokeAsync(Action task, bool cancelActionIfBusy = true)
        {
            try
            {
                if (cancelActionIfBusy && _semaphore.CurrentCount == 0) return;
                await _semaphore.WaitAsync();
                await Task.Run(task);
                _semaphore.Release();
            }
            catch (Exception e) { throw e; }
            finally
            {
                _semaphore.Release(_count);
            }
        }
    }
}
