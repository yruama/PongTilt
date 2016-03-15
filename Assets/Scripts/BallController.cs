using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    public float speed;
    public GameController game_controller;

    private Rigidbody2D _rb;
    private Vector2 _velocity;

	void Awake ()
    {
       _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Unable to find a Rigidbody2D on " + gameObject.name);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            SetVelocity(new Vector2(_velocity.x, _velocity.y * -1) / speed);
        }
        else if ( col.gameObject.tag == "Player")
        {
            SetVelocity(col.contacts[0].normal.normalized);
        }
        else if (col.gameObject.name == "Left")
        {
            game_controller.addScorePlayerRight();
            gameObject.transform.position = Vector2.zero;
            SetVelocity(Vector2.zero);
            gameObject.SetActive(false);
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
            {
                p.GetComponent<PlayerController>().ResetPositionAndRotation();
            }
            
        }
        else if (col.gameObject.name == "Right")
        {
            game_controller.addScorePlayerLeft();
            gameObject.transform.position = Vector2.zero;
            SetVelocity(Vector2.zero);
            gameObject.SetActive(false);
            foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
            {
                p.GetComponent<PlayerController>().ResetPositionAndRotation();
            }
        }
    }

    public void SetVelocity(Vector2 velocity) 
    {
        _velocity = velocity * speed;
        _rb.velocity = _velocity;
    }
}
