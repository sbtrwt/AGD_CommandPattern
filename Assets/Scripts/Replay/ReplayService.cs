using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Replay
{
    public class ReplayService
    {
        public ReplayState ReplayState { get; private set; }

        public ReplayService() => SetReplayState(ReplayState.DEACTIVE);

        private void SetReplayState(ReplayState stateToSet) => ReplayState = stateToSet;
    }

    public enum ReplayState
    {
        ACTIVE,
        DEACTIVE
    }
}