using System.Collections.Generic;
using UnityEngine;

namespace Command.Player
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/PlayerScriptableObject")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public int PlayerID;
        public List<UnitScriptableObject> UnitData;
        public List<Vector3> UnitPositions;
    }
}