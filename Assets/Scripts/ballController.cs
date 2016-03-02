using UnityEngine;
using System.Collections;

public class ballController : MonoBehaviour {
    public float speed;
    public Vector2 dir;

	void Start ()
    {
        dir = new Vector2(speed, 0);
	}

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = dir;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        Debug.Log((ballPos.y - racketPos.y) / racketHeight);
        return (ballPos.y - racketPos.y) / racketHeight * 3.5f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            dir = new Vector2(dir.x, dir.y * -1);
        }
        else if (col.gameObject.name == "Square(Clone)")
        {
            float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
            dir = new Vector2(dir.x * -1, y).normalized * speed;
        }
        else if (col.gameObject.name == "Right")
        {
            GameObject.Find("GameController").GetComponent<GameController>().OnPlayerOneScoreChanged();
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Left")
        {
            GameObject.Find("GameController").GetComponent<GameController>().OnPlayerTwoScoreChanged();
            Destroy(gameObject);
        }
           
    }
}
