using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSpeedScript : MonoBehaviour
{
    //지금은 x1 x2 x3 이미지만 있어서 1 2 3 배속만 구현
    //여기에 스크린 윗쪽 버튼들 한번에 묶어서 코딩할 예정
    public GameObject x1Button;
    public GameObject x2Button;
    public GameObject x3Button;
    public GameObject TowerInfoButton;
    public GameObject SettingButton;

    private bool pauseTester = true;
    private int timeScaleSaver;

    void Start()
    {
        x1Button.SetActive(true);
        x2Button.SetActive(false);
        x3Button.SetActive(false);
    }

    public void onClickx1Button()
    {
        while (pauseTester == true)
        {
            x1Button.SetActive(false);
            x2Button.SetActive(true);
            Time.timeScale = 2;
            timeScaleSaver = 2;
        }
    }

    public void onClickx2Button()
    {
        while (pauseTester == true)
        {
            x2Button.SetActive(false);
            x3Button.SetActive(true);
            Time.timeScale = 3;
            timeScaleSaver = 3;
        }
    }

    public void onClickx3Button()
    {
        while (pauseTester == true)
        {
            x3Button.SetActive(false);
            x1Button.SetActive(true);
            Time.timeScale = 1;
            timeScaleSaver = 1;
        }
    }

    public void onClickTowerInfoButton()
    {
        if (pauseTester == true)
        {
            Time.timeScale = 0;
            pauseTester = false;
        }

        else
        {
            Time.timeScale = timeScaleSaver;
            pauseTester = true;
        }
    }
}
