using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform Following;
     public float Speed;
     
     private void LateUpdate()
    {
        if (Following == null)
            return;

        Vector3 targetPosition = new Vector3(Following.position.x, Following.position.y + 2, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);;
    }
}