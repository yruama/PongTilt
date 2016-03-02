using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float speed;

	void Start ()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0), ForceMode2D.Force);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
