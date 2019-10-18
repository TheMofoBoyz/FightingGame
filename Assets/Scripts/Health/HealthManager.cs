using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private GameObject _player1;
    private GameObject _player2;

    private void Start()
    {
        _player1 = GameObject.Find("Player1");
        _player2 = GameObject.Find("Player2");

    }

    public void OnDamage(GameObject target, int amount)
    {

    }

    public void OnHeal(GameObject target, int amount)
    {
           
    }
}