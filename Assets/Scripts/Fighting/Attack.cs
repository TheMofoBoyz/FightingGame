﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Collider[] attackHitboxes;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LaunchAttack(attackHitboxes[0]);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            LaunchAttack(attackHitboxes[1]);
        }
    }

    private void LaunchAttack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center,
                                             col.bounds.extents,
                                             col.transform.rotation,
                                             LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
            if (c.transform.parent.parent == transform)
            {
                continue;
            }

                Debug.Log(c.name);

                float damage = 0;

                switch (c.name)
                {
                    case "Head":
                    damage = 30;
                    break;

                    case "Torso":
                    damage = 15;
                    break;

                default:
                    Debug.Log("The Collider "+ c.name + " Did not match with switch cases. be sure the name is correct");
                    break;
                }
        }
    }
}