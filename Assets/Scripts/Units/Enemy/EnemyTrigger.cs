using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public EnemySpeaker Speaker;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player))
            Speaker.ChangeFadeDialogText();
    }
}
