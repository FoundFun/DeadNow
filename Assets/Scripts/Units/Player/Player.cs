using CodeBase.Hero;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private PlayerAnimator _playerAnimator;

    public PlayerAnimator PlayerAnimator => _playerAnimator;
    public PlayerParameters PlayerParameters => (PlayerParameters)Parameters;

}
