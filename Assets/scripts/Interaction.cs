using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{
    private Vector2 _parentLookingDirection;
    public float OffsetDistanceX = 0.281f;
    public float OffsetDistanceY = 0.281f;
	// Use this for initialization
	void Start ()
	{
	  
	}
	
	// Update is called once per frame
	void Update ()
	{
        _parentLookingDirection = GetComponentInParent<Transform>().position;
	    Vector3 currentPosition = this.transform.position;
	    Vector3 offsetVector3;
	    float verticalAxis = Input.GetAxisRaw("Vertical");
	    float horizontalAxis = Input.GetAxisRaw("Horizontal");
	   
	    if (verticalAxis == 0.0f)
	    {
            offsetVector3 = new Vector3(currentPosition.x - _parentLookingDirection.x, currentPosition.y - _parentLookingDirection.y, 1);
     
            this.transform.localPosition = offsetVector3;
        }
        else if (verticalAxis == 1.0f)
        {

            offsetVector3 = new Vector3(currentPosition.x - _parentLookingDirection.x, (currentPosition.y + OffsetDistanceY)-_parentLookingDirection.y, 1);
            this.transform.localPosition = offsetVector3;
        }
        else if (verticalAxis == -1.0f)
        {

            offsetVector3 = new Vector3(currentPosition.x - _parentLookingDirection.x, (currentPosition.y + OffsetDistanceY)*-1 + _parentLookingDirection.y, 1);
            this.transform.localPosition = offsetVector3;
        }

        if (horizontalAxis == 1.0f)
        {
            offsetVector3 = new Vector3((currentPosition.x + OffsetDistanceX) - _parentLookingDirection.x, currentPosition.y - _parentLookingDirection.y, 1);
            this.transform.localPosition = offsetVector3;
        }
        else if (horizontalAxis == -1.0f)
        {
            offsetVector3 = new Vector3((currentPosition.x + OffsetDistanceX)*-1 + _parentLookingDirection.x, currentPosition.y - _parentLookingDirection.y, 1);
            this.transform.localPosition = offsetVector3;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            Debug.Log("Interaction collided with" + coll.gameObject.name);
        }
    }

    public void PlaceTrap(GameObject trap)
    {
        
    }
}
