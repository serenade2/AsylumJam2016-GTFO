﻿using System;
using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour
{
    public float TrapEffectTime = 3.0f; // in seconds
    //public bool IsActivated = false;
    private float _startElapsedTime;
    private bool _characterIsTrapped;

    private PlayerMovement _playerMovement;
	// Use this for initialization
	void Start ()
	{
	    _characterIsTrapped = false;
	    _playerMovement = null;
	    _startElapsedTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (_characterIsTrapped)
	    {
	        //float elapsedTime = Time.deltaTime;
            Debug.Log(String.Format("{0} seconds elapsed since character is trapped", _startElapsedTime));
            
            // thanks to :  Mmmpies at : http://answers.unity3d.com/questions/863050/adding-cooldown-c.html
            if (Time.time > _startElapsedTime + TrapEffectTime && _playerMovement != null)
	        {
                // release the player after the cool down of the specific trap
	            _playerMovement.isTrapped = false;
	        }
	    }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            Debug.Log(String.Format("{0} entered in collision with {1}", coll.gameObject.tag, this.gameObject.tag));
            _playerMovement = coll.gameObject.GetComponent<PlayerMovement>();

            if (_playerMovement != null)
            {
                _playerMovement.isTrapped = true;
                _characterIsTrapped = true;
                _startElapsedTime = Time.time;
                CenterTrappedCharacter(coll.gameObject);
            }
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
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

    private void CenterTrappedCharacter(GameObject characterGameObject)
    {
        characterGameObject.transform.position = this.transform.position;
    }
}
