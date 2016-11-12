using UnityEngine;
using System.Collections;
using BehaviourMachine;

public class MoveAround : ActionNode
{
    Rigidbody2D rbody;
    Animator anim;

    // Called once when the node is created
    public virtual void Awake() { }

    // Called when the owner (BehaviourTree or ActionState) is enabled
    public override void OnEnable() { }

    // Called when the node starts its execution
    public override void Start() {
        rbody = self.GetComponent<Rigidbody2D>();
        anim = self.GetComponent<Animator>();
    }

    // This function is called when the node is in execution
    public override Status Update()
    {
        self.GetComponent<GlobalAttributes>().set_movement_vector(new Vector2(1.0f, 0.0f));
        var movement_vector = self.GetComponent<GlobalAttributes>().movement_vector;
        

        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime);

        // Never forget to set the node status
        return Status.Running;
    }

    // Called when the node ends its execution
    public override void End() { }

    // Called when the owner (BehaviourTree or ActionState) is disabled
    public override void OnDisable() { }

    // This function is called to reset the default values of the node
    public override void Reset() { }

    // Called when the script is loaded or a value is changed in the inspector (Called in the editor only)
    public override void OnValidate() { }
}