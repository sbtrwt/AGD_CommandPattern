using UnityEngine;
using Command.Main;
using Command.Commands;

namespace Command.Player
{
    public class UnitController
    {
        public PlayerController Owner { get; private set; }
        private UnitScriptableObject unitScriptableObject;
        private UnitView unitView;

        public int UnitID { get; private set; }
        private UnitAliveState aliveState;
        private int currentHealth;
        public int CurrentPower;
        public UnitUsedState UsedState { get; private set; }

        public UnitController(PlayerController owner, UnitScriptableObject unitScriptableObject, Vector3 unitPosition)
        {
            Owner = owner;
            this.unitScriptableObject = unitScriptableObject;
            UnitID = unitScriptableObject.UnitID;

            InitializeView(unitPosition);
            InitializeVariables();
        }

        private void InitializeView(Vector3 positionToSet)
        {
            unitView = Object.Instantiate(unitScriptableObject.UnitPrefab);
            unitView.Controller = this;
            unitView.transform.position = positionToSet;
            unitView.SetUnitIndicator(false);
        }

        private void InitializeVariables()
        {
            currentHealth = unitScriptableObject.MaxHealth;
            CurrentPower = unitScriptableObject.Power;
            SetAliveState(UnitAliveState.ALIVE);
            SetUsedState(UnitUsedState.NOT_USED);
        }

        public void StartUnitTurn()
        {
            unitView.SetUnitIndicator(true);
            GameService.Instance.UIService.ShowActionSelectionView(unitScriptableObject.executableCommands);
        }

        private void SetAliveState(UnitAliveState stateToSet) => aliveState = stateToSet;

        public void SetUsedState(UnitUsedState stateToSet) => UsedState = stateToSet;

        public bool IsAlive() => aliveState == UnitAliveState.ALIVE;

        public void ProcessUnitCommand(UnitCommand commandToProcess) => GameService.Instance.CommandInvoker.ProcessCommand(commandToProcess);

        public void TakeDamage(int damageToTake)
        {
            currentHealth -= damageToTake;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                UnitDied();
            }
            else
            {
                // Play Hit Animation ???
            }

            unitView.UpdateHealthBar((float) currentHealth / unitScriptableObject.MaxHealth);
        }

        public void RestoreHealth(int healthToRestore)
        {
            currentHealth = currentHealth + healthToRestore > unitScriptableObject.MaxHealth ? unitScriptableObject.MaxHealth : currentHealth + healthToRestore;
            unitView.UpdateHealthBar((float)currentHealth / unitScriptableObject.MaxHealth);
        }

        private void UnitDied()
        {
            aliveState = UnitAliveState.DEAD;
            // Play Death Animation.
        }

        public void PlayActionAnimation(CommandType actionType)
        {
            if (actionType == unitScriptableObject.executableCommands[0])
                unitView.PlayAnimation(UnitAnimations.ACTION1);
            else if (actionType == unitScriptableObject.executableCommands[1])
                unitView.PlayAnimation(UnitAnimations.ACTION2);
            else
                throw new System.Exception($"No Animation found for the action type : {actionType}");
        }

        public void OnActionExecuted()
        {
            Debug.Log("An Action has been executed.");
            SetUsedState(UnitUsedState.USED);
            Owner.OnUnitTurnEnded();
            unitView.SetUnitIndicator(false);
        }

        public void Revive() => SetAliveState(UnitAliveState.ALIVE);

        public void Destroy() => Object.Destroy(unitView.gameObject);

        public void ResetUnitIndicator() => unitView.SetUnitIndicator(false);

    }

    public enum UnitUsedState
    {
        USED,
        NOT_USED
    }

    public enum UnitAliveState
    {
        ALIVE,
        DEAD
    }
}