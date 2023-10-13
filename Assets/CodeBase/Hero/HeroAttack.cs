using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Hero;
using UnityEngine;

public class HeroAttack : MonoBehaviour
{   
    public HeroAnimator Animator;
    private bool _isAttack;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !_isAttack)
        {
            _isAttack = true;

            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        Animator.PlayAttack();

        yield return new WaitForSeconds(5);

        _isAttack = false;
    }
}
