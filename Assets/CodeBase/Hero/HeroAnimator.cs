using UnityEngine;

namespace CodeBase.Hero
{
  public class HeroAnimator : MonoBehaviour
  {
    [SerializeField] private Animator _animator;
    
    private readonly int _moveHash = Animator.StringToHash("Walking");
    private readonly int _attackHash = Animator.StringToHash("Attack");
    private readonly int _dieHash = Animator.StringToHash("Die");
    private readonly int _downHash = Animator.StringToHash("Down");
    private readonly int _dieFinallyHash = Animator.StringToHash("FinallyDeath");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    private readonly int _squat = Animator.StringToHash("Squat");
    private readonly int _idleHash = Animator.StringToHash("Idle");

    public void PlayAttack() => _animator.SetTrigger(_attackHash);
    public void PlayDeath() =>  _animator.SetTrigger(_dieHash);
    public void PlayFinallyDeath() =>  _animator.SetTrigger(_dieFinallyHash);
    public void PlayFinallyDown() =>  _animator.SetTrigger(_downHash);

    public void Jump() => _animator.SetTrigger(_jumpHash);
    public void Move() => _animator.SetTrigger(_moveHash);
    public void Idle() => _animator.SetTrigger(_idleHash);
    public void Squat() => _animator.SetTrigger(_squat);
  }
}
