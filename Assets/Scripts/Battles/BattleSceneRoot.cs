using Commons;
using Foundations;
using Foundations.Tickers;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battle
{
    public class BattleSceneRoot : SceneRoot<BattleSceneRoot>
    {
        [Header("Ticker")]
        public Ticker_Mono ticker_mono;

        //==================================================================================================

        protected override void on_init()
        {
            ticker_mono.init(Config.PHYSICS_TICK_DELTA_TIME);

            BattleContext._init();
            BattleContext.instance.attach();

            base.on_init();
        }


        protected override void on_fini()
        {
            BattleContext.instance.detach();

            base.on_fini();
        }


        public Vector2 GetWorldMousePosition()
        {
            var mousePosition = Mouse.current.position.ReadValue();
            var pos = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));

            return pos;
        }
    }
}

