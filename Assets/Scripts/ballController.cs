using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallController : MonoBehaviour {

    public float speed;

    private Rigidbody2D _rb;
    private Vector2 _dir;


	void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = _dir;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _dir = col.contacts[0].normal.normalized * speed;
        }
        else if (col.gameObject.tag == "Border")
        {
            _dir = new Vector2(_dir.x, _dir.y * -1);
        }
        else if (col.gameObject.name == "Left")
        {
            GameObject.Find("GameController").GetComponent<GameController>().addScorePlayerLeft();
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Right")
        {
            GameObject.Find("GameController").GetComponent<GameController>().addScorePlayerRight();
            Destroy(gameObject);
        }
    }

    public void setDir(Vector2 dir)
    {
        _dir = dir * speed;
    }
}
