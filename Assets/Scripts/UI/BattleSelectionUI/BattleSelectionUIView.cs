using UnityEngine;

namespace Command.UI
{
    public class BattleSelectionUIView : MonoBehaviour, IUIView
    {
        [SerializeField] private Transform battleButtonContainer;

        public void DisableView() => gameObject.SetActive(false);

        public void EnableView() => gameObject.SetActive(true);

        public BattleButtonView AddButton(BattleButtonView battleButtonPrefab) => Instantiate(battleButtonPrefab, battleButtonContainer);
    }
}
