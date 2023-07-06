using UnityEngine;

namespace Command.Player
{
    [CreateAssetMenu(fileName = "BattleScriptableObject", menuName = "ScriptableObjects/BattleScriptableObject")]
    public class BattleScriptableObject : ScriptableObject
    {
        public int BattleID;
        public PlayerScriptableObject Player1Data;
        public PlayerScriptableObject Player2Data;
    }
}