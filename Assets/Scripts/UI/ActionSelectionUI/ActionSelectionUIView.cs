using UnityEngine;

namespace Command.UI
{
    public class ActionSelectionUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private Transform actionButtonContainer;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public ActionButtonView AddButton(ActionButtonView actionButtonPrefab) => Instantiate(actionButtonPrefab, actionButtonContainer);

        public void SetContainerToLeft() => actionButtonContainer.localPosition = new Vector3(-469, actionButtonContainer.localPosition.y, 0);

        public void SetContainerToRight() => actionButtonContainer.localPosition = new Vector3(469, actionButtonContainer.localPosition.y, 0);

        public void RemoveButton(ActionButtonView buttonToDestroy) => Destroy(buttonToDestroy.gameObject);
    }
}