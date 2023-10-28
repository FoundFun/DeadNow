using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static List<Enemy> _enemies = new List<Enemy>();

    public static List<Enemy> Enemies => _enemies;

    protected virtual void Start()
    {
        _enemies.Add(this);
    }

    private void OnDestroy()
    {
        _enemies.Remove(this);
    }
}
