using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{   
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private AudioSource AttackSound;
    [SerializeField] private AttackController _attackController;

    private const float _downSpeed = 0.1f;

    private bool _delay;
    private float speedAnimation;

    public bool IsAttack { get; private set; }

    private void Start()
    {
        speedAnimation = Player.Instance.PlayerParameters.MinSpeedAttack;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !_delay)
        {
            _delay = true;
            AttackSound.Play();
            Attack();
        }
    }

    public void Attack()
    {
        StartCoroutine(StartAttack());
    }

    private IEnumerator StartAttack()
    {
        var animator = Player.Instance.AnimatorController;
        animator.SetAnimation(Animation.Attack);
        _rigidbody2D.AddForce(Vector2.down * _downSpeed);
        animator.SetSpeed(speedAnimation);

        yield return new WaitForSeconds(speedAnimation);

        _attackController.Attack();
        _delay = false;
    }
}

