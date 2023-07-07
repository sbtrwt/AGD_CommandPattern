using UnityEngine;
using Command.Player;

namespace Command.Battle
{
    [CreateAssetMenu(fileName = "BattleScriptableObject", menuName = "ScriptableObjects/BattleScriptableObject")]
    public class BattleScriptableObject : ScriptableObject
    {
        public int BattleID;
        public Sprite BattleBackgroundImage;
        public PlayerScriptableObject Player1Data;
        public PlayerScriptableObject Player2Data;
    }
}