using Commons;
using Foundations;
using Foundations.SceneLoads;
using UnityEngine;

namespace Worlds
{
    public class WorldSceneRoot : SceneRoot<WorldSceneRoot>
    {
        public string battle_scene_name;

        //==================================================================================================

        protected override void on_init()
        {
            base.on_init();
        }


        protected override void on_fini()
        {
            base.on_fini();
        }


        public void btn_enter_battle()
        {
            SceneLoad_Utility.load_scene_with_loading(battle_scene_name);
        }
    }
}

