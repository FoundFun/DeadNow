using UnityEngine;

namespace CodeBase.Hero
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public static readonly int MoveHash = Animator.StringToHash("Walking");
        public static readonly int AttackHash = Animator.StringToHash("Attack");
        public static readonly int HitHash = Animator.StringToHash("Hit");
        public static readonly int DieHash = Animator.StringToHash("Die");
        public static readonly int DownHash = Animator.StringToHash("Down");
        public static readonly int DieFinallyHash = Animator.StringToHash("FinallyDeath");
        public static readonly int JumpHash = Animator.StringToHash("Jump");
        public static readonly int TransferHash = Animator.StringToHash("Transfer");
        public static readonly int IdleStateHash = Animator.StringToHash("Idle");
        public static readonly int AttackStateHash = Animator.StringToHash("Attack");
        public static readonly int WalkingStateHash = Animator.StringToHash("Walking");
        public static readonly int DeathStateHash = Animator.StringToHash("Die");

        public void SetAnimation(int animationHash) => _animator.SetTrigger(animationHash);
    }
}
