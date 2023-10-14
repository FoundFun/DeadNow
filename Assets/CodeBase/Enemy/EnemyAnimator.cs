﻿using UnityEngine;

namespace CodeBase
{
    public class EnemyAnimator : MonoBehaviour
    {
        public Animator Animator;
        
        private static readonly int DeathHash = Animator.StringToHash("Death");
        
        public void Death() => Animator.SetTrigger(DeathHash);
    }
}