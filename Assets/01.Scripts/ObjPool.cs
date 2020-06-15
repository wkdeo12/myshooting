using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    public GameObject projectile;
    public List<GameObject> projectilePool;

    public GameObject GetBullet()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (projectilePool[i].activeSelf)
            {
                continue;
            }
            else
            {
                return projectilePool[i];
            }
        }
        var go = Instantiate(projectile);
        projectilePool.Add(go);
        return go;
    }
}