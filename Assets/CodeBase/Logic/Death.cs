using System;
using UnityEngine;

public class Death : MonoBehaviour, IEventActivation, IEventDeactivation
{
    public bool IsDead { get; protected set; }

    public event Action OnDeath;

    public void Activate()
    {
        Die();
    }

    public void Deactivate()
    {
        IsDead = false;
    }

    public virtual void Die()
    {
        if (IsDead)
            return;

        OnDeath?.Invoke();
        IsDead = true;
    }
}
