using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance => _instance;
   
    public float Volume;

    [SerializeField] AudioSource[] SoundEffectSources;
    [SerializeField] AudioSource Music1;
    [SerializeField] AudioSource Music2;

    public AudioSource CurrentMusic;

    int _index = 0;

    [SerializeField] AudioSource CutAudioSources;

    int _indexcut = 0;

    [SerializeField] AudioSource Voices;

    Queue<AudioClip> voiceclips;

    private void Awake()
    {
        if (_instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            voiceclips = new Queue<AudioClip>();
            CurrentMusic = Music1;
        }
    }

    public void StopAllSounds(string tag)
    {
        foreach(var a in SoundEffectSources)
        {
            if (a.tag == tag)
                a.Stop();
        }
    }

    public AudioSource PlayEffect(AudioClip clip, Transform emmiter, float pitch_value)
    {
        AudioSource audioSource = SoundEffectSources[_index];

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.transform.position = emmiter.position;
        audioSource.tag = emmiter.tag;
        audioSource.pitch = pitch_value;
        audioSource.Play();

        _index = (_index + 1) % SoundEffectSources.Length;

        return audioSource;
    }

    internal AudioSource PlayCutSound(AudioClip clip, bool loop)
    {
        AudioSource audioSource = Instantiate<AudioSource>(CutAudioSources);

        //audioSource.Stop();
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();

        
        return audioSource;
    }

    public AudioSource PlayEffect(AudioClip clip)
    {
        return PlayEffect(clip, this.transform, 1);
    }

    internal void ChangeEffectsVolume(float value)
    {
        Volume = value;
        foreach (var a in SoundEffectSources)
        {
            a.volume = value;
        }

    }

    public void PlayVoice(AudioClip clip, float silencio, Action callback)
    {
        //voiceclips.Enqueue(clip);
        Voices.clip = clip;

        Voices.Play();
        CurrentMusic.volume = 0.5f;
        StartCoroutine(WaitForFinishVoice(Voices, silencio, callback));
    }

    IEnumerator WaitForFinishVoice(AudioSource source, float silencio, Action callback)
    {
        yield return new WaitForSecondsRealtime(silencio);
        while (source.isPlaying)
            yield return new WaitForSecondsRealtime(0.05f);
        CurrentMusic.volume = 1;
        callback?.Invoke();

    }

    float deltaTime = 0;

    private void Update()
    {
        if (voiceclips.Count > 0 && !Voices.isPlaying)
        {
            var clip = voiceclips.Dequeue();

            Voices.clip = clip;

            Voices.Play();

        }
        deltaTime += Time.deltaTime;
    }


    public void ChangeMusic(AudioClip clip, float time, bool loop, bool cross = false)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeMusic_Coroutine(clip, time, loop, cross));
    }

    IEnumerator ChangeMusic_Coroutine(AudioClip clip, float time, bool loop, bool cross)
    {
        var current = CurrentMusic;
        var next = GetOtherMusic(current);
        next.Stop();
        next.clip = clip;
        next.loop = loop;
        next.volume = 0;
        float timer = 0;
        if (cross)
        {
            
            next.Play();
            while (timer < time)
            {
                timer += deltaTime; deltaTime = 0;
                current.volume = (1 - timer / time) * Volume;
                next.volume = (timer / time) * Volume;
                yield return null;
            }
             
        }
        else
        {
            while (timer < time)
            {
                timer += deltaTime; deltaTime = 0;
                current.volume = (1 - timer / time) * Volume;
                yield return null;
            }
            next.volume = Volume;
            next.Play();

        }
        CurrentMusic = next;

    }

    AudioSource GetOtherMusic(AudioSource source)
    {
        if (source == Music1) return Music2;
        else return Music1;

    }
}
