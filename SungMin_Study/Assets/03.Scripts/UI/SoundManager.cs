using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;
    public static SoundManager instance;

    
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SFXPlay(string name, AudioClip clip)
    {
        GameObject go = new GameObject(name + "sound");
        AudioSource audioSource = go.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audioSource.clip = clip;
        audioSource.Play();

        float leng = clip.length;
        //Destroy(go, clip.length);
        Destroy(go, leng);
    }

    public void BGMSoundVolume(float val)
    {
        mixer.SetFloat("BGMvolume", Mathf.Log10(val) * 20);
    }
    public void SFXSoundVolume(float val) //tt
    {
        mixer.SetFloat("SFXvolume", Mathf.Log10(val) * 20);
    }
}
