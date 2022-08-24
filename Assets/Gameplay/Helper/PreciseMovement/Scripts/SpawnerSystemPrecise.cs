using JMoisesCT.UnityMechanics.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class SpawnerSystemPrecise : MonoBehaviour
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

        private PoolSystem<MovableObject> _poolSystem;
        private List<Transform> _targets;
        private List<MovableObject> _balls;
        private float _timer;

        private void Awake()
        {
            _poolSystem = new PoolSystem<MovableObject>();
            _poolSystem.Initialize(20, _ball, _ballsContainer);

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
                    MovableObject ball = _poolSystem.GetFromPool();
                    ball.gameObject.SetActive(true);
                    // Let's calculate the direction to the first target.
                    SetBallValues(ball, 0, _spawner, _targets[0]);
                    ball.Initialize();
                    _balls.Add(ball);
                    _timer = _spawnRate * 0.001f;
                }
            }

            bool shouldRemove = false;
            for (int i = 0; i < _balls.Count; ++i)
            {
                // Check if any ball has reached the target.
                if (_balls[i].CheckIfTargetReached())
                {
                    if(_balls[i].TargetIndex == _targets.Count - 1)
                    {
                        _balls[i].ResetObject();
                        _poolSystem.ReturnToPool(_balls[i]);
                        shouldRemove = true;
                    }
                    else
                    {
                        int ballIndex = _balls[i].TargetIndex;
                        SetBallValues(_balls[i], ballIndex + 1, _targets[ballIndex], _targets[ballIndex + 1]);
                    }
                }
                if (_balls[i].IsAlive)
                {
                    _balls[i].UpdateMove();
                }
            }
            // This removes not alive objects.
            if (shouldRemove)
            {
                _balls.RemoveAll(b => !b.IsAlive);
            }
        }

        private void SetBallValues(MovableObject ball, int indexTarget, Transform init, Transform target)
        {
            Vector2 direction = target.localPosition - init.localPosition;
            Vector2 speedToDirection = (direction / direction.magnitude) * _speedMove;
            ball.SetPosition(init.localPosition.x, init.localPosition.y);
            ball.SetSpeed(speedToDirection.x, speedToDirection.y);
            ball.SetTarget(target.localPosition, indexTarget);
        }
    }
}