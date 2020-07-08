using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ND_VariaBULLET;

public class TestPlayer : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();

    public FireBase[] firepivot;

    private void Start()
    {
        firepivot = GetComponentsInChildren<FireBase>();
    }

    [Client]
    private void Update()
    {
        if (!hasAuthority) { return; }

        if (Input.GetKeyDown(KeyCode.S))
        {
            CmdShot();
        }

        if (!Input.GetKeyDown(KeyCode.Space)) { return; }

        CmdMove();
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
            firepivot[i].InstantiateShot();
        }
    }

    [ClientRpc]
    private void RpcMove() => transform.Translate(movement);
}