using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{
    private Transform _parentLookingDirection;
    public  float _offsetDistance;
	// Use this for initialization
	void Start ()
	{
	    _parentLookingDirection = GetComponentInParent<Transform>();
        //_offsetDistance = 
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log("Vertical axis " + Input.GetAxisRaw("Vertical"));
	    float verticalAxis = Input.GetAxisRaw("Vertical");
	    float horizontalAxis = Input.GetAxisRaw("Horizontal");

	    if (verticalAxis == 0.0f)
	    {
	        //this.transform.position.x *=
	    }
        
    }
}
