using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class SpawnerSystem : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _ball;

        [Header("Objects Reference")]
        [SerializeField] private Transform _spawner;
        [SerializeField] private Transform _targetsContainer;

        [Header("Parameters")]
        [SerializeField] private float _speedMove;
        [SerializeField] [Tooltip("In milliseconds")] private float _spawnRate;

        private List<Vector3> _targetsPosition;
        private List<Transform> _balls;

        private void Awake()
        {
            Transform[] targets = _targetsContainer.GetComponentsInChildren<Transform>();
            // Ignore the position 0 Transform (it's the parent)
            for (int i = 1; i < targets.Length; i++)
            {
                _targetsPosition.Add(targets[i].localPosition);
            }
        }

    }
}