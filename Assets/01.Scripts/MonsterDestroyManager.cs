using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDestroyManager : MonoBehaviour
{
    public FxPool fxPool;

    private void Start()
    {
        fxPool = FindObjectOfType<FxPool>();
    }

    /// <summary>
    /// 몬스터가 죽엇을 때 효과를 출력한다
    /// </summary>
    /// <param name="count">효과출력 회수</param>
    public void PlayDestoryFx(int count, Vector2 position, FxPlayType type = FxPlayType.Nomal)
    {
        switch (type)
        {
            case FxPlayType.Nomal:
                for (int i = 0; i < count; i++)
                {
                    var fx = fxPool.GetDestroyFx();
                    fx.transform.position = position;
                    fx.SetActive(true);
                }

                break;

            case FxPlayType.Random:
                break;

            default:
                break;
        }
    }
}