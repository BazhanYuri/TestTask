using System;
using UnityEngine;
using DG.Tweening;


namespace TestTask
{
    public class TileVisualEffects : MonoBehaviour
    {
        [SerializeField] private Transform _visual;



        public static event Action TileOpened;


        private bool _isShowed = false;
        private Vector3 _scale;

        private void OnEnable()
        {
            _scale = _visual.lossyScale;
            ShowAtStart();
        }
        private void ShowAtStart()
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(_visual.DOPunchScale(_scale * 0.2f, 1, 5, 2));
            seq.Append(_visual.DOScale(Vector3.zero, 0.5f));
        }
        public void Show()
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(_visual.DOScale(Vector3.one, 0.5f));
            seq.Append(_visual.DOPunchScale(_scale * 0.2f, 1, 5, 2));

            if (_isShowed == true)
            {
                return;
            }

            TileOpened?.Invoke();
            _isShowed = true;
        }
       
    }
}

