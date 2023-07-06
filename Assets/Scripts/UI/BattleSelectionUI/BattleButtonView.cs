using UnityEngine;
using UnityEngine.UI;
using Command.Main;
using TMPro;

namespace Command.UI
{
    public class BattleButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonText;
        private BattleSelectionController owner;
        private int battleId;

        private void Start() => GetComponent<Button>().onClick.AddListener(OnBattleButtonClicked);

        public void SetOwner(BattleSelectionController owner) => this.owner = owner;

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        private void OnBattleButtonClicked() => owner.OnBattleSelected(battleId);

        public void SetBattleID(int battleId)
        {
            this.battleId = battleId;
            buttonText.SetText("Battle " + battleId);
        }

    }
}