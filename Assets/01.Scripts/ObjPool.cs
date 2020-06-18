using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    public GameObject projectile;
    public List<GameObject> projectilePool;

    public GameObject[] userShotsArray;

    public List<List<GameObject>> projectilePoolList;

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

    //public GameObject TempGetBullet(UserShots userShots, int lv)
    //{
    //    if (projectilePoolList.Count == 0)
    //    {
    //        int idx = (int)userShots;
    //        var bullet = userShotsArray[idx];
    //        var go = Instantiate(bullet);
    //        List<GameObject> list = new List<GameObject>();
    //        list.Add(go);
    //        projectilePoolList.Add(list);
    //    }

    //    return
    //}
}