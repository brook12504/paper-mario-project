using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 다이얼로그식 일시정지 메뉴 관련 클래스 


public class MenuManager : MonoBehaviour
{
    public GameObject menuDialog; // 메뉴 다이얼로그를 담을 게임 오브젝트 변수
    public GameObject soundDialog;
    public GameObject ClearDialog;
    public GameObject GameOverDialog;

    private bool isMenuOpen = false; // 메뉴 다이얼로그가 열려있는지 여부를 저장하는 변수
    private bool isSoundOpen = false;
    private bool isClearOpen = false;
    private bool isGameOverOpen = false;

    private void Update()
    {
        // ESC 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 메뉴 다이얼로그의 활성화 상태 변경
            if (isMenuOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    private void OpenMenu()
    {
        // 메뉴 다이얼로그 활성화
        menuDialog.SetActive(true);

        // 게임 일시정지
        Time.timeScale = 0f;

        // 메뉴 상태 업데이트
        isMenuOpen = true;
    }

    public void CloseMenu()
    {
        // 메뉴 다이얼로그 비활성화
        menuDialog.SetActive(false);
        soundDialog.SetActive(false);

        // 게임 재개
        Time.timeScale = 1f;

        // 메뉴 상태 업데이트
        isMenuOpen = false;
        isSoundOpen = false;
    }

    public void SoundDialogOpen() 
    {
        menuDialog.SetActive(false);

        soundDialog.SetActive(true);
        isSoundOpen = true;
    }

    public void SoundDialogClose()
    {
        menuDialog.SetActive(true);
        isMenuOpen = true;

        soundDialog.SetActive(false);
        isSoundOpen = false;
    }

    public void openClearDialog() 
    {
        ClearDialog.SetActive(true);
        isClearOpen = true;
    }

    public void closeClearDialog() 
    {
        ClearDialog.SetActive(false);
        isClearOpen = false;
    }
    
    public void openGameOverDialog() 
    {
        GameOverDialog.SetActive(true);
        isGameOverOpen = true;
    }

    public void closeGameOverDialog() 
    {
        GameOverDialog.SetActive(false);
        isGameOverOpen = false;
    }
}