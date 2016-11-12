using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    public float timeLeftInSeconds = 180.0f;

    public Text timerText;

    public Image trap1Image;
    public int trap1Counter;
    public Text trap1Text;

    public Image trap2Image;
    public int trap2Counter;
    public Text trap2Text;

    public Image trap3Image;
    public int trap3Counter;
    public Text trap3Text;

    public Image trap4Image;
    public int trap4Counter;
    public Text trap4Text;

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

    // OnGUI is called just like Update, once per frame
    void OnGUI()
    {
        
        trap1Text.text = " x " + trap1Counter;
        trap2Text.text = " x " + trap2Counter;
        trap3Text.text = " x " + trap3Counter;
        trap4Text.text = " x " + trap4Counter;

    }
}
