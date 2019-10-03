using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMan : MonoBehaviour
{
    public AudioSource musicSFX;
    bool musicVolume;
    bool soundsVolume;

    // public bool MusicVolume
    // {
    //     get { return musicVolume; }
    // }

    // public bool SFXVolume
    // {
    //     get { return soundsVolume; }
    // }

    // public static AudioMan Instance;
    // private void Awake()
    // {
    //     Instance = this;
    //     GameObject.DontDestroyOnLoad(this.gameObject);

    //     musicVolume = true;
    //     soundsVolume = true;

    //     AudioValueVolume(musicVolume);
    // }

    // public void PlaySFX(AudioClip audioClip)
    // {
    //     SFXObject sfxObj = TrashMan.spawn("sfxObj").GetComponent<SFXObject>();
    //     sfxObj.PlaySFX(audioClip, soundsVolume);
    // }

    // public AudioClipCollection audioClipCollection;

    // public void PlaySFX(int idAudioClip)
    // {
    //     SFXObject sfxObj = TrashMan.spawn("SfxObj").GetComponent<SFXObject>();
    //     sfxObj.PlaySFX(audioClipCollection.audioClips[idAudioClip], soundsVolume);
    // }

    // public void PlaySFXInGroup(int idGroup)
    // {
    //     SFXObject sfxObj = TrashMan.spawn("SfxObj").GetComponent<SFXObject>();
    //     sfxObj.PlaySFX(audioClipCollection.GetNextAudioIngroup(idGroup), soundsVolume);
    // }

    // public void PlaySFXDirectInGroup(int idGroup, int idclip)
    // {
    //     SFXObject sfxObj = TrashMan.spawn("SfxObj").GetComponent<SFXObject>();
    //     sfxObj.PlaySFX(audioClipCollection.GetAudioClipInAudioIngroup(idGroup, idclip), soundsVolume);
    // }

    // public void SetMusicVolumeScale(int vol, int max)
    // {
    //     this.musicVolume = (float)vol / (float)max;
    //     DataMan.Instance.optionsData.MusicVolume = vol;

    //     AudioValueVolume(this.musicVolume);
    // }

    // public void SetSoundsVolumeScale(int vol, int max)
    // {
    //     this.soundsVolume = (float)vol / (float)max;
    //     DataMan.Instance.optionsData.SfxVolume = vol;
    // }

    // private void AudioValueVolume(float _value)
    // {
    //     musicSFX.volume = _value;
    // }

    // private void SoundValueVolume(SFXObject sfxObj, float _value)
    // {
    //     sfxObj.audioSource.volume =  _value;
    // }
}