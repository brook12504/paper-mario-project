using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 사운드 볼륨을 조정과 관련된 클래스

public class SoundSettings : MonoBehaviour
{
    public Slider masterVolumeSlider;       // 전체 볼륨 슬라이더
    public Slider bgmVolumeSlider;          // 배경음악 볼륨 슬라이더
    public Slider sfxVolumeSlider;          // 효과음 볼륨 슬라이더

    public void OnMasterVolumeChanged(float value)
    {
        // 전체 볼륨 조절
        AudioListener.volume = value;
    }

    public void OnBGMVolumeChanged(float value)
    {
        // 배경음악 볼륨 조절
        // 배경음악 AudioSource에 접근하여 볼륨을 조절하는 로직을 추가하세요.
    }

    public void OnSFXVolumeChanged(float value)
    {
        // 효과음 볼륨 조절
        // 효과음 AudioSource에 접근하여 볼륨을 조절하는 로직을 추가하세요.
    }
}
