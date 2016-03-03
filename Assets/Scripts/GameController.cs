using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(BallController))] // be sure that GetComponent<BallController> works.
// Game Controller should be on an isolated game_object... it feels weird to have it on the ball, especially when the ball has to communicate with GameController.
public class GameController : MonoBehaviour
{
    //    public GameObject Ball; // Use lower case on fields
    public GameObject ball;

    public Text time_text;
    public Text left_score_text;
    public Text right_score_text;

    private BallController _ball_controller;

    private int _playerRightScore;
    private int _playerLeftScore;
    private float _time;
    private bool _start = true;
    private Vector2 _dir;

    void Start ()
    {
        _time = Time.time;
        _dir = new Vector2(1.0f, 0.0f);

        _ball_controller = GetComponent<BallController>();
        if (_ball_controller == null)
        {
            Debug.LogError("Unable to find BallController on " + gameObject.name);
        }
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
	    if (_start == true)
        {
            // GameObject.Find costs a lot... avoid that in Update()
            // Use a field instead
            // GameObject.Find("Time").GetComponent<Text>().enabled = true;
            time_text.enabled = true;
            if (Time.time - _time > 3)
            {
                _start = false;
                //GameObject.Find("Time").GetComponent<Text>().enabled = false;
                time_text.enabled = false;
                GameObject go = Instantiate(ball, ball.transform.position, Quaternion.identity) as GameObject;
                // Avoid GetComponent at every frame if possible
                // go.GetComponent<BallController>().setDir(_dir);
                if (_ball_controller != null)
                {
                    _ball_controller.SetDir(_dir);
                }
            }
            //GameObject.Find("Time").GetComponent<Text>().text = (3 - ((int)Time.time - (int)_time)).ToString();
            time_text.text = (3 - ((int)Time.time - (int)_time)).ToString();
        }
        
	}

    public void addScorePlayerRight()
    {
        _playerRightScore += 1;
//        GameObject.Find("PlayerRightScore").GetComponent<Text>().text = _playerRightScore.ToString();
        if (right_score_text != null)
        {
            right_score_text.text = _playerRightScore.ToString();
        }
        _start = true;
        _time = Time.time - 2.0f;
        _dir = new Vector2(1.0f, 0f);
    }

    public void addScorePlayerLeft()
    {
        _playerLeftScore += 1;
        //GameObject.Find("PlayerLeftScore").GetComponent<Text>().text = _playerLeftScore.ToString();
        if ( left_score_text != null )
        {
            left_score_text.text = _playerLeftScore.ToString();
        }
        _start = true;
        _time = Time.time - 2.0f;
        _dir = new Vector2(-1.0f, 0f);
    }
}
