using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxPool : MonoBehaviour
{
    public GameObject fireHitFx;
    public List<GameObject> hitFxPool;

    public GameObject GetHitFx()
    {
        if (hitFxPool.Count == 0)
        {
            hitFxPool.Add(Instantiate(fireHitFx));
        }

        for (int i = 0; i < hitFxPool.Count; i++)
        {
            if (hitFxPool[i].activeSelf)
            {
                continue;
            }
            else
            {
                return hitFxPool[i];
            }
        }
        var go = Instantiate(fireHitFx);
        hitFxPool.Add(go);
        return go;
    }
}