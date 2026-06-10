using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource titleMusic;

    public List<AudioSource> bgm = new List<AudioSource>();

    private bool bgmPlaying;
    private int currentTrack;

    public List<AudioSource> sfx = new List<AudioSource>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bgmPlaying == true)
        {
            if (bgm[currentTrack].isPlaying == false)
            {
                StartBGM();
            }
        }
    }

    public void StopMusic()
    {
        titleMusic.Stop();

        foreach (AudioSource track in bgm)
        {
            track.Stop();
        }

        bgmPlaying = false;
    }

    public void StartTitleMusic()
    {
        StopMusic();

        titleMusic.Play();
    }

    public void StartBGM()
    {
        StopMusic();

        bgmPlaying = true;

        currentTrack = Random.Range(0, bgm.Count);

        bgm[currentTrack].Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfx[sfxToPlay].Stop();

        sfx[sfxToPlay].Play();
    }
}
