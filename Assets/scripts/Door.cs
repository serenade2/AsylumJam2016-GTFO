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
    private GlobalAttributes _globalAttributes;

    // Use this for initialization
    void Start ()
    {
        _playerMovement = null;
        _globalAttributes = null;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if (IsOpen)
	    {
	        
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

           // Debug.Log(String.Format("{0} collision entered in collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            _globalAttributes = coll.gameObject.GetComponent<GlobalAttributes>();
            if (_globalAttributes != null && _spriteRenderer != null)
            {
                float enemyVectorX = _globalAttributes.movement_vector.x;
                float enemyVectorY = _globalAttributes.movement_vector.y;

                if (enemyVectorY == 1.0f || enemyVectorY == -1.0f)
                {
                    _spriteRenderer.sprite = HorizontalDoorSmashedSprite;
                    GameManager.Instance.ExplodeAtLocation(transform.position);
                }
                else if (enemyVectorX == 1.0f || enemyVectorX == -1.0f)
                {
                    _spriteRenderer.sprite = VerticalDoorSmashedSprite;
                    GameManager.Instance.ExplodeAtLocation(transform.position);
                }
            }
            Debug.Log(String.Format("{1} entering smashed the {0}!!", this.gameObject.tag, coll.gameObject.tag));
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
            //Debug.Log(String.Format("{0} collision exited collision with {1}", this.gameObject.tag, coll.gameObject.tag));
        }
        else if (coll.gameObject.tag.Equals("Enemy"))
        {
            _globalAttributes = coll.gameObject.GetComponent<GlobalAttributes>();
            if (_globalAttributes != null && _spriteRenderer != null)
            {
                float enemyVectorX = _globalAttributes.movement_vector.x;
                float enemyVectorY = _globalAttributes.movement_vector.y;

                if (enemyVectorY == 1.0f || enemyVectorY == -1.0f)
                {
                    _spriteRenderer.sprite = HorizontalDoorSmashedSprite;
                }
                else if (enemyVectorX == 1.0f || enemyVectorX == -1.0f)
                {
                    _spriteRenderer.sprite = VerticalDoorSmashedSprite;
                }
            }

            //Debug.Log(String.Format("{1} exiting smashed the {0}!!!", this.gameObject.tag, coll.gameObject.tag));
        }
    }

    public void OpenDoor()
    {
        IsOpen = true;
    }

}
