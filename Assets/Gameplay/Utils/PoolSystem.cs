using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JMoisesCT.UnityMechanics.Utils
{
    public class PoolSystem<T> where T : MonoBehaviour
    {
        private Stack<T> _stackObjects;
        private GameObject _prefab;
        private Transform _container;

        public PoolSystem()
        {
            _stackObjects = new Stack<T>();
        }

        public void Initialize(int size, GameObject prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
            for (int i = 0; i < size; ++i)
            {
                _stackObjects.Push(CreateObject());
            }
        }

        public T GetFromPool()
        {
            if (_stackObjects.Count > 0)
            {
                return _stackObjects.Pop();
            }
            return CreateObject();
        }

        public void ReturnToPool(T poolObject)
        {
            _stackObjects.Push(poolObject);
        }

        private T CreateObject()
        {
            T instantiatedObject = Object.Instantiate(_prefab, _container).GetComponent<T>();
            instantiatedObject.gameObject.SetActive(false);
            return instantiatedObject;
        }
    }
}