using Battles.Cameras;
using Battles.Humans;
using Foundations;
using UnityEngine;

namespace Battle.Cameras
{
    public class CameraPD : Producer
    {
        public override IMgr imgr => mgr;
        CameraMgr mgr;

        //==================================================================================================

        public override void init(int priority)
        {
            mgr = new("CameraMgr", priority);
        }


        public override void call()
        {
        }
    }
}

