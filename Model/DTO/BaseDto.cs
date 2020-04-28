using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Model.DTO
{
    public class BaseDto : object, IDisposable
    {
        private readonly SafeHandle _handle = new SafeFileHandle(IntPtr.Zero, true);
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _handle.Dispose();
            _disposed = true;
        }
    }
}