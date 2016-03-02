﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public int nbPlayer;
    public float speed;
    public float speedRotation;
    public float rotationAngle;

    private float ver_angle = 0.0f;
    private Rigidbody2D _rb;

    void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        float r = Input.GetAxis("Horizontal" + nbPlayer.ToString()) * -1;
        float h = Input.GetAxis("Vertical" + nbPlayer.ToString());

        // Movement Vertical
        _rb.velocity = new Vector2(0, h) * speed;

        // Rotation Z
        ver_angle = Mathf.Clamp(ver_angle + r * speedRotation, -rotationAngle, rotationAngle);
        Vector3 current_rot = transform.rotation.eulerAngles;
        current_rot.z = ver_angle;
        transform.rotation = Quaternion.Euler(current_rot);
    }
}
