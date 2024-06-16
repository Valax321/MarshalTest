using System.Buffers;
using JetBrains.Annotations;

namespace Radish;

public static class ArrayPoolExtensions
{
    /// <summary>
    /// Allows for renting an array from a pool with using expressions. 
    /// </summary>
    /// <param name="pool">The pool to rent from.</param>
    /// <param name="minimumSize">The size of array we want.</param>
    /// <param name="clearOnAcquire">Should the array be zeroed before being returned to you?</param>
    /// <param name="clearOnReturn">Should the array be cleared when we're done with it?</param>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <returns>Disposable wrapper for the array.</returns>
    [PublicAPI]
    public static RentalArray<T> Rent<T>(this ArrayPool<T> pool, int minimumSize, bool clearOnAcquire = false,
        bool clearOnReturn = false)
    {
        return new RentalArray<T>(minimumSize, clearOnAcquire, clearOnReturn, pool);
    }
    
    /// <summary>
    /// A disposable wrapper for an array from a pool.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    public struct RentalArray<T>
        : IDisposable
    {
        /// <summary>
        /// The actual array being rented.
        /// <exception cref="ObjectDisposedException">Thrown if this rental has been disposed already.</exception>
        /// </summary>
        [PublicAPI]
        public T[] Array
        {
            get
            {
                ObjectDisposedException.ThrowIf(_array is null, this);
                return _array;
            }
        }

        private T[]? _array;
        private readonly ArrayPool<T> _pool;
        private readonly bool _clearWhenDone;

        internal RentalArray(int minimumSize, bool clearOnAcquire, bool clearWhenDone,
            ArrayPool<T>? pool)
        {
            _pool = pool ?? ArrayPool<T>.Shared;
            _array = _pool.Rent(minimumSize);
            _clearWhenDone = clearWhenDone;
            if (clearOnAcquire)
                System.Array.Clear(_array);
        }

        /// <summary>
        /// Returns the array to the pool.
        /// </summary>
        public void Dispose()
        {
            if (_array is null) 
                return;
            
            _pool.Return(_array, _clearWhenDone);
            _array = null;
        }

        public static implicit operator T[](in RentalArray<T> wrapper)
        {
            return wrapper.Array;
        }
    }
}