using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ND_VariaBULLET;

public class TestPlayer : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();

    public FireBase[] firepivot;
    public float speed = 10f;
    public LayerMask shotLayer;
    public SpreadPattern pattern;

    private void Start()
    {
        firepivot = GetComponentsInChildren<FireBase>();
        if (netId == 1)
        {
            shotLayer = LayerMask.NameToLayer("1p");
        }
        else
        {
            shotLayer = LayerMask.NameToLayer("2p");
        }
        gameObject.layer = shotLayer;
    }

    [Client]
    private void Update()
    {
        if (!hasAuthority) { return; }
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RpcShot();
            }

            //CmdMove();
            movement = Vector3.zero;

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    [Command]
    private void CmdMove()
    {
        // Valiate logic here

        RpcMove();
    }

    [Command]
    private void CmdShot()
    {
        RpcShot();
    }

    [ClientRpc]
    private void RpcShot()
    {
        for (int i = 0; i < firepivot.Length; i++)
        {
            firepivot[i].InstantiateShot(shotLayer);
        }
    }

    [ClientRpc]
    private void RpcMove()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}