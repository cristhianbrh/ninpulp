using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip soundFile;
    AudioSource audioSource;

    void Awake() {
        //audioSource = GetComponent<AudioSource>();
    }

    void OnEnable () {
        
    }
}
