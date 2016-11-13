using System;
using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public bool IsOpen = false;
    public Sprite HorizontalDoorClosedSprite;
    public Sprite HorizontalDoorOpenedSprite;
    public Sprite HorizontalDoorSmashedSprite;

    public Sprite VerticalDoorClosedSprite;
    public Sprite VerticalDoorOpenedSprite;
    public Sprite VerticalDoorSmashedSprite;

    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;
    // Use this for initialization
    void Start ()
    {
        _playerMovement = null;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (IsOpen)
	    {
	        
	    }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            _playerMovement = coll.gameObject.GetComponent<PlayerMovement>();
            if (_playerMovement != null && _spriteRenderer != null)
            {
                if (_playerMovement.IsMovingUp)
                {
                    _spriteRenderer.sprite = HorizontalDoorOpenedSprite;
                }
                else if (_playerMovement.IsMovingDown)
                {
                    
                }
                else if (_playerMovement.IsMovingLeft)
                {
                    
                }
                else if (_playerMovement.IsMovingRight)
                {
                    
                }
            }
            Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            _playerMovement = coll.gameObject.GetComponent<PlayerMovement>();
            if (_playerMovement != null && _spriteRenderer != null)
            {
                if (_playerMovement.IsMovingUp || _playerMovement.IsMovingDown)
                {
                    _spriteRenderer.sprite = HorizontalDoorOpenedSprite;
                }
                else if (_playerMovement.IsMovingLeft || _playerMovement.IsMovingRight)
                {
                    _spriteRenderer.sprite = VerticalDoorOpenedSprite;
                }
            }
            Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Equals("Player"))
        {
            _playerMovement = coll.gameObject.GetComponent<PlayerMovement>();
            if (_playerMovement != null && _spriteRenderer != null)
            {
                if (_playerMovement.IsMovingUp || _playerMovement.IsMovingDown)
                {
                    _spriteRenderer.sprite = HorizontalDoorClosedSprite;
                }
                else if (_playerMovement.IsMovingLeft || _playerMovement.IsMovingRight)
                {
                    _spriteRenderer.sprite = VerticalDoorClosedSprite;
                }
            }
            Debug.Log(String.Format("{0} collision exited collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            Debug.Log(String.Format("{0} collision exit in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    public void OpenDoor()
    {
        IsOpen = true;
    }

}
