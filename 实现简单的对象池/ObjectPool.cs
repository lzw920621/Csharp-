using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 实现简单的对象池
{

    //博客原文:https://www.cnblogs.com/TianFang/p/3411399.html
    public class ObjectPool<T>
    {
        ConcurrentBag<T> buffer;
        Func<T> createFunc;
        Action<T> resetFunc;

        public ObjectPool(Func<T> createFunc, Action<T> resetFunc, int capacity)
        {
            Contract.Assume(createFunc != null);
            Contract.Assume(capacity > 0);

            this.buffer = new ConcurrentBag<T>();
            this.createFunc = createFunc;
            this.resetFunc = resetFunc;

            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }
        public int Count { get { return buffer.Count; } }

        /// <summary>
        /// 申请对象
        /// </summary>
        public T GetObject()
        {
            var obj = default(T);

            if (!buffer.TryTake(out obj))
                return createFunc();
            else
                return obj;
        }

       
        public void PutObject(T obj)
        {
            Contract.Assume(obj != null);

            if (Count >= Capacity)        //超过容量了，不再需要
                return;

            if (resetFunc != null)
                resetFunc(obj);

            buffer.Add(obj);
        }
    }
}
