using UnityEngine;


[CreateAssetMenu(fileName = "UnitParameters", menuName = "CustomParameters/UnitParameters/UnitParameters")]
public class UnitParameters : ScriptableObject
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public float MaxSpeed => _maxSpeed;
    public float MinSpeed => _minSpeed;
}
