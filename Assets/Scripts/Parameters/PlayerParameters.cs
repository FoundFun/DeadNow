using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "CustomParameters/UnitParameters/PlayerParameters")]
public class PlayerParameters : UnitParameters
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _groundDistanceTrigger;
    [SerializeField] private float _minSpeedAttack;

    public float JumpForce => _jumpForce;
    public LayerMask GroundLayer => _groundLayer;
    public float GroundDistanceTrigger => _groundDistanceTrigger;
    public float MinSpeedAttack => _minSpeedAttack;
}
