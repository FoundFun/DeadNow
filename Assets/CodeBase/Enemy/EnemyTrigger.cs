using UnityEngine;

namespace CodeBase
{
    public class EnemyTrigger : MonoBehaviour
    {
        public EnemyAnimator Animator;
        
        public bool IsDead { get; private set; } 

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent<HeroAttack>(out HeroAttack heroAttack) && !IsDead)
            {
                if (heroAttack.IsAttack)
                {
                    IsDead = true;
                    Animator.Death();
                }
            }
        }

        public void Reset()
        {
            IsDead = false;
        }
    }
}