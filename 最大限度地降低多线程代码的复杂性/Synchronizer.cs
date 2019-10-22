using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 最大限度地降低多线程代码的复杂性
{
    class Synchronizer<TImpl, TIRead, TIWrite> where TImpl : TIWrite, TIRead
    {
        ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        TImpl _shared;

        public Synchronizer(TImpl shared)
        {
            _shared = shared;
        }

        public void Read(Action<TIRead> functor)
        {
            _lock.EnterReadLock();
            try
            {
                functor(_shared);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void Write(Action<TIWrite> functor)
        {
            _lock.EnterWriteLock();
            try
            {
                functor(_shared);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }
    }
}
