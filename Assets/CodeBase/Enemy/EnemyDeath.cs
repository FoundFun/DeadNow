using CodeBase.Enemy;
using CodeBase.Logic;
using UnityEngine;

[RequireComponent(typeof(SpeakerController))]
public class EnemyDeath : Death
{
    [SerializeField] private SpeakerText _deathText;
    [SerializeField] private SpeakerController _speakerController;
    [SerializeField] private EnemyAnimator _animator;

    public override void Die()
    {
        base.Die();
        EventController.DeactivateEvent<EnemyDialog>(gameObject);
        _speakerController.ShowText(_deathText);
        _animator.Death();
    }
}
