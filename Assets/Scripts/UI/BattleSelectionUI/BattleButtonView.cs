using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Command.UI
{
    public class BattleButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        private BattleSelectionUIController owner;
        private int battleId;

        private void Start() => GetComponent<Button>().onClick.AddListener(OnBattleButtonClicked);

        public void SetOwner(BattleSelectionUIController owner) => this.owner = owner;

        private void OnBattleButtonClicked() => owner.OnBattleSelected(battleId);

        public void SetBattleID(int battleId)
        {
            this.battleId = battleId;
            buttonText.SetText("Battle " + battleId);
        }

    }
}