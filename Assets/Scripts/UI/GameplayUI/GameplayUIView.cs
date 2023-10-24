using Command.Input;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Command.UI
{
    public class GameplayUIView : MonoBehaviour, IUIView
    {
        private GameplayUIController controller;
        [SerializeField] TextMeshProUGUI turnText;
        [SerializeField] TextMeshProUGUI missedText;
        [SerializeField] Image Player1BackgroundOverlay;
        [SerializeField] Image Player2BackgroundOverlay;

        public void SetController(GameplayUIController controllerToSet) 
        {
            controller = controllerToSet;
            missedText.canvasRenderer.SetAlpha(0);
        }

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public void SetTurnText(string turnText) => this.turnText.SetText(turnText);

        public void ToggleActionChoosingBackgroundOverLay(bool isPlayer1)
        {
            ResetBackgroundOverlay();

            var color = Color.green;
            color.a = 0.185f;

            if (isPlayer1)
            {
                Player1BackgroundOverlay.color = color;
                Player1BackgroundOverlay.gameObject.SetActive(true);
                Player2BackgroundOverlay.gameObject.SetActive(false);
            }
            else
            {
                Player2BackgroundOverlay.color = color;
                Player2BackgroundOverlay.gameObject.SetActive(true);
                Player1BackgroundOverlay.gameObject.SetActive(false);
            }
        }

        public void ToggleTargetChoosingBackgroundOverLay(bool isPlayer1, TargetType targetType)
        {
            ResetBackgroundOverlay();

            var color = Color.red;
            color.a = 0.185f;

            switch (targetType)
            {
                case TargetType.Enemy:
                    var target = isPlayer1 ? Player2BackgroundOverlay : Player1BackgroundOverlay;
                    target.color = color;
                    target.gameObject.SetActive(true);
                    break;
                case TargetType.Friendly:
                    ToggleActionChoosingBackgroundOverLay(isPlayer1);
                    break;
            }
        }

        public void ResetBackgroundOverlay()
        {
            Player1BackgroundOverlay.gameObject.SetActive(false);
            Player2BackgroundOverlay.gameObject.SetActive(false);
        }

        public void ShowMissedText()
        {
            missedText.SetText("Missed!");
            missedText.canvasRenderer.SetAlpha(1);
            missedText.CrossFadeAlpha(0, 2, false);
        }
    }
}