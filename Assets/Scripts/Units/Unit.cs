using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitParameters _parameters;

    public UnitParameters Parameters => _parameters;

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
