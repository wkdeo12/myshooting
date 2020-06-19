using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFx : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnEnable()
    {
        audioSource.Play();
    }

    public void Off()
    {
        gameObject.SetActive(false);
    }
}