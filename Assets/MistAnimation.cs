using UnityEngine;
using System.Collections;

public class MistAnimation : MonoBehaviour
{
    private float _time;
    private Material _material;

    void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        _time += Time.fixedDeltaTime;
    }

    void Update()
    {
        _material.SetFloat("__Time", _time);
    }


}
