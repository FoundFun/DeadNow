using CodeBase.Services;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}