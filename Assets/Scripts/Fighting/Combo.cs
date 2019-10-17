using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fighting.ComboManager;
using Fighting.ComboManager.ComboInput;
using Fighting.ComboManager.Attack;

namespace Fighting.ComboManager.Combo
{
    public class Combo : MonoBehaviour
    {
        public string comboName;
        public List<ComboInput.ComboInput> inputs;
        public Attack.Attack comboAttack;
        public UnityEvent onInputted;
        private int curInput = 0;

        public bool continueCombo(ComboInput.ComboInput i)
        {
            if (i.type == inputs[curInput].type)
            {
                curInput++;
                if (curInput >= inputs.Count)
                {
                    onInputted.Invoke();
                    curInput = 0;
                }
                return true;
            }
            else
            {
                curInput = 0;
                return false;
            }
        }

        public ComboInput.ComboInput CurrentComboInput()
        {
            if (curInput >= inputs.Count) return null;

            return inputs[curInput];
        }

        public void ResetCombo()
        {
            curInput = 0;
        }
    }
}
