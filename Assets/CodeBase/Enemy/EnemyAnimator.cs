using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        public Animator Animator;
        
        private static readonly int DeathHash = Animator.StringToHash("Death");
        
        public void Death() => Animator.SetTrigger(DeathHash);
    }
}