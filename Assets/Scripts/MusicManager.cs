using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{

    // reference of UiManager Script

    private UiManager uiManagerScript;

    // songs array and array index variable

    [SerializeField] private AudioClip[] songsArray;
    private int songNumber = 0;

    //audiosource reference

    public AudioSource cameraAudiosource;
    
    // condiions for detect if rndom and loop modes are activated or not

    private bool songIsOnLooop = false;
    private bool randomModeActivated = false;
 
    // reference of the random toggle to dissable it when loop is activated

    [SerializeField] private Toggle randomToggle;

    

    private void Start()
    {
        //reference of UiManager
        uiManagerScript = FindObjectOfType<UiManager>();


        StartMusic();
     
    }
    private void Update()
    {
        NextSongAtFinishCurrentSong();
        RandomReproduction();
    }

    // normal mode funcions

    private void StartMusic()
    {
        cameraAudiosource.clip = songsArray[songNumber];
        cameraAudiosource.Play();
        uiManagerScript.ChangeSongName(songNumber);
        uiManagerScript.ChangeImageSong(songNumber);
        
    }
    private void NextSongAtFinishCurrentSong()
    {
        if (cameraAudiosource.time >= cameraAudiosource.clip.length && !songIsOnLooop && !randomModeActivated)
        {
            songNumber++;
            cameraAudiosource.clip = songsArray[songNumber];
            cameraAudiosource.Play();
            uiManagerScript.ChangeSongName(songNumber);
            uiManagerScript.ChangeImageSong(songNumber);


        }
    }
    public void PauseAndPlay()
    {
        if (cameraAudiosource.isPlaying)
        {
            cameraAudiosource.Pause();
        }
        else
        {
            cameraAudiosource.UnPause();
        }
    }
    public void NextSongButton()
    {
        if (!randomModeActivated && !songIsOnLooop)
        {
            songNumber++;

            if (songNumber > songsArray.Length - 1 )
            {
                songNumber = 0;
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);
            }
            else if (songNumber <= songsArray.Length - 1 )
            {
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);
            }
        }
        else if (randomModeActivated && !songIsOnLooop)
        {
            
            
            if ( songNumber < songsArray.Length - 1)
            {
                songNumber = Random.Range(songNumber, songsArray.Length - 1);
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);

            }
            else if (songNumber >= 14) 
            {
                songNumber = Random.Range(0, songsArray.Length - 1);
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);


            }




        }
        
       
    }
    public void PreviusSongButton()
    {
        if (!randomModeActivated && !songIsOnLooop)
        {
            songNumber--;

            if (songNumber < 0 && !randomModeActivated)
            {
                songNumber = songsArray.Length - 1;
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);

            }
            else if (songNumber >= 0 && !songIsOnLooop && !randomModeActivated)
            {
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);

            }
        }
        else if (randomModeActivated && !songIsOnLooop)
        {


            if (songNumber > 0)
            {
                songNumber = Random.Range(0, songNumber);
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);

            }
            else if (songNumber <= 0)
            {
                songNumber = Random.Range(0, songsArray.Length - 1);
                cameraAudiosource.clip = songsArray[songNumber];
                cameraAudiosource.Play();
                uiManagerScript.ChangeSongName(songNumber);
                uiManagerScript.ChangeImageSong(songNumber);


            }




        }

    }

    // loop mode functions
    
    public void Loop()
    {
        if (!songIsOnLooop)
        {
            songIsOnLooop = true;
            cameraAudiosource.loop = true;
            randomToggle.interactable = false;
            
        }
        else
        {
            songIsOnLooop = false;
            cameraAudiosource.loop = false;
            randomToggle.interactable = true;
        }
    }   
    
    //random mode functions

    public void RandomToggle()
    {
        if (!randomModeActivated)
        {
            randomModeActivated = true;

        }
        else
        {
            randomModeActivated = false;
        }

    }
    private void RandomReproduction()
    {
        if (cameraAudiosource.time >= cameraAudiosource.clip.length && !songIsOnLooop && randomModeActivated)
        {
            songNumber = Random.Range(0, songsArray.Length - 1);
            cameraAudiosource.clip = songsArray[songNumber];
            cameraAudiosource.Play();
            uiManagerScript.ChangeSongName(songNumber);
            uiManagerScript.ChangeImageSong(songNumber);



        }

    }
    
    

}
