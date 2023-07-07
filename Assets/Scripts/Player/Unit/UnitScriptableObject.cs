using System.Collections.Generic;
using UnityEngine;
using Command.Commands;

namespace Command.Player
{
    [CreateAssetMenu(fileName = "UnitScriptableObject", menuName = "ScriptableObjects/UnitScriptableObject")]
    public class UnitScriptableObject : ScriptableObject
    {
        public int UnitID;
        public UnitView UnitPrefab;
        public List<CommandType> executableCommands;

        // All the other Unit related Data:
        // Prefab,
        // Executable Command Types.
    }
}