using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public float timeLeftInSeconds = 180.0f;

    public Text timerText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        int minutes;
        int seconds;

        timeLeftInSeconds -= Time.deltaTime;

        minutes = (int)(timeLeftInSeconds / 60);
        seconds = (int)(timeLeftInSeconds % 60);

        timerText.text = minutes + " : " + seconds;

    }
}
