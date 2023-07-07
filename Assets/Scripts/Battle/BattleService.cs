using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Command.Main;

namespace Command.Battle
{
    public class BattleService
    {
        private List<BattleScriptableObject> battleScriptableObjects;

        public BattleService(List<BattleScriptableObject> battleScriptableObjects)
        {
            this.battleScriptableObjects = battleScriptableObjects;
            SubscribeToEvents();
        }

        private void SubscribeToEvents() => GameService.Instance.EventService.OnBattleSelected.AddListener(LoadBattle);

        private void LoadBattle(int battleId)
        {
            var battleDataToLoad = GetBattleDataByID(battleId);
            GameService.Instance.UIService.ShowGameplayView(battleDataToLoad.BattleBackgroundImage);
            GameService.Instance.PlayerService.Init(battleDataToLoad.Player1Data, battleDataToLoad.Player2Data);
        }

        private BattleScriptableObject GetBattleDataByID(int battleId) => battleScriptableObjects.Find(battleSO => battleSO.BattleID == battleId);
    }
}
