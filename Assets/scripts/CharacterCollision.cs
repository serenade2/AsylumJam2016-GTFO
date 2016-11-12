using System;
using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour
{
    private Door door;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Door"))
        {
            Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            Debug.Log(String.Format("{0} entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Door"))
        {
            Debug.Log(String.Format("{0} entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Floor"))
        {
            Debug.Log(String.Format("{0} trigger exited from collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Door"))
        {
            Debug.Log(String.Format("{0} trigger exited from collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    void OpenDoor(GameObject doorGameObject)
    {
        door = doorGameObject.GetComponent<Door>();
        if (door != null)
        {
            door.OpenDoor();
        }
    }
}
