using UnityEngine;
using System.Collections;

public class GlobalAttributes : MonoBehaviour {

    public Vector2 movement_vector = new Vector2();

    public void set_movement_vector(Vector2 m)
    {
        movement_vector = m;
    }
}
