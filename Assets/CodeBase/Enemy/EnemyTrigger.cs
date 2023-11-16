using System;
using CodeBase.Hero;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        public EnemyAnimator Animator;
        public EnemySpeaker Speaker;
        public bool IsDead;

        public event Action Happened;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out HeroAttack heroAttack) && !IsDead)
            {
                Speaker.ShowText(Speaker.Tutorial);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out HeroAttack heroAttack) && !IsDead)
            {
                if (heroAttack.IsAttack)
                {
                    Speaker.ShowText(Speaker.Dead);
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