using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Command.UI
{
    public class GameplayUIView : MonoBehaviour, IUIView
    {
        private GameplayUIController controller;
        [SerializeField] TextMeshProUGUI turnText;
        [SerializeField] Button undoButton;
        [SerializeField] TextMeshProUGUI missedText;

        public void SetController(GameplayUIController controllerToSet) 
        {
            controller = controllerToSet;
            undoButton.onClick.AddListener(controller.OnUndoButtonClicked);
            missedText.canvasRenderer.SetAlpha(0);
        }

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public void SetTurnText(string turnText) => this.turnText.SetText(turnText);

        public void ShowMissedText()
        {
            missedText.SetText("Missed!");
            missedText.canvasRenderer.SetAlpha(1);
            missedText.CrossFadeAlpha(0, 2, false);
        }
    }
}