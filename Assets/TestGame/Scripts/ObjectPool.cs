using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestGame.Scripts
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly Func<T> _factoryMethod;
        private readonly List<T> _objects;
        private readonly Action<T> _turnOnCallback;
        private readonly Action<T> _turnOffCallback;

        public ObjectPool(Func<T> factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int amount = 10)
        {
            _factoryMethod = factoryMethod;
            _turnOnCallback = turnOnCallback;
            _turnOffCallback = turnOffCallback;
            
            _objects = new List<T>();

            for (int i = 0; i < amount; i++)
            {
                var objectExample = _factoryMethod();
                _turnOffCallback(objectExample);
                _objects.Add(objectExample);
            }
        }

        public T GetObject()
        {
            var result = default(T);
            
            if (_objects.Count > 0)
            {
                result = _objects[0];
                _objects.RemoveAt(0);
            }
            else
            {
                result = _factoryMethod();
            }

            _turnOnCallback(result);
            return result;
        }

        public void ReturnObject(T objectExample)
        {
            _turnOffCallback(objectExample);
            _objects.Add(objectExample);
        }
    }
}