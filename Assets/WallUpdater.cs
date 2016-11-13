using UnityEngine;
using System.Collections;
using System.Linq;
using BehaviourMachine;
using UnityEditor;

public class WallUpdater : MonoBehaviour
{
    private bool _hasNorthWall;
    private bool _hasEastWall;
    private bool _hasSouthWall;
    private bool _hasWestWall;
    private Sprite[] _sprites;

    void Awake()
    {
        _sprites = Resources.LoadAll<Sprite>("TemplateTiles");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            if (coll.transform.position.x > transform.position.x) // TO THE RIGHT
            {
                if (coll.transform.position.y > transform.position.y) // TO THE TOP
                {
                    return;
                }
                else if (coll.transform.position.y < transform.position.y) // TO THE BOTTOM
                {
                    return;
                }
                else
                {
                    _hasEastWall = true;
                }
            }
            else if (coll.transform.position.x < transform.position.x) // TO THE LEFT
            {
                if (coll.transform.position.y > transform.position.y) // TO THE TOP
                {
                    return;
                }
                else if (coll.transform.position.y < transform.position.y) // TO THE BOTTOM
                {
                    return;
                }
                else
                {
                    _hasWestWall = true;
                }
            }
            else
            {
                if (coll.transform.position.y > transform.position.y) // TO THE TOP
                {
                    _hasNorthWall = true;
                }
                else if (coll.transform.position.y < transform.position.y) // TO THE BOTTOM
                {
                    _hasSouthWall = true;
                }
                else
                {
                    return;
                }
            }
        }
        UpdateSprite();
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            if (coll.transform.position.x > transform.position.x) // TO THE RIGHT
            {
                if (coll.transform.position.y > transform.position.y) // TO THE TOP
                {
                    return;
                }
                else if (coll.transform.position.y < transform.position.y) // TO THE BOTTOM
                {
                    return;
                }
                else
                {
                    _hasEastWall = false;
                }
            }
            else if (coll.transform.position.x < transform.position.x) // TO THE LEFT
            {
                if (coll.transform.position.y > transform.position.y) // TO THE TOP
                {
                    return;
                }
                else if (coll.transform.position.y < transform.position.y) // TO THE BOTTOM
                {
                    return;
                }
                else
                {
                    _hasWestWall = false;
                }
            }
            else
            {
                if (coll.transform.position.y > transform.position.y) // TO THE TOP
                {
                    _hasNorthWall = false;
                }
                else if (coll.transform.position.y < transform.position.y) // TO THE BOTTOM
                {
                    _hasSouthWall = false;
                }
                else
                {
                    return;
                }
            }
        }
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        int value = 0;
        if (_hasNorthWall)
            value += 1;
        if (_hasEastWall)
            value += 2;
        if (_hasSouthWall)
            value += 4;
        if (_hasWestWall)
            value += 8;

        switch (value)
        {
            case 0:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileColumn");
                break;
            case 1:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileBottom");
                break;
            case 2:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileSideUpRight");
                break;
            case 3:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileBottomLeft");
                break;
            case 4:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTop");
                break;
            case 5:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "TemplateTiles_11");
                break;
            case 6:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTopLeft");
                break;
            case 7:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTRight");
                break;
            case 8:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileSideUpRight");
                break;
            case 9:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileBottomRight");
                break;
            case 10:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileSideUp");
                break;
            case 11:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTUp");
                break;
            case 12:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTopRight");
                break;
            case 13:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTLeft");
                break;
            case 14:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileTBottom");
                break;
            case 15:
                GetComponentInParent<SpriteRenderer>().sprite = _sprites.Single(s => s.name == "tileSide");
                break;
        }
    }
}
