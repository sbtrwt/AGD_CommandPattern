using System.Collections.Generic;
using UnityEngine;
using Command.Main;
using UnityEngine.UI;

namespace Command.Battle
{
    public class BattleService
    {
        private List<BattleScriptableObject> battleScriptableObjects;
        private Image backgroundImage;
        private int currentBattleId;

        public BattleService(List<BattleScriptableObject> battleScriptableObjects, Image backgroundImage)
        {
            this.battleScriptableObjects = battleScriptableObjects;
            this.backgroundImage = backgroundImage;
            SubscribeToEvents();
            backgroundImage.gameObject.SetActive(false);
        }

        private void SubscribeToEvents() => GameService.Instance.EventService.OnBattleSelected.AddListener(LoadBattle);

        private void LoadBattle(int battleId)
        {
            currentBattleId = battleId;
            var battleDataToLoad = GetBattleDataByID(battleId);
            SetBackgroundImage(battleDataToLoad.BattleBackgroundImage);
            GameService.Instance.UIService.ShowGameplayView();
            GameService.Instance.PlayerService.Init(battleDataToLoad.Player1Data, battleDataToLoad.Player2Data);
        }

        private BattleScriptableObject GetBattleDataByID(int battleId) => battleScriptableObjects.Find(battleSO => battleSO.BattleID == battleId);

        private void SetBackgroundImage(Sprite bgSprite)
        {
            backgroundImage.gameObject.SetActive(true);
            backgroundImage.sprite = bgSprite;
        }
    }
}
