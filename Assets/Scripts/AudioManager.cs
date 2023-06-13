using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip hoverSound; // 버튼 호버 효과음을 저장할 AudioClip 변수
    public AudioClip clickSound;

    private AudioSource audioSource; // 효과음 재생에 사용할 AudioSource 컴포넌트

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // AudioSource 컴포넌트를 가져옴
    }

    public void PlayHoverSound()
    {
        audioSource.PlayOneShot(hoverSound); // 버튼 호버 효과음을 재생
        Debug.Log("버튼 호버 사운드 재생");
    }

    public void clickSoundPlay() {
        audioSource.PlayOneShot(clickSound);
        Debug.Log("버튼 클릭 사운드 재생");
    }

}

