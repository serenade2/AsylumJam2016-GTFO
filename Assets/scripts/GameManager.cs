using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [InspectorButton("OnAlignClicked")]
    public bool AlignTiles;

    private const float MULTIPLIER = 3.333333333333f;

    private void Align()
    {
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject floor in floors)
        {
            floor.transform.position = new Vector3(
                Mathf.Round(floor.transform.position.x * MULTIPLIER) / MULTIPLIER,
                Mathf.Round(floor.transform.position.y * MULTIPLIER) / MULTIPLIER);
        }
        foreach (GameObject wall in walls)
        {
            wall.transform.position = new Vector3(
                Mathf.Round(wall.transform.position.x * MULTIPLIER) / MULTIPLIER,
                Mathf.Round(wall.transform.position.y * MULTIPLIER) / MULTIPLIER);
        }
    }

    protected void OnAlignClicked()
    {
        Align();
    }
}
