using System.Collections;
using UnityEngine;


namespace TestTask
{
    public enum PanelType
    {
        Right,
        Left
    }
    public class ForcePanel : MonoBehaviour
    {
        [SerializeField] private PanelType _panelType;
        [SerializeField] private HingeJoint _hingeJoint;
        [SerializeField] private float _timeToRotate;


        private void OnEnable()
        {
            InputManager.ScreenTouched += DetectTouch;
        }
        private void OnDisable()
        {
            InputManager.ScreenTouched -= DetectTouch;
        }
        private void DetectTouch(InvokeTouchType touchType)
        {
            bool isRight = touchType == InvokeTouchType.PanelRight && _panelType == PanelType.Right;
            bool isLeft = touchType == InvokeTouchType.PanelLeft && _panelType == PanelType.Left;

            if (isRight || isLeft)
            {
                StopAllCoroutines();
                StartCoroutine(RotatePanel());
            }
        }
        private IEnumerator RotatePanel()
        {
            _hingeJoint.useMotor = true;
            yield return new WaitForSeconds(_timeToRotate);
            _hingeJoint.useMotor = false;
        }
    }
}

