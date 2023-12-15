using System;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.SoundLogic
{
    public class SoundView : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;

        public event Action<bool> ChangedMusic;
        
        private void OnEnable() => 
            _toggle.onValueChanged.AddListener(OnChangedMusic);

        private void OnDisable() =>
            _toggle.onValueChanged.RemoveListener(OnChangedMusic);

        private void OnChangedMusic(bool isEnabled) => 
            ChangedMusic?.Invoke(isEnabled);
    }
}