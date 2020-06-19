using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public float speed = 0.5f;

    public GameObject[] backGroundArray;

    // Update is called once per frame
    private void FixedUpdate()
    {
        for (int i = 0; i < backGroundArray.Length; i++)
        {
            backGroundArray[i].transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
            if (backGroundArray[i].transform.position.y <= -6.4f)
            {
                backGroundArray[i].transform.position = new Vector3(0, 3.2f, 0);
            }
        }
    }
}