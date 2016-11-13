using System;
using UnityEngine;
using System.Collections;

public class GlobalAttributes : MonoBehaviour {

    public Vector2 movement_vector = new Vector2();
    public Boolean IsTrapped = false;
    public float TrapEffectTime;
    public void set_movement_vector(Vector2 m)
    {
        movement_vector = m;
    }
}
