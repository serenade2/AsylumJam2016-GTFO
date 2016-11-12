using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {

    AudioSource musicPlayer = new AudioSource();
    public AudioClip song;

	// Use this for initialization
	void Start () {

        musicPlayer.clip = song;
        musicPlayer.loop = true;
        musicPlayer.Play();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
