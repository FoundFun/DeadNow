using System.Collections;
using CodeBase.Hero;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{   
    public HeroAnimator Animator;
    public Rigidbody2D Rigidbody2D;

    private const float _downSpeed = 0.1f;

    private bool _delay;
    
    public bool IsAttack { get; private set; }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !_delay)
        {
            _delay = true;

            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        Animator.PlayAttack();
        
        Rigidbody2D.AddForce(Vector2.down * _downSpeed);
        
        yield return new WaitForSeconds(0.2f);
        
        IsAttack = true;

        yield return new WaitForSeconds(1);

        _delay = false;
        IsAttack = false;
    }
}
