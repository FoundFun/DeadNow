using System;
using CodeBase.Hero;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        public EnemyAnimator Animator;
        public bool IsDead;

        public event Action Happened;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out HeroAttack heroAttack) && !IsDead)
            {
                EventController.ActivateEvent<SpeakerController>(gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out HeroAttack heroAttack) && !IsDead)
            {
                if (heroAttack.IsAttack)
                {
                    EventController.DeactivateEvent<SpeakerController>(gameObject);
                    IsDead = true;
                    Happened?.Invoke();
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