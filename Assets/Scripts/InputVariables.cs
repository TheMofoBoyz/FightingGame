using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputVariables : MonoBehaviour
{
    
}

public class FightingVariables : MonoBehaviour
{
    public Input punch;
    public Input punch_up;
    public Input block;

    public Input kick;
    public Input kick_low;
    public Input kick_high;
}

public class MovementVariables : MonoBehaviour
{
    public Input walk_left;
    public Input walk_right;

    public Input jump;
    public Input crouch;
}

public class SetInputVariables : MonoBehaviour
{
    public enum GetVariable { fighting = 0, movement = 1 }

    private FightingVariables fighting;
    private MovementVariables movement;

    public void SetInput()
    {
        GetVariable choice = GetVariable.fighting;
        switch (choice)
        {
            case GetVariable.fighting:
                break;
            case GetVariable.movement:
                break;
            default:
                break;
        }
    }
}
