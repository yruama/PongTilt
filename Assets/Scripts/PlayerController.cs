using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;

    public override void OnStartLocalPlayer()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(
             bulletPrefab,
             bulletPrefab.transform.position - transform.forward,
             Quaternion.identity);
        NetworkServer.Spawn(bullet);
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;

        var x = Input.GetAxis("Horizontal") * 0.1f;
        var y = Input.GetAxis("Vertical") * 0.1f;

        transform.Translate(x, y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }
    }
}