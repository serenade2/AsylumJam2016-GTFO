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
	    Vector2 currentPosition = this.transform.position;

	    float verticalAxis = Input.GetAxisRaw("Vertical");
	    float horizontalAxis = Input.GetAxisRaw("Horizontal");
	   
	    if (verticalAxis == 0.0f)
	    {
            Vector2 offsetVector2 = new Vector2(currentPosition.x - _parentLookingDirection.x, currentPosition.y - _parentLookingDirection.y);
            this.transform.localPosition = offsetVector2;
        }
        else if (verticalAxis == 1.0f)
        {

            Vector2 offsetVector2 = new Vector2(currentPosition.x - _parentLookingDirection.x, (currentPosition.y + OffsetDistanceY)-_parentLookingDirection.y);
            this.transform.localPosition = offsetVector2;
        }
        else if (verticalAxis == -1.0f)
        {

            Vector2 offsetVector2 = new Vector2(currentPosition.x - _parentLookingDirection.x, (currentPosition.y + OffsetDistanceY)*-1 + _parentLookingDirection.y);
            this.transform.localPosition = offsetVector2;
        }

        if (horizontalAxis == 1.0f)
        {
            Debug.Log("Horizontal Axis :" + horizontalAxis);
            Vector2 offsetVector2 = new Vector2((currentPosition.x + OffsetDistanceX) - _parentLookingDirection.x, currentPosition.y - _parentLookingDirection.y );
            this.transform.localPosition = offsetVector2;
        }
        else if (horizontalAxis == -1.0f)
        {
            Debug.Log("Horizontal Axis :" + horizontalAxis);
            Vector2 offsetVector2 = new Vector2((currentPosition.x + OffsetDistanceX)*-1 + _parentLookingDirection.x, currentPosition.y - _parentLookingDirection.y);
            this.transform.localPosition = offsetVector2;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            
        }
    }

    public void PlaceTrap(GameObject trap)
    {
        
    }
}
