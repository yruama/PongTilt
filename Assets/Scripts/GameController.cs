using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class GameController : NetworkBehaviour
{
    public GameObject ball;

    public Text time_text;
    public Text left_score_text;
    public Text right_score_text;

    public List<GameObject> playerList;

    private int _playerRightScore;
    private int _playerLeftScore;
    private float _time;
    private Vector2 _velocity;

    void Start ()
    {
        ball.SetActive(false);
        _time = Time.time;
        _velocity = new Vector2(1.0f, 0.0f);

        if (time_text == null)
        {
            Debug.LogError("time_text field should not be empty.");
        }
        if (left_score_text == null)
        {
            Debug.LogWarning("left_score_text field should not be empty.");
        }
        if (right_score_text == null)
        {
            Debug.LogWarning("right_score_text field should not be empty.");
        }
    }

    
    void Update () 
    {
        if (ball.activeSelf == false && playerList.Count > 1)
        {
            time_text.enabled = true;
            if (Time.time - _time > 3)
            {
                ball.SetActive(true);
                time_text.enabled = false;
                ball.GetComponent<BallController>().SetVelocity(_velocity);
            }
            time_text.text = (3 - ((int)Time.time - (int)_time)).ToString();
        }
	}

    public void addScorePlayerRight()
    {
        _playerRightScore += 1;
        if (right_score_text != null)
        {
            right_score_text.text = _playerRightScore.ToString();
        }
        _time = Time.time - 2.0f;
    }

    public void addScorePlayerLeft()
    {
        _playerLeftScore += 1;
        if ( left_score_text != null )
        {
            left_score_text.text = _playerLeftScore.ToString();
        }
        _time = Time.time - 2.0f;
    }

    public void addPlayer(GameObject g)
    {
        _time = Time.time;
        playerList.Add(g);
    }
}
