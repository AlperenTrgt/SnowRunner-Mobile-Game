using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    
    [SerializeField] RawImage SoundOnIcon;
    [SerializeField] RawImage SoundOffIcon;
    public bool muted = false;
    /*
    private void Start()
    {
        if (PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;

    }*/
    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
        }
        Load();
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted= true;
            AudioListener.pause = true ;
        }
        else
        {
            muted= false;
            AudioListener.pause = false ;
        }
        Save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if(muted == false)
        {
            SoundOnIcon.enabled= true;
            SoundOffIcon.enabled = false;
        }
        else
        {
            SoundOnIcon.enabled= false;
            SoundOffIcon.enabled = true;
        }
    }
    void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    void Save()
    {
        PlayerPrefs.SetInt("muted", muted? 1:0);
    }
}
