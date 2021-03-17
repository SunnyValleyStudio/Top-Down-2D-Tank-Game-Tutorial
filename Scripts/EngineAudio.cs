using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    private AudioSource audioSource;

    public float minVloume = 0.05f, maxVolume = 0.1f;
    public float volumeIncrease = 0.01f;
    [SerializeField]
    private float currentVolume;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentVolume = minVloume;
    }

    private void Start()
    {
        audioSource.volume = currentVolume;
    }

    public void ControlEngineVolume(float speed)
    {
        if (speed > 0)
        {
            if (currentVolume < maxVolume)
                currentVolume += volumeIncrease * Time.deltaTime;

        }
        else
        {
            if (currentVolume > minVloume)
                currentVolume -= volumeIncrease * Time.deltaTime;
        }
        currentVolume = Mathf.Clamp(currentVolume, minVloume, maxVolume);
        audioSource.volume = currentVolume;
    }
}
