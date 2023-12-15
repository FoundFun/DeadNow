using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure
{
    public class ScalableHorizontalLayoutGroup : LayoutGroup
    {
        [SerializeField] private RectTransform _canvasRectTransform;
        [SerializeField] private Transform _scaledObject;

        private float _originWidthScale = 1080;

        private Vector3 _startPosition;
        private bool _isChangeCameraView;

        protected override void Awake()
        {
            if (_canvasRectTransform.rect.width > _originWidthScale)
                _originWidthScale = 1920;
            else
                _originWidthScale = 1080;

            base.Awake();
        }

        public override void SetLayoutVertical()
        {
            _scaledObject.localScale = Vector3.one * _canvasRectTransform.rect.width / _originWidthScale;
            Vector3 upper = _scaledObject.localPosition;
            _scaledObject.localPosition = upper;
        }

        public override void CalculateLayoutInputVertical()
        {
        }

        public override void SetLayoutHorizontal()
        {
        }
    }
}