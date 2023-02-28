using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _fillArea;

        public void SetValue(float current, float max) =>
            _fillArea.fillAmount = current / max;
    }
}