using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace BasicTemplate.CodeBase.Yandex
{
    public class YandexLeaderBoardView : MonoBehaviour
    {
        [SerializeField] private List<LineBoardView> _boards;
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        public IReadOnlyList<LineBoardView> LineBoards => _boards;

        public event Action Open;

        private void OnEnable()
        {
            _openButton.onClick.AddListener(OnOpen);
            _closeButton.onClick.AddListener(CloseTopListPlayer);
        }

        private void OnDisable()
        {
            _openButton.onClick.RemoveListener(OnOpen);
            _closeButton.onClick.RemoveListener(CloseTopListPlayer);
        }
        
        private void OnOpen() => 
            Open?.Invoke();

        public void OpenTopListPlayer()
        {
            const float timeAnimation = 1f;

            gameObject.transform.DOScale(Vector3.one, timeAnimation).Elapsed();
        }

        private void CloseTopListPlayer()
        {
            const float timeAnimation = 0.5f;

            gameObject.transform.DOScale(Vector3.zero, timeAnimation).Elapsed();
        }
    }
}