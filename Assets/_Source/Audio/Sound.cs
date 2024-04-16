using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    
    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    public void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayOnce() {
        
        audioSource.PlayOneShot(audioClip);
    }
}
