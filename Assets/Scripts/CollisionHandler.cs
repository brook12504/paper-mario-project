using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class CollisionHandler : MonoBehaviour
{
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
=======
using UnityEngine.Audio;


public class CollisionHandler : MonoBehaviour
{

    private int gatheredStar = 0;
    public AudioSource audioSource;

    public float jumpForce = 5f;
    public float jumpDuration = 0.5f;
    public float destroyDelay = 0.5f;

    private Rigidbody rb;


    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
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

        CollectStar();
    }

    private void CollectStar()
    {
        // 코인을 제거
        gatheredStar++;
        Debug.Log("별 먹음");
        gameObject.SetActive(false);
    }

    public int GetStar() {
        return gatheredStar;
    }

    public void ResetStar() {
        gatheredStar = 0;
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
>>>>>>> Stashed changes
