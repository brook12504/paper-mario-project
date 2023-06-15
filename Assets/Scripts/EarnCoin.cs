using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EarnCoin : MonoBehaviour
{   

    private int gatheredCoin = 0;
    public AudioSource audioSource;

    public float jumpForce = 5f;
    public float jumpDuration = 0.5f;
    public float destroyDelay = 0.5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayEarnSound();
            StartCoroutine(JumpAndDestroy());
        }
    }

    private IEnumerator JumpAndDestroy()
    {
        // 위로 튀어오르는 동작
        rb.useGravity = true;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        yield return new WaitForSeconds(jumpDuration);

        // 일정 시간이 지난 후 오브젝트를 비활성화
        gameObject.SetActive(false);

        yield return new WaitForSeconds(destroyDelay);

        CollectCoin();
    }

    private void CollectCoin()
    {
        // 코인을 제거
        gatheredCoin++;
        Debug.Log("별 먹음");
        gameObject.SetActive(false);
    }

    public int GetCoin() {
        return gatheredCoin;
    }

    public void ResetCoin() {
        gatheredCoin = 0;
    }

    private void PlayEarnSound()
    {
        if (audioSource != null)
        {
            Debug.Log("별먹기 사운드");
            audioSource.Play();
        }
    }
}
