using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour {

    public Text result;
    public Text timeLasted;
    public Text ending;

    // Use this for initialization
    void Start () {

        float timeTotal = GameManager.Instance.GetTime();
        int minutes = (int)timeTotal / 60;
        int seconds = (int)timeTotal % 60;

        result.text = "It's over. The demon has escaped the mansion.";
        
        timeLasted.text = "You lasted a grand total of : " + string.Format("{0:0}:{1:00}", minutes, seconds);

        if (timeTotal < 120)
        {
            ending.text = "You were dispatched with great ease. \n" + "The demon was able to catch up to those you"
                + " were protecting, and managed to make enough sacrifices to complete his ritual. \n" + "He will"
                + " continue to be a plague upon mankind for all of eternity.";
        }
        else if(timeTotal >= 120 && timeTotal < 300)
        {
            ending.text = "You put up some resistance. \n" + "Although the demon was able to reach to your friends"
                + " and loved ones, he could not make enough sacrifices to finish the ritual. \n"
                + "Though he will carry on his bloody work, his time on Earth will be short.";
        }
        else
        {
            ending.text = "You put up quite a fight. \n" + "The demon was unable to find your friends"
                + " and family, and was thus prevented from completing his ritual. \n" + "He has"
                + " returned to Hell, where he will remain for all time... Hopefully.";
        }


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
