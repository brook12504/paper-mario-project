using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Slider masterVolumeSlider; // 전체 볼륨을 조절하는 슬라이더
    public Slider backgroundMusicSlider; // 배경 음악 볼륨을 조절하는 슬라이더
    public Slider effectSoundSlider; // 효과음 볼륨을 조절하는 슬라이더

    public AudioSource hoverSound; // 버튼 호버 효과음을 저장할 AudioClip 변수
    public AudioSource clickSound;
    public AudioSource backgroundMusic;

    public AudioMixer audioMixer;

    private void Awake()
    {
        masterVolumeSlider = GameObject.Find("MasterVolumeSlider").GetComponent<Slider>();
        backgroundMusicSlider = GameObject.Find("BackgroundMusicSlider").GetComponent<Slider>();
        effectSoundSlider = GameObject.Find("EffectSoundSlider").GetComponent<Slider>();

        LoadVolumeSettings(); // 설정값을 불러옴
        
    }

    private void LoadVolumeSettings()
    {
        // 저장된 볼륨 값 불러오기
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float bgmVolume = PlayerPrefs.GetFloat("BackgroundMusicVolume", 1f);
        float effectVolume = PlayerPrefs.GetFloat("EffectSoundVolume", 1f);

        // 슬라이더에 볼륨 값 적용
        masterVolumeSlider.value = masterVolume;
        backgroundMusicSlider.value = bgmVolume;
        effectSoundSlider.value = effectVolume;

        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        audioMixer.SetFloat("BGMMixer", Mathf.Log10(bgmVolume) * 20);
        audioMixer.SetFloat("SFXMixer", Mathf.Log10(effectVolume) * 20);
    }

    private void SaveVolumeSettings()
    {
        // 슬라이더의 볼륨 값을 저장
        float masterVolume = masterVolumeSlider.value;
        float bgmVolume = backgroundMusicSlider.value;
        float effectVolume = effectSoundSlider.value;

        // PlayerPrefs에 볼륨 값 저장
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("BackgroundMusicVolume", bgmVolume);
        PlayerPrefs.SetFloat("EffectSoundVolume", effectVolume);

        // PlayerPrefs 값을 저장
        PlayerPrefs.Save();
    }

    public void PlayHoverSound()
    {
        if (hoverSound != null)
        {
            hoverSound.Play(); // 버튼 호버 효과음을 재생
            Debug.Log("버튼 호버 사운드 재생");
        }
        else
        {
            Debug.LogWarning("버튼 호버 사운드가 할당되지 않았습니다.");
        }
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            clickSound.Play(); // 버튼 클릭 효과음을 재생
            Debug.Log("버튼 클릭 사운드 재생");
        }
        else
        {
            Debug.LogWarning("버튼 클릭 사운드가 할당되지 않았습니다.");
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.loop = true; // 반복 재생 설정
            backgroundMusic.Play(); // 배경 음악 재생
        }
        else
        {
            Debug.LogWarning("배경 음악이 할당되지 않았습니다.");
        }
    }

    public void OnMasterVolumeChanged()
    {
        float volume = masterVolumeSlider.value;
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20); // Master 오디오믹서의 전체 볼륨을 조절
        SaveVolumeSettings(); // 볼륨 설정값 저장
    }

    public void OnBackgroundMusicVolumeChanged()
    {
        float volume = backgroundMusicSlider.value;
        audioMixer.SetFloat("BGMMixer", Mathf.Log10(volume) * 20); // BGM 오디오믹서의 볼륨을 조절
        SaveVolumeSettings(); // 볼륨 설정값 저장
    }

    public void OnEffectSoundVolumeChanged()
    {
        float volume = effectSoundSlider.value;
        audioMixer.SetFloat("SFXMixer", Mathf.Log10(volume) * 20); // SFX 오디오믹서의 볼륨을 조절
        SaveVolumeSettings(); // 볼륨 설정값 저장
    }
}
