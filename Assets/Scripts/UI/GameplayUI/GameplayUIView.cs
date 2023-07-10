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

        public void SetController(GameplayUIController controllerToSet) 
        {
            controller = controllerToSet;
            undoButton.onClick.AddListener(controller.OnUndoButtonClicked);
        }

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public void SetTurnText(string turnText) => this.turnText.SetText(turnText);
    }
}