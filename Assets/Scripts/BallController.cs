using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Be sure that the object has a rigidbody to avoid surprises.
public class BallController : MonoBehaviour
{

    public float speed;
    public GameController game_controller;

    private Rigidbody2D _rb;
    private Vector2 _dir;

	void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        if ( _rb == null)
        {
            Debug.LogError("Unable to find a Rigidbody2D on " + gameObject.name);
        }
    }

    //void Update()
    //{
    //    //_rb.velocity = _dir; // Why updating the velocity every frame with the same value?
    //    // Why not updating velocity only when _dir is actually changed (in SetDir) instead?
    //}

    void OnCollisionEnter2D(Collision2D col)
    {

        // "Player" and "Border" collision should act the same...
        //if (col.gameObject.tag == "Player")
        //{
        //    _dir = col.contacts[0].normal.normalized * speed;
        //}
        //else if (col.gameObject.tag == "Border")
        //{
        //    _dir = new Vector2(_dir.x, _dir.y * -1);
        //}
        if ( col.gameObject.tag == "Player" || col.gameObject.tag == "Border")
        {
            // Always use methods you've created on purpose instead of doing the same line of code twice.
            //_dir = col.contacts[0].normal.normalized * speed;
            SetDir(col.contacts[0].normal.normalized);
        }
        else if (col.gameObject.name == "Left")
        {
            // GameObject.Find("GameController").GetComponent<GameController>().addScorePlayerLeft();  // Avoid GameObject.Find() + GameComponent if you can.
            // Use a public field instead
            game_controller.addScorePlayerLeft();
            Destroy(gameObject);
        }
        else if (col.gameObject.name == "Right")
        {
            //GameObject.Find("GameController").GetComponent<GameController>().addScorePlayerRight();
            game_controller.addScorePlayerRight();
            Destroy(gameObject);
        }
    }

    public void SetDir(Vector2 dir) 
    //    public void setDir(Vector2 dir) // Methods should use a Camel Case.
    {
        _dir = dir * speed; // As you apply a speed on it _dir is a velocity, not really a direction... the name should be _velocity :)
        _rb.velocity = _dir;
    }
}
