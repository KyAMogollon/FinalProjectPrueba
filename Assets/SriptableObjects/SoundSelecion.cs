using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "SoundSelecion", menuName = "SoundSelecion/SoundSelecion", order = 0)]
public class SoundSelecion : ScriptableObject
{
    [SerializeField] AudioClip myAudio;
    [SerializeField] AudioMixerGroup myGroup;
    
    public void StartSoundSelection()
    {
        GameObject audioGameObject = new GameObject();
        AudioSource myAudioSource = audioGameObject.AddComponent<AudioSource>();

        myAudioSource.outputAudioMixerGroup = myGroup;
        myAudioSource.PlayOneShot(myAudio);
        Destroy(audioGameObject,1.5f);
    }
}
