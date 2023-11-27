using UnityEngine;

public class EventController
{
    public static void ActivateEvent<T>(GameObject gameObject) where T : IEventActivation
    {
        if (gameObject.TryGetComponent(out T component))
            component.Activate();
        else
            throw new System.NullReferenceException("The game object has no event component.");
    }

    public static void DeactivateEvent<T>(GameObject gameObject) where T : IEventDeactivation
    {
        if (gameObject.TryGetComponent(out T component))
            component.Deactivate();
        else
            throw new System.NullReferenceException("The game object has no event component.");
        }
}
