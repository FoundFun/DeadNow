using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Player _player;
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private Transform _groundCheckPos;

    private void FixedUpdate()
    {
        Move();

        if ((_moveJoystick.Direction.y > 0.5f || Input.GetKeyDown(KeyCode.Space)) && IsGround())
            Jump();
    }

    public void Move()
    {
        Vector2 movement = new Vector2(_moveJoystick.Direction.x * _player.PlayerParameters.MaxSpeed, _rigidBody2D.velocity.y);
        if (_rigidBody2D.velocity.x < _player.PlayerParameters.MaxSpeed)
            _rigidBody2D.AddForce(movement);
    }

    private void Jump()
    {
        _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, _player.PlayerParameters.JumpForce);
    }

    private bool IsGround()
    {
        return Physics2D.OverlapCircleAll(_groundCheckPos.position,
            _player.PlayerParameters.GroundDistanceTrigger, _player.PlayerParameters.GroundLayer).Length > 0;
    }
} 
