using System.Collections.Generic;
using UnityEngine;

namespace Command.Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObejcts/PlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public int PlayerID;
        public List<UnitScriptableObject> UnitData;
    }
}