using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private float oldVolume;

    private void Start()
    {
        oldVolume=slider.value;
        if(!PlayerPrefs.HasKey("volume")) slider.value=1;
        else slider.value=PlayerPrefs.GetFloat("volume");
    }
    private void Update()
    {
        if(oldVolume !=slider.value)//если изменили значение
        {
            PlayerPrefs.SetFloat("volume",slider.value);
            PlayerPrefs.Save();
            oldVolume=slider.value;
        }
    }
}
