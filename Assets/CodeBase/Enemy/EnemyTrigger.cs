using UnityEngine;

namespace CodeBase
{
    public class EnemyTrigger : MonoBehaviour
    {
        public EnemyAnimator Animator;
        
        private void OnTriggerStay(Collider other)
        {
            if (other.GetComponent<HeroAttack>().IsAttack)
                Animator.Death();
        }
    }
}