using System;
using UnityEngine;
using System.Collections;

public class CharacterCollision : MonoBehaviour
{
    private Door door;
    public int pushPower = 5;
    private Collider2D touchedFurniture;
    public Transform Enemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ( touchedFurniture != null) //Input.GetKey(KeyCode.B) &&
        {
            Vector3 direction = transform.position - touchedFurniture.transform.position;

            touchedFurniture.attachedRigidbody.velocity = -direction * pushPower;

            touchedFurniture = null;
        }
        if (Vector3.Distance(transform.position, Enemy.position) <= 1.05f)
            GameManager.Instance.TriggerGameOverEvent();
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
        else if (coll.gameObject.tag.Equals("Furniture"))
        {
            touchedFurniture = coll.collider;

            if (Input.GetKey(KeyCode.P))
            {
                Vector3 direction = transform.position - coll.transform.position;

                coll.rigidbody.velocity = -direction * pushPower;
            }
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
        else if (coll.gameObject.tag.Equals("Furniture"))
        {
            touchedFurniture = coll;
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            if (Vector3.Distance(coll.transform.position, transform.position) <= 1.1f)
                GameManager.Instance.TriggerGameOverEvent();
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
        else if (coll.gameObject.tag.Equals("Furniture"))
        {
            touchedFurniture = null;
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
