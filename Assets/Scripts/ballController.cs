using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {
    public float speed;
    public Vector2 dir;
	// Use this for initialization
	void Start () {
        dir = new Vector2(speed, 0);
	}

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = dir;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        Debug.Log((ballPos.y - racketPos.y) / racketHeight);
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            dir = new Vector2(dir.x, dir.y * -1);
        }
        else
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            speed *= -1;
            dir = new Vector2(speed, y * speed).normalized;

            
        }
    }
}
