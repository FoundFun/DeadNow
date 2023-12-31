﻿using CodeBase.Infrastructure.GameBootstrapper;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using UnityEngine;
using UnityEngine.Serialization;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _bootstrapperPrefab;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();

            if (bootstrapper != null) return;

            Instantiate(_bootstrapperPrefab);
        }
    }
}