using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public static Sound Instance { get; private set; }

    AudioSource soundPlayer = new AudioSource();
    public AudioClip song;
    public float minimumPitch = 0.95f;
    public float maximumPitch = 1.05f;
    public int soundCapacity = 10;
    private int currentSound = 0;

    private AudioSource[] soundManager;

    void Awake()
    {
        Instance = this;

        soundManager = new AudioSource[soundCapacity];

        for(int i = 0; i < soundManager.Length; i++)
        {
            soundManager[i] = Instantiate(soundPlayer);
            soundManager[i].transform.parent = transform;
        }

    }

    public void PlaySound(AudioClip sfx, int distance)
    {

        if(sfx == null)
        {
            return;
        }

        soundManager[currentSound].clip = sfx;
        soundManager[currentSound].pitch = Random.Range(minimumPitch, maximumPitch);
        AdjustVolumeForDistance(distance);
        soundManager[currentSound].Play();

        if(currentSound == soundCapacity)
        {
            currentSound = 0;
        }
        else
        {
            currentSound++;
        }

    }

    private void AdjustVolumeForDistance(int distance)
    {
        soundManager[currentSound].volume /= distance;
    }
}
