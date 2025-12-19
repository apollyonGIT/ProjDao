using Battle;
using Commons;
using Foundations;
using Foundations.MVVM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Battles.Humans
{
    public interface IHumanView : IModelView<Human>
    {
        void notify_on_tick1();
    }


    public class Human : Model<Human, IHumanView>
    {
        public Vector2 pos;
        public Vector2 dir;
        public int filp = 1;

        public float angle;

        public Vector2 view_pos => pos;
        public Quaternion view_rotation => calc_view_rotation();
        public int view_filp => calc_view_flip();

        const int leap_deg = 15;

        //==================================================================================================

        public void tick()
        {
            var ctx = BattleContext.instance;

            if (ctx.is_moveAhead)
            {
                pos.x += 10f * Config.PHYSICS_TICK_DELTA_TIME;
            }

            ctx.main_pos = pos;

            dir = (BattleSceneRoot.instance.GetWorldMousePosition() - pos).normalized;
            angle = EX_Utility.convert_dir_to_angle(dir);
        }


        public void tick1()
        {
            foreach (var view in views)
            {
                view.notify_on_tick1();
            }
        }


        protected virtual Quaternion calc_view_rotation()
        {
            if (angle >= leap_deg && angle <= 90)
                dir = EX_Utility.convert_rad_to_dir(leap_deg * Mathf.Deg2Rad);
            if (angle >= 270 && angle <= 360 - leap_deg)
                dir = EX_Utility.convert_rad_to_dir(-leap_deg * Mathf.Deg2Rad);

            if (angle >= 90 && angle <= 180 - leap_deg)
            {
                var _angle = 180 - leap_deg;
                dir = new(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad));
            }
                
            if (angle >= 180 + leap_deg && angle <= 270)
            {
                var _angle = 180 + leap_deg;
                dir = new(Mathf.Cos(_angle * Mathf.Deg2Rad), Mathf.Sin(_angle * Mathf.Deg2Rad));
            }

            return EX_Utility.look_rotation_from_left(dir);
        }


        int calc_view_flip()
        {
            var ret = 1;
            if (angle > 90 && angle < 270)
                ret = -1;

            return ret;
        }
    }
}





