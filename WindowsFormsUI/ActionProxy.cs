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
        public ActionProxy(int threadsInCount = 1)
        {
            _semaphore = new SemaphoreSlim(threadsInCount);
        }

        public void Invoke(Action action, bool cancelActionIfBusy = true)
        {
            if (cancelActionIfBusy && _semaphore.CurrentCount == 0) return;
            _semaphore.Wait();
            action();
            _semaphore.Release();
        }

        public async Task InvokeTask(Task task, bool cancelActionIfBusy = true)
        {
            if (cancelActionIfBusy && _semaphore.CurrentCount == 0) return;
            await _semaphore.WaitAsync();
            await task;
            _semaphore.Release();
        }
    }
}
