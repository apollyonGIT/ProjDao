using UnityEngine;

namespace Battle
{
    public class BattleSceneInput : MonoBehaviour
    {

        //==================================================================================================

        public void OnMoveAhead()
        {
            ref var is_moveAhead = ref BattleContext.instance.is_moveAhead;
            is_moveAhead = !is_moveAhead;
        }
    }
}

