using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float speed;

    private Rigidbody2D _rb;
    private Vector2 _dir;

	void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        _dir = new Vector2(1.0f, 0f) * speed;
        // GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Force);
    }

    void Update()
    {
        _rb.velocity = _dir;
        Debug.Log(_dir);
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
       
    }
}
