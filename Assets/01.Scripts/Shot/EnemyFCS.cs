using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFCS : FCS
{
    public List<Projectile> projectileCashList;

    public int GetIdx(int lv)
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (projectilePool[i].activeSelf)
            {
                continue;
            }
            else
            {
                return i;
            }
        }
        var go = Instantiate(projectile[lv]);
        projectilePool.Add(go);
        projectileCashList.Add(go.GetComponent<Projectile>());
        return projectilePool.Count - 1;
    }
}