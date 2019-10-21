using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider[] attackHitboxes;


    private void Update() {

        if (Input.GetKeyDown(KeyCode.Z)) {
            LauchAttack(attackHitboxes[0]);
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            LauchAttack(attackHitboxes[1]);
        }
    }

    private void LauchAttack(Collider col) 
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, 
                                             col.bounds.extents, 
                                             col.transform.rotation, 
                                             LayerMask.GetMask("Hitbox"));

        foreach (Collider c  in cols) 
        {
            if (c.transform.parent.parent == transform) 
            {
                continue;
            }

            float damage = 0;

            switch (c.name) 
            {

                case "Head":
                    damage = 25;
                    break;

                case "Torso":
                    damage = 10;
                    break;

                default:
                    Debug.Log("Non-existing body part detected, check if name matches with switch case");
                    break;
            }
        }
    }
}
