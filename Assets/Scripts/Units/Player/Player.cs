using System;
using UnityEngine;

public class Player : Unit
{
    [SerializeField] private AnimatorController _animatorController;

    public AnimatorController AnimatorController => _animatorController;
    public PlayerParameters PlayerParameters => (PlayerParameters)Parameters;
    public static Player Instance { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        if (Instance != null)
        {
            Debug.LogError($"Exists more than 1 instance of {typeof(Player).Name} class!");

            throw new Exception();
        }

        Instance = this;
    }

}
