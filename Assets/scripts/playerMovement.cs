using UnityEngine;
using System.Collections;
using System.Security.Policy;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rbody;
    Animator anim;
    public bool IsTrapped = false;
    public bool IsMovingDown = false;
    public bool IsMovingUp = false;
    public bool IsMovingLeft = false;
    public bool IsMovingRight = false;

	void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (!IsTrapped)
        {
            rbody.MovePosition(rbody.position + movement_vector * Time.fixedDeltaTime);
        }
    }
	
	void Update ()
    {

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(movement_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        float verticalAxis = Input.GetAxisRaw("Vertical");
        float horizontalAxis = Input.GetAxisRaw("Horizontal");

	    if (verticalAxis == 0.0f)
	    {
	        IsMovingUp = IsMovingDown = false;
	    }
        else if (verticalAxis == 1.0f)
        {
            IsMovingUp = true;
        }
        else if (verticalAxis == -1.0f)
        {
            IsMovingDown = true;
            IsMovingUp = false;
        }

	    if (horizontalAxis == 0.0f)
	    {
	        IsMovingLeft = IsMovingRight = false;
	    }
        else if (horizontalAxis == 1.0f)
        {
            IsMovingRight = true;
            IsMovingLeft = false;
        }
        else if (horizontalAxis == -1.0f)
        {
            IsMovingLeft = true;
            IsMovingRight = false;
        }

    }
}
