using UnityEngine;

namespace PixelWeatherAsset.Scripts
{
    public class SnowController : MonoBehaviour
    {
        [Range(0, 1f)] [SerializeField] public float _masterIntensity = 1f;
        [Range(0, 1f)] [SerializeField] public float _snowIntensity = 1f;
        [Range(0, 1f)] [SerializeField] public float _windIntensity = 1f;
        [Range(0, 1f)] [SerializeField] public float _fogIntensity = 1f;
        [Range(0, 7f)] [SerializeField] public float _snowLevel;

        [SerializeField] public ParticleSystem _snowPart;
        [SerializeField] public ParticleSystem _windPart;
        [SerializeField] public ParticleSystem _fogPart;
        [SerializeField] private Material _snowMat;
        [SerializeField] public bool _autoUpdate;

        private const string SnowLevel = "_SnowLevel";

        private ParticleSystem.EmissionModule _snowEmission;
        private ParticleSystem.ForceOverLifetimeModule _snowForce;
        private ParticleSystem.ShapeModule _snowShape;
        private ParticleSystem.EmissionModule _windEmission;
        private ParticleSystem.MainModule _windMain;
        private ParticleSystem.EmissionModule _lightningEmission;
        private ParticleSystem.MainModule _lightningMain;
        private ParticleSystem.EmissionModule _fogEmission;

        private void Awake()
        {
            _snowEmission = _snowPart.emission;
            _snowShape = _snowPart.shape;
            _snowForce = _snowPart.forceOverLifetime;
            _windEmission = _windPart.emission;
            _windMain = _windPart.main;
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
            _snowEmission.rateOverTime = 110f * _masterIntensity * _snowIntensity;
            _snowShape.radius = 30f * Mathf.Clamp(_windIntensity, 0.4f, 1f) * _masterIntensity;
            _snowForce.x = new ParticleSystem.MinMaxCurve(-9f * _windIntensity, -3 - 14f * _windIntensity);
            _windEmission.rateOverTime = 14f * _masterIntensity * (_windIntensity + _fogIntensity);
            _windMain.startLifetime = 2f + 6f * (1f - _windIntensity);
            _windMain.startSpeed = new ParticleSystem.MinMaxCurve(15f * _windIntensity, 20 * _windIntensity);
            _fogEmission.rateOverTime = (_fogIntensity + (_snowIntensity + _windIntensity) * 0.5f) * _masterIntensity;
            _snowMat.SetFloat(SnowLevel, _snowLevel);
        }

        private void OnMasterChanged(float value)
        {
            _masterIntensity = value;
            UpdateAll();
        }

        private void OnSnowChanged(float value)
        {
            _snowIntensity = value;
            UpdateAll();
        }

        private void OnWindChanged(float value)
        {
            _windIntensity = value;
            UpdateAll();
        }

        private void OnFogChanged(float value)
        {
            _fogIntensity = value;
            UpdateAll();
        }

        private void OnSnowLevelChanged(float value)
        {
            _snowLevel = value;
            UpdateAll();
        }
    }
}