using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour
{

    public Transform seeker, target;
    public Rigidbody2D rbodySeeker;
    public float Speed;
    public float SpeedIncreasePerMinute = 0.2f;
    private bool _enemyTrappedStatus;
    public GameObject EnemyGameObject;
    private GlobalAttributes _globalAttributes;
    Grid grid;
    public List<Node> pathToTarget;
    Animator anim;

    void Awake()
    {
        grid = GetComponent<Grid>();
    }

    void Start()
    {
        grid = GetComponent<Grid>();
        anim = EnemyGameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        FindPath(seeker.position, target.position);

        if(pathToTarget.Count > 1)
        {
            // check if the enemy is trapped
            _globalAttributes = EnemyGameObject.GetComponent<GlobalAttributes>();
            if (_globalAttributes != null)
            {
                //sound.instance.playSound(3,4)
                if (!_globalAttributes.IsTrapped)
                {
                    float nbSecPass = GameManager.Instance.GetTime();
                    float realSpeed = Speed + SpeedIncreasePerMinute / 60 * nbSecPass;
                    Vector3 seekPositionVector3 = seeker.position;
                    float xSeek = seekPositionVector3.x;
                    float ySeek = seekPositionVector3.y;

                    seeker.position = Vector3.MoveTowards(seeker.position, pathToTarget[0].worldPosition, realSpeed * Time.deltaTime);
                    Vector2 movementVector2 = Vector2.zero;

                    if (seeker.position.x > xSeek)
                    {
                        //if true then moving right
                        movementVector2.x = 1.0f;
                    }
                    else if (seeker.position.x < xSeek)
                    {
                        // moving left
                        movementVector2.x = -1.0f;
                    }
                    if (seeker.position.y > ySeek)
                    {
                        //if true then moving up
                        movementVector2.y = 1.0f;
                    }
                    else if (seeker.position.y < ySeek)
                    {
                        // moving down
                        movementVector2.y = -1.0f;
                    }
                    anim.SetBool("isWalking", true);
                    anim.SetFloat("input_x", movementVector2.x);
                    anim.SetFloat("input_y", movementVector2.y);

                    _globalAttributes.set_movement_vector(movementVector2);

                }
            }
            
        }
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.GetNodeFromWorldPoint(startPos);
        Node targetNode = grid.GetNodeFromWorldPoint(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();
        openSet.Add(startNode);

        while (openSet.Count > 0)
        {
            Node node = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost)
                {
                    if (openSet[i].hCost < node.hCost)
                        node = openSet[i];
                }
            }

            openSet.Remove(node);
            closedSet.Add(node);

            if (node == targetNode)
            {
                RetracePath(startNode, targetNode);
                return;
            }

            foreach (Node neighbour in grid.GetNeighbours(node))
            {
                if (!neighbour.walkable || closedSet.Contains(neighbour))
                {
                    continue;
                }

                int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
                if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newCostToNeighbour;
                    neighbour.hCost = GetDistance(neighbour, targetNode);
                    neighbour.parent = node;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
    }

    void RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;

        while (currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }
        path.Reverse();

        grid.path = path;

        //test
        pathToTarget = path;
    }

    int GetDistance(Node nodeA, Node nodeB)
    {
        int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (dstX > dstY)
            return 14 * dstY + 10 * (dstX - dstY);
        return 14 * dstX + 10 * (dstY - dstX);
    }
}