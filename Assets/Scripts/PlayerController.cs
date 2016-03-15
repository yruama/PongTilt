using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour
{
    public float speed;
    public float speedRotation;
    public float rotationAngle;
    public float boundary;

    private float ver_angle = 0.0f;
    private Rigidbody2D _rb;
    private Vector2 _position;

    void Awake()
    {
        _position = gameObject.transform.position;
    }

    void Start ()
    {
        GameObject.Find("GameController").GetComponent<GameController>().addPlayer(this.gameObject);
        _rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        if (isLocalPlayer == false)
            return;

        float r = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

        // Movement Vertical
        _rb.velocity = new Vector2(0, h) * speed;
        _rb.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, boundary * -1, boundary));

        // Rotation Z
        ver_angle = Mathf.Clamp(ver_angle + r * speedRotation, -rotationAngle, rotationAngle);
        Vector3 current_rot = transform.rotation.eulerAngles;
        current_rot.z = ver_angle;
        transform.rotation = Quaternion.Euler(current_rot);
    }

    public void ResetPositionAndRotation()
    {
        gameObject.transform.position = _position;
        ver_angle = 0;
    }
}