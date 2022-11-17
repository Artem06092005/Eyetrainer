using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio1;
    [SerializeField]
    private AudioSource audio2;
    [SerializeField]
    private AudioSource audio3;
    [SerializeField]
    private AudioSource audio4;
    [SerializeField]
    private AudioSource audio5;
    private void Update()
    {
        audio1.volume=PlayerPrefs.GetFloat("volume");
        audio2.volume=PlayerPrefs.GetFloat("volume");
        audio3.volume=PlayerPrefs.GetFloat("volume");
        audio4.volume=PlayerPrefs.GetFloat("volume");
        audio5.volume=PlayerPrefs.GetFloat("volume");
    }
}
