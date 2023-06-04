using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject camera2D; // 2D 카메라
    public GameObject camera3D; // 3D 카메라

    public float moveSpeed = 5f; // 캐릭터 이동 속도

    private bool is2D = true; // 현재 시점이 2D인지 여부
    bool isGrounded = true;
    bool isPaused = false;
    private Rigidbody rb3D;

    void Start()
    {
        rb3D = GetComponent<Rigidbody>();

        camera2D.SetActive(true);
        camera3D.SetActive(false);
    }

    void Update(){
        // 시점 변환
        if (Input.GetKeyDown(KeyCode.E))
        {
            is2D = !is2D;
            camera2D.SetActive(is2D);
            camera3D.SetActive(!is2D);
        }
        //점프 기능
        if(Input.GetButtonDown("Jump") && isGrounded){
            rb3D.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            isGrounded = false;
        }
        //esc가 눌렸을 때 시간이 멈추게 하기.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void FixedUpdate()
    {
        // 이동
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
         if (is2D)
        {
            Vector3 movement = new Vector3(moveHorizontal * moveSpeed, rb3D.velocity.y, 0f);
            rb3D.velocity = movement;
        }
        else
        {
            Vector3 movement = new Vector3(moveVertical * moveSpeed, rb3D.velocity.y, -moveHorizontal * moveSpeed);
            rb3D.velocity = movement;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // 바닥과 충돌 체크
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // 시간을 멈추는 코드
            Time.timeScale = 0f;
        }
        else
        {
            // 시간을 다시 움직이도록 설정하는 코드
            Time.timeScale = 1f;
        }
    }
}
