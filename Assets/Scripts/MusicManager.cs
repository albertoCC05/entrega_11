using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] songsArray;
    [SerializeField] private AudioSource cameraAudiosource;

    private float timeBetweenSongs;

    private void Start()
    {
        AsignSong();
     
    }
    private void AsignSong()
    {
        cameraAudiosource.clip = songsArray[0];
        cameraAudiosource.Play();
    }
    
}
