using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // scripts referencees 
   
    private MusicManager musicManagerScript;
  
    // ui elements

    [SerializeField] private TextMeshProUGUI playButtonText;
    [SerializeField] private TextMeshProUGUI songNameText;
    [SerializeField] private Image songImage;

    // song name array and song image array

    [SerializeField] private string[] songNames;
    [SerializeField] private Sprite[] songImagesArray;

    private void Start()
    {
        playButtonText.text = "PLAY";

        //music manager reference

        musicManagerScript = FindObjectOfType<MusicManager>();
    }
    
    //Play buton change text function (when the song is playing it showa "play" and when it is paused it shows "pause")

    public void ChaangePlayButtonText()
    {
       if (musicManagerScript.cameraAudiosource.isPlaying)
        {
            playButtonText.text = "PLAY";
        }
        else
        {
            playButtonText.text = "PAUSE";
        }

    }

    // Change Song Name function

    public void ChangeSongName(int songNameArrayIndex)
    {
        songNameText.text = songNames[songNameArrayIndex];
    }
    public void ChangeImageSong(int songImageArrayIndex)
    {
        songImage.sprite = songImagesArray[songImageArrayIndex];
    }


}
