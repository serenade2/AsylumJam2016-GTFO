using System;
using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            Debug.Log(String.Format("{0} entered in collision with {1}", coll.gameObject.tag, this.gameObject.tag));
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            Debug.Log(String.Format("{0} exited from collision with {1}", coll.gameObject.tag, this.gameObject.tag));
        }
    }
}
