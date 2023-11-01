using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace BasicTemplate.CodeBase.SoundLogic
{
    public class SoundView : MonoBehaviour
    {
        public AudioMixerGroup Master;
        public Toggle Toggle;

        public event Action<bool> ChangedMusic;
        
        private void OnEnable() => 
            Toggle.onValueChanged.AddListener(OnChangedMusic);

        private void OnDisable() =>
            Toggle.onValueChanged.RemoveListener(OnChangedMusic);

        private void OnChangedMusic(bool isEnabled) => 
            ChangedMusic?.Invoke(isEnabled);
    }
}