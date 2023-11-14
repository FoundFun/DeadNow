using System.Collections;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}