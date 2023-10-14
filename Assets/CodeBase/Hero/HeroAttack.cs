using System.Collections;
using CodeBase.Hero;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{   
    public HeroAnimator Animator;

    public bool IsAttack { get; private set; }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !IsAttack)
        {
            IsAttack = true;

            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        Animator.PlayAttack();

        yield return new WaitForSeconds(1);

        IsAttack = false;
    }
}
