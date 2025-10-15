using System.Collections.Generic;
using UnityEngine;

namespace _02.Code.Pooling
{
    public class PoolFactory<T> where T : MonoBehaviour
    {
        private T _prefab;
        private Stack<T> _pool = new();

        public PoolFactory(T prefab)
        {
            _prefab = prefab;
        }

        public void Push(T go)
        {
            _pool.Push(go);
            go.gameObject.SetActive(false);
        }

        public T Pop()
        {
            if (!_pool.TryPop(out T go))
            {
                go = Object.Instantiate(_prefab);
            }

            go.gameObject.SetActive(true);
            return go;
        }
    }
}