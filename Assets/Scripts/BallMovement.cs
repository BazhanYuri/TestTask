using UnityEngine;


namespace TestTask
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _ballRB;
        [SerializeField] private float _speed;



        Vector3 _moveVector = Vector3.zero;



        private void OnEnable()
        {
            InputManager.ScreenTouched += CheckTouch;
            InputManager.TouchEnded += StopMoving;
            GameManager.GamePlayStarted += PushBallToUp;
        }
        private void OnDisable()
        {
            InputManager.ScreenTouched -= CheckTouch;
            InputManager.TouchEnded -= StopMoving;
            GameManager.GamePlayStarted -= PushBallToUp;
        }


        private void FixedUpdate()
        {
            Move();
        }


        private void CheckTouch(InvokeTouchType touchType)
        {
            if (touchType == InvokeTouchType.BallRight)
            {
                _moveVector = Vector3.right;
            }
            else if (touchType == InvokeTouchType.BallLeft)
            {
                _moveVector = Vector3.left;
            }
            Move();
        }
        private void StopMoving()
        {
            _moveVector = Vector3.zero;
        }
        private void Move()
        {
            _ballRB.AddForce(_moveVector * _speed);
        }
        private void PushBallToUp()
        {
            _ballRB.isKinematic = false;
            _ballRB.AddForce(Vector3.up * 700);
        }
    }
}

