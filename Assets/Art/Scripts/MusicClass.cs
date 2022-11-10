using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource;
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) StopMusic();
        _audioSource.Play();
        _audioSource.loop = true;
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }

    public void OnChanged(float newValue = 0.5f)
    {
        GetComponent<AudioSource>().volume = newValue;
    }
}
