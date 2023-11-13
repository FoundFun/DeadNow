using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BasicTemplate.CodeBase.Yandex
{
    public class LineBoardView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _number;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Image _badgeBest;

        private const string NullText = "";

        public void SetValue(int number, string publicName, int score)
        {
            _number.text = number.ToString();
            _name.text = publicName;
            _score.text = score.ToString();
            _badgeBest.enabled = true;
        }

        public void Clear()
        {
            _number.text = NullText;
            _name.text = NullText;
            _score.text = NullText;
            _badgeBest.enabled = false;
        }
    }
}