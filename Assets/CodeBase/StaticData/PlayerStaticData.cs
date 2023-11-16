using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Static Data/Hero")]
    public class PlayerStaticData : ScriptableObject
    {
        [SerializeField] private List<string> _actionTexts;
        [SerializeField] private List<string> _randomText;
    }
}