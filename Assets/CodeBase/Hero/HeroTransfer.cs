using System.Collections;
using System.Collections.Generic;
using CodeBase.Hero;
using UnityEngine;

public class HeroTransfer : MonoBehaviour
{
    public HeroAnimator Animator;
    private bool _isTransfer;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && !_isTransfer)
        {
            _isTransfer = true;

            StartCoroutine(Transfer());
        }
    }

    private IEnumerator Transfer()
    {
        Animator.Transfer();

        yield return new WaitForSeconds(5);

        _isTransfer = false;
    }
}
