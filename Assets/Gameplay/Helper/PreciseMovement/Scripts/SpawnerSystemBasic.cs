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

        private List<Transform> _targets;
        private List<MovableObject> _balls;
        private float _timer;

        private void Awake()
        {
            _targets = new List<Transform>();

            Transform[] targets = _targetsContainer.GetComponentsInChildren<Transform>();
            // Ignore the position 0 Transform (it's the parent)
            for (int i = 1; i < targets.Length; ++i)
            {
                _targets.Add(targets[i]);
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
                    Vector2 direction = _targets[0].localPosition - _spawner.localPosition;
                    Vector2 speedToDirection = (direction / direction.magnitude) * _speedMove;
                    ball.SetPosition(_spawner.localPosition.x, _spawner.localPosition.y);
                    ball.SetSpeed(speedToDirection.x, speedToDirection.y);
                    ball.SetTarget(_targets[0].localPosition, 0);
                    ball.Initialize();
                    _balls.Add(ball);
                    _timer = _spawnRate * 0.001f;
                }
            }

            for (int i = 0; i < _balls.Count; ++i)
            {
                // Check if any ball has reached the target.
                if (_balls[i].CheckIfTargetReached())
                {
                    _balls[i].ResetObject();
                }
                if (_balls[i].IsAlive)
                {
                    _balls[i].UpdateMove();
                }
            }
        }
    }
}