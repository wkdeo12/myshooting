using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxPool : MonoBehaviour
{
    public GameObject fireHitFx;
    public GameObject destroyFx;
    public List<GameObject> hitFxPool;
    public List<GameObject> destroyFxPool;

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

    public GameObject GetDestroyFx()
    {
        if (destroyFxPool.Count == 0)
        {
            destroyFxPool.Add(Instantiate(destroyFx));
        }

        for (int i = 0; i < destroyFxPool.Count; i++)
        {
            if (destroyFxPool[i].activeSelf)
            {
                continue;
            }
            else
            {
                return destroyFxPool[i];
            }
        }
        var go = Instantiate(destroyFx);
        destroyFxPool.Add(go);
        return go;
    }
}