using BasicTemplate.CodeBase.Services.Load;
using UnityEngine;

namespace BasicTemplate.CodeBase.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;
        
        private const int MainScene = 1;

        private void Awake() => 
            DontDestroyOnLoad(this);

        private void Start() => 
            _sceneLoader.LoadMenu(MainScene);
    }
}