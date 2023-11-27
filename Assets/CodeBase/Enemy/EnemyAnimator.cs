using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent (typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private Animator _animator;
        
        private static readonly int DeathHash = Animator.StringToHash("Death");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Death() => _animator.SetTrigger(DeathHash);
    }
}