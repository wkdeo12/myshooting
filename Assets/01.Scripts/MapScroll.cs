using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroll : MonoBehaviour
{
    public float speed = 0.5f;
    public Material material;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        float y = material.mainTextureOffset.y + speed * Time.deltaTime;
        material.mainTextureOffset = new Vector2(0, y);
    }
}