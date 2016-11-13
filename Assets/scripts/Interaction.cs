using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour
{
    public GameObject[] TrapPrefabs;
    private Vector2 _parentLookingDirection;
    public float OffsetDistanceX = 0.281f;
    public float OffsetDistanceY = 0.281f;
    public float SetTrapDuration = 1.0f;
    public float SetTrapDurationSecIncreasePerMin = 0.5f;
    private float _trapFillAmount;
    private GameObject _selectedFloor;

	// Use this for initialization
	void Start ()
	{
        Vector3 currentPosition = this.transform.position;
	    Vector3 offsetVector3 = new Vector3(currentPosition.x - _parentLookingDirection.x, (currentPosition.y + OffsetDistanceY) * -1 + _parentLookingDirection.y, 1);
        this.transform.localPosition = offsetVector3;
    }
	
	// Update is called once per frame
	void Update ()
	{
        float nbSecPass = GameManager.Instance.GetTime();
        float realSetTrapDuration = SetTrapDuration + SetTrapDurationSecIncreasePerMin / 60 * nbSecPass;

        _parentLookingDirection = GetComponentInParent<Transform>().position;
	    Vector3 currentPosition = this.transform.position;
	    Vector3 offsetVector3;
	    float verticalAxis = Input.GetAxisRaw("Vertical");
	    float horizontalAxis = Input.GetAxisRaw("Horizontal");
	   
	    if (verticalAxis == 0.0f && horizontalAxis != 0.0f)
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

	    if (Input.GetKey(KeyCode.N) || Input.GetKey(KeyCode.M))
	    {
	        if (_selectedFloor == null)
	            _trapFillAmount = 0.0f;
	        else if (_trapFillAmount >= SetTrapDuration)
	        {
	            _trapFillAmount = 0.0f;
	            PlaceTrap(Input.GetKey(KeyCode.N) ? TrapPrefabs[0] : TrapPrefabs[1]);
	        }
	        else
	            _trapFillAmount += Time.deltaTime;
        }
	    if (_selectedFloor != null)
	    {
	        GameManager.Instance.ProgressBar.SetPosition(_selectedFloor.transform.position);
	        GameManager.Instance.ProgressBar.SetFillAmount(_trapFillAmount/SetTrapDuration);
	    }
	    else
	    {
            _trapFillAmount = 0.0f;
            GameManager.Instance.ProgressBar.SetFillAmount(_trapFillAmount / SetTrapDuration);
        }
            

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            _selectedFloor = coll.gameObject;
        } else if (coll.gameObject.tag.Equals("Trap"))
        {
            _selectedFloor = null;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            if (_selectedFloor == coll.gameObject)
                _selectedFloor = null;
        }
    }

    public void PlaceTrap(GameObject trap)
    {
        Sound.Instance.PlaySound(5);
        GameObject newTrap = Instantiate(trap);
        newTrap.transform.position = _selectedFloor.transform.position;
    }
}
