using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource shutterSound;
    
    public void OnClickSound()
	{
        shutterSound.Stop();
        shutterSound.Play();
	}
}
