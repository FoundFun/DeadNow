using UnityEngine;

namespace PixelWeatherAsset.Scripts
{
    public class RainController : MonoBehaviour
    {
        [Range(0, 1f)] [SerializeField] private float _masterIntensity = 1f;
        [Range(0, 1f)] [SerializeField] private float _rainIntensity = 0.7f;
        [Range(0, 1f)] [SerializeField] private float _windIntensity = 0.5f;
        [Range(0, 1f)] [SerializeField] private float _fogIntensity = 0.25f;
        [Range(0, 1f)] [SerializeField] private float _lightningIntensity = 1f;

        [SerializeField] private ParticleSystem _rainPart;
        [SerializeField] private ParticleSystem _windPart;
        [SerializeField] private ParticleSystem _lightningPart;
        [SerializeField] private ParticleSystem _fogPart;
        [SerializeField] private bool _autoUpdate;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _thunder;
        [SerializeField] private AudioClip _thunder2;
        [SerializeField] private AudioClip _thunder3;
        [SerializeField] private AudioClip _thunder4;

        private ParticleSystem.EmissionModule _rainEmission;
        private ParticleSystem.ForceOverLifetimeModule _rainForce;
        private ParticleSystem.EmissionModule _windEmission;
        private ParticleSystem.MainModule _windMain;
        private ParticleSystem.EmissionModule _lightningEmission;
        private ParticleSystem.EmissionModule _fogEmission;

        private float _delayThunder;

        private void Awake()
        {
            _rainEmission = _rainPart.emission;
            _rainForce = _rainPart.forceOverLifetime;
            _windEmission = _windPart.emission;
            _windMain = _windPart.main;
            _lightningEmission = _lightningPart.emission;
            _fogEmission = _fogPart.emission;
            UpdateAll();
        }

        private void Update()
        {
            if (_autoUpdate)
                UpdateAll();
        }

        private void UpdateAll()
        {
            _rainEmission.rateOverTime = 200f * _masterIntensity * _rainIntensity;
            _rainForce.x = new ParticleSystem.MinMaxCurve(-25f * _windIntensity * _masterIntensity,
                (-3 - 30f * _windIntensity) * _masterIntensity);
            _windEmission.rateOverTime = 5f * _masterIntensity * (_windIntensity + _fogIntensity);
            _windMain.startLifetime = 2f + 5f * (1f - _windIntensity);
            _windMain.startSpeed = new ParticleSystem.MinMaxCurve(15f * _windIntensity, 25 * _windIntensity);
            _fogEmission.rateOverTime =
                (1f + (_rainIntensity + _windIntensity) * 0.5f) * _fogIntensity * _masterIntensity;

            if (_rainIntensity * _masterIntensity < 0.7f)
            {
                _lightningEmission.rateOverTime = 0;
            }
            else
            {
                _lightningEmission.rateOverTime = _lightningIntensity * _masterIntensity * 0.4f;
            }

            if (_lightningEmission.rateOverTime.constant > 0 && _delayThunder > 10)
            {
                AudioClip clip = Random.Range(0, 4) switch
                {
                    0 => _thunder,
                    1 => _thunder2,
                    2 => _thunder3,
                    3 => _thunder4,
                    _ => _thunder
                };
                
                _audioSource.PlayOneShot(clip);
                _delayThunder = 0;
            }

            _delayThunder += Time.deltaTime;
        }

        private void OnMasterChanged(float value)
        {
            _masterIntensity = value;
            UpdateAll();
        }

        private void OnRainChanged(float value)
        {
            _rainIntensity = value;
            UpdateAll();
        }

        private void OnWindChanged(float value)
        {
            _windIntensity = value;
            UpdateAll();
        }

        private void OnLightningChanged(float value)
        {
            _lightningIntensity = value;
            UpdateAll();
        }

        private void OnFogChanged(float value)
        {
            _fogIntensity = value;
            UpdateAll();
        }
    }
}