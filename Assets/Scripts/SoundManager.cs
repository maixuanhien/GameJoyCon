using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager> {

    [SerializeField]
    private AudioSource sceneAudioSource;
    [SerializeField]
    private AudioSource audioGuide;
    [SerializeField]
    private AudioClip main;
    [SerializeField]
    private List<AudioClip> listAudioBalloon;
    [SerializeField]
    private List<AudioClip> listAudioLetter;

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        SelectSceneSound();
    }

    private void SelectSceneSound() {
        if (SceneManager.GetActiveScene().name == Constants.SCENE_1) {
            PlaySceneSound(main, true);
        }
    }

    private void PlaySceneSound(AudioClip audio, bool loop) {
        sceneAudioSource.clip = audio;
        sceneAudioSource.Play();
        sceneAudioSource.loop = loop;
    }

    public void PlaySoundGuide(bool isBalloon, int index) {
        if (isBalloon) {
            if (index < listAudioBalloon.Count) {
                PlaySoundGuide(listAudioBalloon[index]);
            }
        } else {
            if (index < listAudioLetter.Count) {
                PlaySoundGuide(listAudioLetter[index]);
            }
        }
    }

    private void PlaySoundGuide(AudioClip audio, bool loop = false) {
        StopAllCoroutines();
        StartCoroutine(SoundGuide(audio, loop));
    }

    IEnumerator SoundGuide(AudioClip audio, bool loop = false) {
        if (audioGuide.isPlaying) {
            yield return null;
        }
        audioGuide.clip = audio;
        audioGuide.Play();
        audioGuide.loop = loop;
    }
}
