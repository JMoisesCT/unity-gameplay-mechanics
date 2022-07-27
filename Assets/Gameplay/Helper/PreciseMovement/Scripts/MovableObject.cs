using UnityEngine;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class MovableObject : MonoBehaviour
    {
        private bool _isAlive;
        private Vector3 _speed;

        private void Awake()
        {
            _isAlive = false;    
        }

        public void Initialize()
        {
            _isAlive = true;
        }

        public void SetSpeed(float speedX, float speedY)
        {
            _speed = new Vector3(speedX, speedY, 0f);
        }

        public void SetPosition(float posX, float posY)
        {
            transform.localPosition = new Vector3(posX, posY, 0f);
        }

        private void Update()
        {
            if (_isAlive)
            {
                transform.localPosition += _speed * Time.deltaTime;
            }
        }
    }
}
