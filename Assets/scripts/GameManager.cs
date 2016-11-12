﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [InspectorButton("OnAlignClicked")]
    public bool AlignTiles;

    [InspectorButton("OnGenerateClicked")]
    public bool Generate;

    public GameObject FloorPrefab;
    public GameObject WallPrefab;
    public GameObject DoorPrefab;
    public int RoomId = 0;
    public int RoomSizeX = 1;
    public int RoomSizeY = 1;

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
                Mathf.Round(floor.transform.position.y * multiplier) / multiplier);
        }
        foreach (GameObject wall in walls)
        {
            wall.transform.position = new Vector3(
                Mathf.Round(wall.transform.position.x * multiplier) / multiplier,
                Mathf.Round(wall.transform.position.y * multiplier) / multiplier);
        }
        foreach (GameObject room in rooms)
        {
            room.transform.position = new Vector3(
                Mathf.Round(room.transform.position.x * multiplier) / multiplier,
                Mathf.Round(room.transform.position.y * multiplier) / multiplier);
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
                        GameObject wall = Instantiate(WallPrefab);
                        wall.transform.parent = Room.transform;
                        wall.name = "Wall " + i + "x" + j;
                        float size = wall.GetComponent<Renderer>().bounds.size.x;
                        wall.transform.localPosition = new Vector3(i * size, j * size);
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
}
