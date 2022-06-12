using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _shot;

    public void PlaySoundShot()
    {
        if (SoundController.Instance.IsSoundOn())
        {
            _audioSource.PlayOneShot(_shot);
        }
    }
}
