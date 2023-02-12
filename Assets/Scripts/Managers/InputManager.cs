using System;
using UnityEngine;


namespace TestTask
{
    [Serializable]
    public class TouchControlToDetect
    {
        [Range(0f, 1f)] public float _minWidth;
        [Range(0f, 1f)] public float _maxWidth;

        [Range(0f, 1f)] public float _minHeight;
        [Range(0f, 1f)] public float _maxHeight;
    }


    public enum InvokeTouchType
    {
        BallRight,
        BallLeft,
        PanelRight,
        PanelLeft,
        None
    }
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private TouchControlToDetect _ballRightMovInfo;
        [SerializeField] private TouchControlToDetect _ballLeftMovInfo;

        [SerializeField] private TouchControlToDetect _rightPanelInfo;
        [SerializeField] private TouchControlToDetect _leftPanelInfo;

        public static event Action<InvokeTouchType> ScreenTouched; 
        public static event Action TouchEnded;


        private Touch _touch;


        private void Update()
        {
            CheckInput();
        }
        private void CheckInput()
        {
            if (Input.touchCount < 1)
            {
                return;
            }
            _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    DetectTypeOfTouch();
                    break;
                case TouchPhase.Moved:
                    DetectTypeOfTouch();
                    break;
                case TouchPhase.Stationary:
                    DetectTypeOfTouch();
                    break;
                case TouchPhase.Ended:
                    TouchEnded?.Invoke();
                    break;
                case TouchPhase.Canceled:
                    TouchEnded?.Invoke();
                    break;
                default:
                    break;
            }
        }
        
        private void DetectTypeOfTouch()
        {
            InvokeTouchType invokeTouchType = InvokeTouchType.None;

            if (IsTouchInZone(_ballRightMovInfo))
            {
                invokeTouchType = InvokeTouchType.BallRight;
            }
            else if (IsTouchInZone(_ballLeftMovInfo))
            {
                invokeTouchType = InvokeTouchType.BallLeft;
            }
            else if (IsTouchInZone(_rightPanelInfo))
            {
                invokeTouchType = InvokeTouchType.PanelRight;
            }
            else if (IsTouchInZone(_leftPanelInfo))
            {
                invokeTouchType = InvokeTouchType.PanelLeft;
            }

            ScreenTouched?.Invoke(invokeTouchType);
        }
        private bool IsTouchInZone(TouchControlToDetect touchControl)
        {
            float widthP = GetWidthTouchPercentage();
            float heightP = GetHeightTouchPercentage();

            bool width = widthP > touchControl._minWidth && widthP < touchControl._maxWidth;
            bool height = heightP > touchControl._minHeight && heightP < touchControl._maxHeight;

            if (width && height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private float GetWidthTouchPercentage()
        {
            return _touch.position.x / Screen.width;
        }
        private float GetHeightTouchPercentage()
        {
            return _touch.position.y / Screen.height;
        }

    }
}

