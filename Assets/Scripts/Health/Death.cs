using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private int _matchNum;
    public GameObject playerAnimator;
    private Animator _anim;

    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _anim = playerAnimator.GetComponent<Animator>();
    }

    public void OnDeath()
    {
        _anim.Play("Player_Death");
        gameObject.BroadcastMessage("IncreaseMatch", _player.name, (UnityEngine.SendMessageOptions)1);
    }
}
