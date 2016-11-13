using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    public static Sound Instance { get; private set; }

    public AudioClip[] SoundList;
    public AudioSource soundPlayerPrefab;
    public float minimumPitch = 0.95f;
    public float maximumPitch = 1.05f;
    public int soundCapacity = 10;
    private int currentSound = 0;

    private AudioSource[] soundManager;

    void Awake()
    {
        Instance = this;

        soundManager = new AudioSource[soundCapacity];

        for (int i = 0; i < soundManager.Length; i++)
        {
            soundManager[i] = Instantiate(soundPlayerPrefab);
            soundManager[i].transform.parent = transform;
        }
    }

    public void PlaySound(int index, int distance = 1)
    {
        PlaySound(SoundList[index], distance);
    }

    public void PlaySound(AudioClip sfx, int distance = 1)
    {

        if(sfx == null)
        {
            return;
        }

        

        soundManager[currentSound].clip = sfx;
        soundManager[currentSound].pitch = Random.Range(minimumPitch, maximumPitch);
        AdjustVolumeForDistance(distance);
        soundManager[currentSound].Play();
        currentSound++;
        if (currentSound == soundCapacity)
        {
            currentSound = 0;
        }

    }

    private void AdjustVolumeForDistance(int distance)
    {
        soundManager[currentSound].volume /= distance;
    }
}
