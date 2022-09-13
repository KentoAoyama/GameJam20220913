using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSE : MonoBehaviour
{
    [SerializeField] AudioSource _se;
    void Start()
    {
        _se.Play();
        Destroy(gameObject, 1f);
    }

    void Update()
    {

    }
}
