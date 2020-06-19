using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShot : MonoBehaviour
{
    private Vector3 retVector;

    public int speed = 1;
    public int degree = 0;
    public GameObject bullet;

    private void Start()
    {
    }

    public float deg;
    public float rad;
    public float count;

    private void Test()
    {
        deg = Mathf.Rad2Deg;
    }

    private void Test2()
    {
        rad = Mathf.Deg2Rad;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Test();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            //degree += speed;

            for (int i = 0; i < count; i++)
            {
                GameObject vullet = Instantiate(bullet);
                float radian = (degree + 360 / count * i) * Mathf.PI / 180; //라디안값

                Debug.Log(radian);
                //retVector.x += 1f * Mathf.Cos(radian);
                //retVector.y += 1f * Mathf.Cos(radian);
                retVector.x = Mathf.Cos(radian);
                retVector.y = Mathf.Sin(radian);
                vullet.GetComponent<Rigidbody2D>().MovePosition(retVector * 3f);
            }
        }
    }
}