using UnityEngine;
using System.Collections;

public class ViewCone : MonoBehaviour {

    public Collider2D colliderVision;
    public Collider2D colliderMur;

    void Update()
    {
        var movement_vector = GetComponent<GlobalAttributes>().movement_vector;
        float angle = Mathf.Atan2(movement_vector.x, -movement_vector.y) * Mathf.Rad2Deg;

        colliderVision.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        colliderMur.transform.rotation = Quaternion.Euler(0f, 0f, angle);

           
    }
}
