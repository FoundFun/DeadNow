using System;
using Agava.YandexGames;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.Yandex
{
    public class YandexAuthorizationView : MonoBehaviour
    {
        [SerializeField] private Image _bordAuthorization;
        [SerializeField] private Button _acceptButton;
        [SerializeField] private Button _rejectButton;

        public event Action AcceptButtonClick;

        private void OnEnable()
        {
            _acceptButton.onClick.AddListener(OnAcceptButtonClick);
            _rejectButton.onClick.AddListener(Close);
        }

        private void OnDisable()
        {
            _acceptButton.onClick.RemoveListener(OnAcceptButtonClick);
            _rejectButton.onClick.RemoveListener(Close);
        }

        private void OnAcceptButtonClick()
        {
            if (!PlayerAccount.IsAuthorized)
                AcceptButtonClick?.Invoke();
            
            Close();
        }

        public void Open()
        {
            const float timeAnimation = 0.2f;

            _bordAuthorization.transform.DOScale(Vector3.one, timeAnimation);
            _bordAuthorization.raycastTarget = true;
            _acceptButton.interactable = true;
            _rejectButton.interactable = true;
        }

        private void Close()
        {
            const float timeAnimation = 0.2f;

            _bordAuthorization.transform.DOScale(Vector3.zero, timeAnimation);
            _bordAuthorization.raycastTarget = false;
            _acceptButton.interactable = false;
            _rejectButton.interactable = false;
        }
    }
}