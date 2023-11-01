using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    private static List<Enemy> _enemies = new List<Enemy>();

    public static List<Enemy> Enemies => _enemies;

    protected virtual void Start()
    {
        _enemies.Add(this);
    }

    protected override void OnDestroy()
    {
        _enemies.Remove(this);
    }
}
