using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//class that allows the user to set volume level
public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel (float sliderValue)
    {
        mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20 );
    }
}
