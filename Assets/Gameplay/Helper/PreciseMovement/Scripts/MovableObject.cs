using System;
using UnityEngine;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class MovableObject : MonoBehaviour
    {
        private bool _isAlive;
        private Vector3 _speed;
        private Vector2 _targetPosition;
        private int _targetIndex;

        public bool IsAlive => _isAlive;
        public int TargetIndex => _targetIndex;

        private void Awake()
        {
            _isAlive = false;
        }

        public void Initialize()
        {
            _isAlive = true;
        }

        public void ResetObject()
        {
            _isAlive = false;
            gameObject.SetActive(false);
        }

        public void SetSpeed(float speedX, float speedY)
        {
            _speed = new Vector3(speedX, speedY, 0f);
        }

        public void SetPosition(float posX, float posY)
        {
            transform.localPosition = new Vector3(posX, posY, 0f);
        }

        public void SetTarget(Vector2 targetPosition, int targetIndex)
        {
            _targetPosition = targetPosition;
            _targetIndex = targetIndex;
        }

        public void SetOffset(float timeOffset)
        {
            transform.localPosition += _speed * timeOffset;
        }

        public void UpdateMove()
        {
            if (_isAlive)
            {
                transform.localPosition += _speed * Time.deltaTime;
            }
        }

        public bool CheckIfTargetReached()
        {
            Vector3 nextPos = transform.localPosition + _speed * Time.deltaTime;
            if (_speed.x != 0f)
            {
                if (_speed.x > 0f && nextPos.x > _targetPosition.x ||
                    _speed.x < 0f && nextPos.x < _targetPosition.x)
                {
                    return true;
                }
            }
            if (_speed.y != 0f)
            {
                if (_speed.y > 0f && nextPos.y > _targetPosition.y ||
                    _speed.y < 0f && nextPos.y < _targetPosition.y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
