using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour 
{
    [SyncVar(hook = "OnPlayerOneScoreChanged")] private int _playerOneScore = 0;
    [SyncVar(hook = "OnPlayerTwoScoreChanged")] private int _playerTwoScore = 0;

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public void AddScorePlayerOne()
    {

    }

    public void OnPlayerOneScoreChanged(int i = 1)
    {
        Debug.Log(i);
        _playerOneScore += i;
        GameObject.Find("Score Player1").GetComponent<Text>().text = _playerOneScore.ToString();
    }

    public void OnPlayerTwoScoreChanged(int i = 1)
    {
        Debug.Log(i);
        _playerTwoScore += 1;
        GameObject.Find("Score Player2").GetComponent<Text>().text = _playerOneScore.ToString();
    }
}