using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    AudioSource backgroundMusicSelected;
    UIManagerTech uIManagerTech;
    // Start is called before the first frame update
    void Start()
    {
        backgroundMusicSelected = GetComponent<AudioSource>();
        uIManagerTech = GameObject.Find("Pause Menu").GetComponent<UIManagerTech>();
        backgroundMusicSelected.clip = uIManagerTech.backgroundMusic[uIManagerTech.backgroundMusicIndex];
        backgroundMusicSelected.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMusic(int i)
    {
        backgroundMusicSelected.clip = uIManagerTech.backgroundMusic[i];
        backgroundMusicSelected.Play();
    }
    
}
