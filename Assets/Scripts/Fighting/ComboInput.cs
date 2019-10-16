using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fighting.ComboManager;

namespace Fighting.ComboManager.ComboInput
{
    public class ComboInput : MonoBehaviour
    {

        public AttackType type;

        public ComboInput(AttackType t)
        {
            type = t;
        }

        public bool isSameAs(ComboInput test)
        {
            return (type == test.type);
        }
    }
}