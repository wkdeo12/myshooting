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
    private bool up = false;

    public Vector2 screenMin;
    public Vector2 screenMax;

    private void Start()
    {
        firepivot = GetComponentsInChildren<FireBase>();
        if (netId % 2 != 0)
        {
            shotLayer = LayerMask.NameToLayer("1p");
        }
        else
        {
            shotLayer = LayerMask.NameToLayer("2p");
        }
        gameObject.layer = shotLayer;
    }

    public override void OnStartLocalPlayer()
    {
        if (transform.position.y > 0)
        {
            up = true;
            Camera.main.transform.rotation = new Quaternion(0, 0, 180, 0);
        }
    }

    private void Update()
    {
        if (!hasAuthority) { return; }
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CmdShot();
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                StartCoroutine(BeastMode());
            }
            //CmdMove();
            movement = Vector3.zero;

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            if (up)
            {
                movement.x *= -1f;
                movement.y *= -1f;
            }

            transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (isLocalPlayer)
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, screenMin.x, screenMax.x), Mathf.Clamp(transform.position.y, screenMin.y, screenMax.y));
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

    private IEnumerator BeastMode()
    {
        while (true)
        {
            CmdShot();
            yield return new WaitForSeconds(0.5f);
        }
    }
}