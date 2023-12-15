using System;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class ShowHideMobileUI : MonoBehaviour
    {
        [SerializeField] private GameObject _mobileUI;
        [SerializeField] private Button _heroJump;
        [SerializeField] private Button _heroAttack;
        [SerializeField] private Button _heroSquat;

        private bool IsMobilePlatform
        {
            get
            {
#if UNITY_EDITOR
                return UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.Android ||
                       UnityEditor.EditorUserBuildSettings.activeBuildTarget == UnityEditor.BuildTarget.iOS;
#else
                return Application.isMobilePlatform;
#endif
            }
        }

        private void Awake() =>
            _mobileUI.SetActive(IsMobilePlatform);

        private void OnEnable()
        {
            _heroJump.onClick.AddListener(OnJump);
            _heroAttack.onClick.AddListener(OnAttack);
            _heroSquat.onClick.AddListener(OnSquat);
        }

        private void OnDisable()
        {
            _heroJump.onClick.RemoveListener(OnJump);
            _heroAttack.onClick.RemoveListener(OnAttack);
            _heroSquat.onClick.RemoveListener(OnSquat);
        }

        private void OnJump() =>
            EventBus.Instance.HeroJump?.Invoke();

        private void OnAttack() =>
            EventBus.Instance.HeroAttack?.Invoke();

        private void OnSquat() =>
            EventBus.Instance.HeroSquat?.Invoke();
    }
}