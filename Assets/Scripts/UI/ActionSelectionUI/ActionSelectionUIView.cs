using UnityEngine;

namespace Command.UI
{
    public class ActionSelectionUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private Transform actionButtonContainer;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public ActionButtonView AddButton(ActionButtonView actionButtonPrefab) => Instantiate(actionButtonPrefab, actionButtonContainer);

        public void RemoveButton(ActionButtonView buttonToDestroy) => Destroy(buttonToDestroy.gameObject);
    }
}