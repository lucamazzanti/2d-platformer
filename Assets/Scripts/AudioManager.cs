using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] soundEffects;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(int index)
    {
        soundEffects[index].Stop();
        soundEffects[index].pitch = Random.Range(.9f,1.1f);
        soundEffects[index].Play();
    }

    public void PlaySoundEffect(string soundEffectName)
    {
        AudioSource soundEffect = soundEffects.FirstOrDefault(i => i.name == soundEffectName);
        if (soundEffect == null) return;
        soundEffect.Stop();
        soundEffect.pitch = Random.Range(.9f, 1.1f);
        soundEffect.Play();
    }
}
