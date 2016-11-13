using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    
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
        
        float timeInSeconds = GameManager.Instance.GetTime();

        int minutes;
        int seconds;

        minutes = (int)(timeInSeconds / 60);
        seconds = (int)(timeInSeconds % 60);

        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

    }

    // OnGUI is called just like Update, once per frame
    void OnGUI()
    {

    }
}
