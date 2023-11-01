﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase
{
    public class HeroSpeaker : MonoBehaviour
    {
        public Text MapsChange;

        private Coroutine _coroutine;

        public void ShowText(Text text)
        {
            if(_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(OnShowText(text));
        }

        private IEnumerator OnShowText(Text text)
        {
            text.gameObject.LeanScale(new Vector3(0.009259259f, 0.009259259f, 0.009259259f), 1).setEaseOutBounce();

            yield return new WaitForSeconds(4);
        
            text.gameObject.LeanScale(Vector3.zero, 1).setEaseOutBounce();
        }
    }
}