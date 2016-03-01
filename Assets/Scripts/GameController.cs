using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class GameController : NetworkManager
{
    public GameObject balle;
    private int _nbPlayer;
    private bool _spawnBall;

    public void Start()
    {
        _spawnBall = false;
    }

    public void Update()
    {
        
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
       
        _nbPlayer += 1;
    }
}