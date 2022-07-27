using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class SpawnerSystemBasic : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField] private GameObject _ball;

        [Header("Objects References")]
        [SerializeField] private Transform _spawner;
        [SerializeField] private Transform _targetsContainer;
        [SerializeField] private Transform _ballsContainer;

        [Header("Parameters")]
        [SerializeField] private float _speedMove;
        [SerializeField] [Tooltip("In milliseconds")] private float _spawnRate;

        private List<Vector3> _targetsPosition;
        private List<MovableObject> _balls;
        private float _timer;

        private void Awake()
        {
            _targetsPosition = new List<Vector3>();

            Transform[] targets = _targetsContainer.GetComponentsInChildren<Transform>();
            // Ignore the position 0 Transform (it's the parent)
            for (int i = 1; i < targets.Length; i++)
            {
                _targetsPosition.Add(targets[i].localPosition);
            }

            _balls = new List<MovableObject>();

            _timer = _spawnRate * 0.001f; // To convert milliseconds to seconds.
        }

        private void Update()
        {
            if (_timer > 0f)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0f)
                {
                    MovableObject ball = Instantiate(_ball, _ballsContainer).GetComponent<MovableObject>();
                    // Let's calculate the direction to the first target.
                    Vector2 direction = _targetsPosition[0] - _spawner.localPosition;
                    Vector2 speedToDirection = (direction / direction.magnitude) * _speedMove;
                    ball.SetPosition(_spawner.localPosition.x, _spawner.localPosition.y);
                    ball.SetSpeed(speedToDirection.x, speedToDirection.y);
                    ball.Initialize();
                    _balls.Add(ball);
                    _timer = _spawnRate * 0.001f;
                }
            }
        }

    }
}