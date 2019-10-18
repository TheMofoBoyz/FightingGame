using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private int _matchNum;

    [SerializeField]
    private GameObject _player;

    public void OnDeath()
    {
        //play death animation.
        gameObject.BroadcastMessage("IncreaseMatch", _player.name, (UnityEngine.SendMessageOptions)1);
    }
}
