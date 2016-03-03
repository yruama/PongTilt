using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject Ball;

    private int _playerRightScore;
    private int _playerLeftScore;
    private float _time;
    private bool _start = true;
    private Vector2 _dir;

    void Start ()
    {
        _time = Time.time;
        _dir = new Vector2(1.0f, 0.0f);
    }
	
	void Update ()
    {
	    if (_start == true)
        {
            GameObject.Find("Time").GetComponent<Text>().enabled = true;
            if (Time.time - _time > 3)
            {
                _start = false;
                GameObject.Find("Time").GetComponent<Text>().enabled = false;
                GameObject go = Instantiate(Ball, Ball.transform.position, Quaternion.identity) as GameObject;
                go.GetComponent<BallController>().setDir(_dir);
            }
            GameObject.Find("Time").GetComponent<Text>().text = (3 - ((int)Time.time - (int)_time)).ToString();
        }
        
	}

    public void addScorePlayerRight()
    {
        _playerRightScore += 1;
        GameObject.Find("PlayerRightScore").GetComponent<Text>().text = _playerRightScore.ToString();
        _start = true;
        _time = Time.time - 2.0f;
        _dir = new Vector2(1.0f, 0f);
    }

    public void addScorePlayerLeft()
    {
        _playerLeftScore += 1;
        GameObject.Find("PlayerLeftScore").GetComponent<Text>().text = _playerLeftScore.ToString();
        _start = true;
        _time = Time.time - 2.0f;
        _dir = new Vector2(-1.0f, 0f);
    }
}
