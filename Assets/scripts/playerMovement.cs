using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rbody;
    Animator anim;
    public bool isTrapped = false;

	void Start ()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

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

	    if (!isTrapped)
	    {
            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);
        }
      
	}
}
