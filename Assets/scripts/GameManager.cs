using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }  // Singleton

    [InspectorButton("OnGameOverClicked")]
    public bool GameOver;

    [InspectorButton("OnAlignClicked")]
    public bool AlignTiles;

    [InspectorButton("OnGenerateClicked")]
    public bool Generate;

    public Image GameOverBackground;
    public Image GameOverMessage;
    public BarProgresser ProgressBar;
    public GameObject FloorPrefab;
    public GameObject Wall3DPrefab;
    public GameObject Wall2DPrefab;
    public GameObject DoorPrefab;
    public int RoomId = 0;
    public int RoomSizeX = 1;
    public int RoomSizeY = 1;

    void Awake()
    {
        Instance = this;
    }

    private void Align()
    {
        GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
        float size = floors[0].GetComponent<Renderer>().bounds.size.x;
        float multiplier = 1 / size;
        foreach (GameObject floor in floors)
        {
            floor.transform.position = new Vector3(
                Mathf.Round(floor.transform.position.x * multiplier) / multiplier,
                Mathf.Round(floor.transform.position.y * multiplier) / multiplier,
                floor.transform.position.z);
        }
        foreach (GameObject wall in walls)
        {
            wall.transform.position = new Vector3(
                Mathf.Round(wall.transform.position.x * multiplier) / multiplier,
                Mathf.Round(wall.transform.position.y * multiplier) / multiplier,
                wall.transform.position.z);
        }
        foreach (GameObject room in rooms)
        {
            room.transform.position = new Vector3(
                Mathf.Round(room.transform.position.x * multiplier) / multiplier,
                Mathf.Round(room.transform.position.y * multiplier) / multiplier,
                room.transform.position.z);
        }
    }

    private void GenerateRoom()
    {
        GameObject Room = new GameObject("Room " + RoomId);
        Room.tag = "Room";
        RoomId++;

        for (int j = 0; j < RoomSizeY + 2; ++j)
        {
            for (int i = 0; i < RoomSizeX + 1; ++i)
            {
                if (i == 0 || j == 0 || j == RoomSizeY + 1)
                {
                    if (j == (RoomSizeY + 1) / 2)
                    {
                        GameObject door = Instantiate(DoorPrefab);
                        door.transform.parent = Room.transform;
                        door.name = "Door " + i + "x" + j;
                        float size = door.GetComponent<Renderer>().bounds.size.x;
                        door.transform.localPosition = new Vector3(i * size, j * size);
                    }
                    else
                    {
                        GameObject wall3D = Instantiate(Wall3DPrefab);
                        wall3D.transform.parent = Room.transform;
                        wall3D.name = "Wall " + i + "x" + j;
                        float size = wall3D.GetComponent<Renderer>().bounds.size.x;
                        wall3D.transform.localPosition = new Vector3(i * size, j * size);
                        GameObject wall2D = Instantiate(Wall2DPrefab);
                        wall2D.transform.parent = wall3D.transform;
                        wall2D.name = "Wall Sprite " + i + "x" + j;
                        wall2D.transform.localPosition = new Vector3(0, 0, -0.75f);
                    }
                }
                else
                {
                    GameObject floor = Instantiate(FloorPrefab);
                    floor.transform.parent = Room.transform;
                    floor.name = "Floor " + i + "x" + j;
                    float size = floor.GetComponent<Renderer>().bounds.size.x;
                    floor.transform.localPosition = new Vector3(i * size, j * size);
                }
            }
        }
    }

    protected void OnAlignClicked()
    {
        Align();
        Align();
    }

    protected void OnGenerateClicked()
    {
        GenerateRoom();
    }

    protected void OnGameOverClicked()
    {
        StartCoroutine(TriggerGameOver());
    }

    public void TriggerGameOverEvent()
    {
        StartCoroutine(TriggerGameOver());
    }

    private IEnumerator TriggerGameOver()
    {
        Sound.Instance.PlaySound(0);
        Camera.main.GetComponent<GameOverShading>().IsShading = true;
        yield return new WaitForSeconds(5);
        Camera.main.GetComponent<GameOverShading>().IsShading = false;

        if (GameOverBackground != null && GameOverMessage != null)
        {
            GameOverBackground.color = Color.black;
            while (GameOverMessage.color.a <= 1)
            {
                GameOverMessage.color = new Color(GameOverMessage.color.r, 
                    GameOverMessage.color.g, 
                    GameOverMessage.color.b, 
                    GameOverMessage.color.a + 0.1f);
                yield return new WaitForSeconds(0.1f);
            }
        }

        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("UI/MainMenu");
    }
}
