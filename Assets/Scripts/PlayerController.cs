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
    private bool isInvincible = false;
    public float invincibilityDuration = 2f; // 무적 지속 시간
    private float invincibilityTimer = 0f; // 무적 타이머
    private Heart heartScript;
    public float blinkDuration = 2f; // 깜박임 지속 시간
    public float blinkInterval = 0.2f; // 깜박임 간격

    private Renderer renderer;
    private bool isBlinking = false; // 깜박임 상태 여부
    private float blinkTimer = 0f; // 깜박임 타이머

    private bool isEKeyPressed = false;
    
    // 다이얼로그 변수

    public GameObject gameoverDialog;
    public GameObject clearDialog;

    void Start()
    {
        heartScript = GetComponent<Heart>();
        rb3D = GetComponent<Rigidbody>();

        camera2D.SetActive(true);
        camera3D.SetActive(false);
        renderer = GetComponent<Renderer>();
    }

    void Update(){
        // 시점 변환
       
        
        if (Input.GetKeyDown(KeyCode.E) && !isEKeyPressed)
        {
            isEKeyPressed = true;
            StartCoroutine(WaitAndExecute()); //1초 대기후 명령어 실행
            
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

        // 무적 상태인 경우 타이머 감소
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
            }
        }

        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer >= blinkDuration)
            {
                StopBlinking();
            }
            else
            {
                // 깜박임 간격에 맞춰서 활성화/비활성화 상태를 변경하여 깜박임 효과를 나타냄
                float remainder = blinkTimer % (2 * blinkInterval);
                bool isVisible = remainder < blinkInterval;
                renderer.enabled = isVisible;
            }
        }


    }

   
    
    //1초 대기후 카메라 시점 변환 명령어를 실행하기 위해 삽입
    IEnumerator WaitAndExecute()
    {

        yield return new WaitForSeconds(1f);
        is2D = !is2D;
        if(is2D){
            Vector3 currentPosition = transform.position;
            currentPosition.z = -0.5f;
            transform.position = currentPosition;
        }
        camera2D.SetActive(is2D);
        camera3D.SetActive(!is2D);
        yield return new WaitForSeconds(1f);
        isEKeyPressed = false;
    
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

        // 충돌한 객체가 "Mob" 태그를 가지고 있는 경우에만 처리
        if (collision.gameObject.CompareTag("Mob"))
        {
            if (!isInvincible)
            {
                heartScript.health -= 1;
                
                if (heartScript.health <= 0)
                {
                    GameOver();
                }
                else
                {
                    StartInvincibility();
                    StartBlinking();
                }
            }
        }

        // 바닥과 충돌 체크
        if (collision.gameObject.CompareTag("FallDeadGround")){
            heartScript.health = 0;
            GameOver();
        }
            
    }

    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        // 무적 상태에 대한 시각적인 처리 로직 추가 가능
    }

    private void GameOver()
    {
        gameoverDialog.SetActive(true);
        renderer.enabled = false;
    }

    private void GameClear() 
    {
        clearDialog.SetActive(true);
    }

    private void StartBlinking()
    {
        isBlinking = true;
        blinkTimer = 0f;
    }
    
    private void StopBlinking()
    {
        isBlinking = false;
        renderer.enabled = true;
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
