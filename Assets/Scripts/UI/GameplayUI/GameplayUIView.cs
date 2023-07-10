using TMPro;
using UnityEngine;

namespace Command.UI
{
    public class GameplayUIView : MonoBehaviour, IUIView
    {
        [SerializeField] TextMeshProUGUI turnText;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public void SetTurnText(string turnText) => this.turnText.SetText(turnText);
    }
}