using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fighting.ComboManager.ComboInput;
using Fighting.ComboManager.Combo;
using Fighting.ComboManager.Attack;

namespace Fighting.ComboManager
{
    public enum AttackType { light = 0, heavy = 1 }
    [RequireComponent(typeof(ComboInput.ComboInput))]
    [RequireComponent(typeof(Combo.Combo))]
    [RequireComponent(typeof(Attack.Attack))]
    public class ComboManager : MonoBehaviour
    {
        [Header("Inputs")]
        public KeyCode lightKey;
        public KeyCode heavyKey;

        [Header("Attacks")]
        public Attack.Attack lightAttack;
        public Attack.Attack heavyAttack;
        public List<Combo.Combo> combos;
        public float comboLeeway = 0.2f;

        [Header("Components")]
        //private Animator anim;

        private Attack.Attack curAttack = null;
        private ComboInput.ComboInput lastInput = null;
        private List<int> currentCombos = new List<int>();
       
        private float timer = 0;
        private float leeway = 0;
        private bool skip = false;


        void Start()
        {
            //anim = GetComponent<Animator>();
            PrimeCombos();
        }

        void PrimeCombos()
        {
            for (int i = 0; i < combos.Count; i++)
            {
                Combo.Combo c = combos[i];
                c.onInputted.AddListener(() =>
                {
                    skip = true;
                    Attack(c.comboAttack);
                    ResetCombos();
                });
            }
        }

        void Update()
        {
            if (curAttack != null)
            {
                if (timer > 0)
                {
                    timer -= Time.deltaTime;

                }
                else
                {
                    curAttack = null;
                }
                return; 
            }

                if (currentCombos.Count > 0)
                {
                    leeway += Time.deltaTime;
                    if (leeway >= comboLeeway)
                    {
                        if (lastInput != null)
                        {
                            Attack(getAttackFromType(lastInput.type));
                            lastInput = null;
                        }

                        ResetCombos();
                    }
                }
                else
                {
                    leeway = 0;
                }


                ComboInput.ComboInput input = null;
                if (Input.GetKeyDown(lightKey))
                {
                    input = new ComboInput.ComboInput(AttackType.light);
                }

                if (Input.GetKeyDown(heavyKey))
                {
                    input = new ComboInput.ComboInput(AttackType.heavy);
                }

                if (input == null) return;
                lastInput = input;


                List<int> remove = new List<int>();
                for (int i = 0; i < currentCombos.Count; i++)
                {

                    Combo.Combo c = combos[currentCombos[i]];
                    if (c.continueCombo(input))
                    {
                        leeway = 0;
                    }
                    else
                    {
                        remove.Add(i);
                    }
                }

            if (skip)
            {
                skip = false;
                return;
            }

            for (int i = 0; i < combos.Count; i++)
            {
                if (currentCombos.Contains(i)) continue;
                if (combos[i].continueCombo(input))
                {
                    currentCombos.Add(i);
                    leeway = 0;
                }
            }

            foreach (int i in remove)
                {
                    currentCombos.RemoveAt(i);
                }

                if (currentCombos.Count <= 0)
                {
                    Attack(getAttackFromType(input.type));
                }
            }


            void ResetCombos()
            {
                leeway = 0;
                for (int i = 0; i < currentCombos.Count; i++)
                {
                    Combo.Combo c = combos[currentCombos[i]];
                    c.ResetCombo();
                }

                currentCombos.Clear();
            }


        void Attack(Attack.Attack atk)
        {
            curAttack = atk;
            timer = atk.length;
            //anim.Play(atk.anim_name, -1, 0);
        }

        Attack.Attack getAttackFromType(AttackType t)
        {
            if (t == AttackType.light)
            {
                return lightAttack;
            }

            if (t == AttackType.heavy)
            {
                return heavyAttack;
            }

            return null;
        }
    }

    //[System.Serializable]
    //public class Attack
    //{
    //    public string anim_name;
    //    public float length;

    //}

    //public class ComboInput
    //{
    //    public AttackType type;
    
    //    public ComboInput(AttackType t)
    //    {
    //        type = t;
    //    }

    //    public bool isSameAs(ComboInput test)
    //    {
    //        return (type == test.type);
    //    }
    //}


//    [System.Serializable]
//    public class Combo
//    {
//        public string comboName;
//        public List<ComboInput> inputs;
//        public Attack comboAttack;
//        public UnityEvent onInputted;
//        private int curInput = 0;

//        public bool continueCombo(ComboInput i)
//        {
//            if (i.type == inputs[curInput].type)
//            {
//                curInput++;
//                if (curInput >= inputs.Count)
//                {
//                    onInputted.Invoke();
//                    curInput = 0;
//                }
//                return true;
//            }
//            else
//            {
//                curInput = 0;
//                return false;
//            }
//        }

//        public ComboInput CurrentComboInput()
//        {
//            if (curInput >= inputs.Count) return null;

//            return inputs[curInput];
//        }

//        public void ResetCombo()
//        {
//            curInput = 0;
//        }
//    }
}
