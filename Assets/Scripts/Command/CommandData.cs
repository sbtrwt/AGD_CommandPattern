using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command.Command
{
    public struct CommandData
    {
        public int ActorUnitID;
        public int TargetUnitID;
        public int ActorPlayerID;
        public int TargetPlayerID;

        public CommandData(int ActorUnitID, int TargetUnitID, int ActorPlayerID, int TargetPlayerID)
        {
            this.ActorUnitID = ActorUnitID;
            this.TargetUnitID = TargetUnitID;
            this.ActorPlayerID = ActorPlayerID;
            this.TargetPlayerID = TargetPlayerID;
        }
    }
}
