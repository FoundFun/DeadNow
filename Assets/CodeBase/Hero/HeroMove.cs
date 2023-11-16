using CodeBase.Data;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Services;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Hero
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(HeroAnimator))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private float _speed;

        private const float MaxVelocityX = 5;
        private const float MinVelocityX = -5;

        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider2D;
        private HeroAnimator _heroAnimator;
        private IInputService _inputService;
        private Vector2 _direction;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _heroAnimator = GetComponent<HeroAnimator>();
            
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update() => 
            _direction = _inputService.Axis;

        private void FixedUpdate()
        {
            if (_direction.x != 0 && WithinVelocity())
                Move();
        }

        private bool WithinVelocity() => 
            _rigidbody2D.velocity.x is < MaxVelocityX and > MinVelocityX;

        private void Move()
        {
            _heroAnimator.Move();
            _rigidbody2D.AddForce(Vector2.right * _direction.x * _speed, ForceMode2D.Force);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if(CurrentLevel() == progress.WorldData.PositionOnLevel.Level)
            {
                Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;

                if (savedPosition != null) 
                    Warp(to: savedPosition);
            }
        }
        
        private void Warp(Vector3Data to)
        {
            gameObject.SetActive(false);
            transform.position = to.AsUnityVector().AddY(_boxCollider2D.size.y);
            gameObject.SetActive(true);
        }

        public void UpdateProgress(PlayerProgress progress) => 
            progress.WorldData.PositionOnLevel = new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        
        private static string CurrentLevel() =>
            SceneManager.GetActiveScene().name;
    }
}