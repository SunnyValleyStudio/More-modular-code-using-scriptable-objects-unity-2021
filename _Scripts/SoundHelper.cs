using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHelper : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private List<AudioClip> clips;

    public void PlayerClip()
    {
        AudioClip clip = clips[UnityEngine.Random.Range(0, clips.Count)];
        audioSource.PlayOneShot(clip);
    }
}
