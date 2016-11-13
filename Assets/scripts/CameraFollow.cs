using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPosition = player.position;

        newPosition.z = transform.position.z;

        transform.position = newPosition;

	}
}
