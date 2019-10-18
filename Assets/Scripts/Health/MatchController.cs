using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchController : MonoBehaviour
{
    private int _matchNum;
    private List<string> _wins;

    private void Start()
    {
        _wins = new List<string>();
    }

    public void IncreaseMatch(GameObject player, int i)
    {
        if (_matchNum == 2)
        {
            if (_wins[0] == _wins[1] ||
                _wins[0] == _wins[2])
            {
                EndGame(_wins[0]);
            }

            if (_wins[1] == _wins[2])
            {
                EndGame(_wins[1]);
            }
        }
        _matchNum++;
    }

    private void EndGame(string winner)
    {
        Debug.Log("WINNER: " + winner + "!");
    }
}
