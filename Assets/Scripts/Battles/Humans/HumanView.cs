using Foundations.MVVM;
using System;
using UnityEngine;

namespace Battles.Humans
{
    public class HumanView : MonoBehaviour, IHumanView
    {
        Human owner;

        Action<object> IModelView.tick1 { get => m_tick1_ac; set => m_tick1_ac = value; }
        Action<object> m_tick1_ac;

        //==================================================================================================

        void IModelView<Human>.attach(Human owner)
        {
            this.owner = owner;
        }


        void IModelView<Human>.detach(Human owner)
        {
            this.owner = null;
        }


        void IHumanView.notify_on_tick1()
        {
            transform.localPosition = owner.view_pos;
            transform.localRotation = owner.view_rotation;
            transform.localScale = new(1, owner.view_filp, 1);

            m_tick1_ac?.Invoke(owner);
        }
    }
}

