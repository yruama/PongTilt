using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class RotationSync : NetworkBehaviour {

    [SyncVar]
    private Quaternion syncPlayerRotation;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private float lerpRate = 15;

	void Start ()
    {
	
	}
	
	void FixedUpdate ()
    {
        TransmitRotations();
        LerpRotations();
	}

    void LerpRotations()
    {
        if (isLocalPlayer == false)
        {
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, syncPlayerRotation,Time.deltaTime * lerpRate);
        }
    }

    [Command]
    void CmdProvideRotationsToServer(Quaternion playerRot)
    {
        syncPlayerRotation = playerRot;
    }

    [Client]
    void TransmitRotations()
    {
        if (isLocalPlayer == true)
        {
            CmdProvideRotationsToServer(playerTransform.rotation);
        }
    }
}
