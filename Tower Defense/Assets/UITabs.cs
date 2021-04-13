using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITabs : MonoBehaviour //이건 보면 대충 알거임 ㅋㅋㅋㅋㅋ
{

    public List<GameObject> UI_TABS;
    public List<GameObject> Buttons;

    public void Start()
    {
        UI_TABS[0].SetActive(true);
        Buttons[0].SetActive(false);
        UI_TABS[1].SetActive(false);
        Buttons[1].SetActive(true);
        UI_TABS[2].SetActive(false);
        Buttons[2].SetActive(true);
        UI_TABS[3].SetActive(false);
        Buttons[3].SetActive(true);

    }
    public void OnClickTab1()
    {
        Debug.Log("btn1");
        UI_TABS[0].SetActive(true);
        Buttons[0].SetActive(false);
        UI_TABS[1].SetActive(false);
        Buttons[1].SetActive(true);
        UI_TABS[2].SetActive(false);
        Buttons[2].SetActive(true);
        UI_TABS[3].SetActive(false);
        Buttons[3].SetActive(true);
    }
    public void OnClickTab2()
    {
        Debug.Log("btn2");
        UI_TABS[0].SetActive(false);
        Buttons[0].SetActive(true);
        UI_TABS[1].SetActive(true);
        Buttons[1].SetActive(false);
        UI_TABS[2].SetActive(false);
        Buttons[2].SetActive(true);
        UI_TABS[3].SetActive(false);
        Buttons[3].SetActive(true);
    }
    public void OnClickTab3()
    {
        Debug.Log("btn3");
        UI_TABS[0].SetActive(false);
        Buttons[0].SetActive(true);
        UI_TABS[1].SetActive(false);
        Buttons[1].SetActive(true);
        UI_TABS[2].SetActive(true);
        Buttons[2].SetActive(false);
        UI_TABS[3].SetActive(false);
        Buttons[3].SetActive(true);
    }
    public void OnClickTab4()
    {
        Debug.Log("btn4");
        UI_TABS[0].SetActive(false);
        Buttons[0].SetActive(true);
        UI_TABS[1].SetActive(false);
        Buttons[1].SetActive(true);
        UI_TABS[2].SetActive(false);
        Buttons[2].SetActive(true);
        UI_TABS[3].SetActive(true);
        Buttons[3].SetActive(false);
    }

    public void OnClickButton1test()
    {
        Debug.Log("innerbtn1");
    }
    public void OnClickButton2test()
    {
        Debug.Log("innerbtn2");
    }
}
