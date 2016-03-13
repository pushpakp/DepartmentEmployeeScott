using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeeAPp
{
    class CircularBuffer<T> : Buffer<T>
    {
        private int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);

            if (buffer.Count > _capacity)
            {
                buffer.Dequeue();
            }
        }
    }

    public class Buffer<T> : IBuffer<T>, IEnumerable<T>
    {
       protected  Queue<T> buffer = new Queue<T>();

        public virtual bool IsEmpty
        {
            get { return buffer.Count == 0; }
        }

        public virtual void Write(T value)
        {
            buffer.Enqueue(value);
        }

        public virtual T Read()
        {
          return  buffer.Dequeue();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return buffer.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in buffer)
            {
                yield return item;
            }
        }
    }
 

    public interface IBuffer<T>
    {
        bool IsEmpty { get; }
        void Write(T value);

         T Read();
    }
}
