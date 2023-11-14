using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBase.Infrastructure.Infrastructure.GameBootstrapper;
using CodeBase.Services;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressesReaders { get; }
        List<ISavedProgress> ProgressesWriters { get; }
        GameObject CreateHero(GameObject at);
        void Cleanup();
    }
}