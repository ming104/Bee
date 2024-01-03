using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Item_List
{
    public Sprite ItemListImage;
    public string ItemListName;
    public string ItemListInformation;
}

public class StartScene_Manager : MonoBehaviour
{
    public static StartScene_Manager instance;

    // 리스트
    public List<Item_List> itemlist = new List<Item_List>();

    [Header("Canvas")]
    [SerializeField] private GameObject SettingCanvas;
    [SerializeField] private GameObject ItemCanvas;
    [SerializeField] private GameObject Leader_Board_Canvas;

    [Header("Item_Canvas_Object")]
    [SerializeField] private int Item_Index;
    [SerializeField] private Image Item_Image;
    [SerializeField] private TextMeshProUGUI Item_Name;
    [SerializeField] private TextMeshProUGUI Item_Information;

    [SerializeField] private Button SoundOKButton;

    public List<TextMeshProUGUI> LeaderBorad_Text = new List<TextMeshProUGUI>();

    void Start()
    {
        GameObject.Find("Setting").transform.GetChild(0).gameObject.SetActive(false);
        SoundOKButton.onClick.AddListener(Setting_Button_Exit);
        Item_Image.sprite = itemlist[Item_Index].ItemListImage;
        Item_Name.text = itemlist[Item_Index].ItemListName;
        Item_Information.text = itemlist[Item_Index].ItemListInformation;
    }

    #region Buttons
    // 게임 시작 버튼
    public void GameStart()
    {
        SceneManager.LoadScene("GamePlay");
    }
    //--------

    // 설정 버튼
    public void Setting_Button()
    {
        GameObject.Find("Setting").transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Setting_Button_Exit()
    {
        GameObject.Find("Setting").transform.GetChild(0).gameObject.SetActive(false);
    }
    //--------

    // 아이템 관련 설정
    public void Item_Button()
    {
        ItemCanvas.SetActive(true);
    }

    public void Item_Button_Exit()
    {
        ItemCanvas.SetActive(false);
    }

    public void Right_ItemSelect_Button() // 아이템 리스트 변경
    {
        if (Item_Index < itemlist.Count - 1)
        {
            Item_Index++;
            Item_Image.sprite = itemlist[Item_Index].ItemListImage;
            Item_Name.text = itemlist[Item_Index].ItemListName;
            Item_Information.text = itemlist[Item_Index].ItemListInformation;
        }
    }

    public void Left_ItemSelect_Button() // 아이템 리스트 변경
    {
        if (0 < Item_Index)
        {
            Item_Index--;
            Item_Image.sprite = itemlist[Item_Index].ItemListImage;
            Item_Name.text = itemlist[Item_Index].ItemListName;
            Item_Information.text = itemlist[Item_Index].ItemListInformation;
        }
    }
    //--------


    // 리더보드 설정
    public void Leader_Board_Button()
    {
        Leader_Board_Canvas.SetActive(true);
        FirebaseManger.instance.LoadRanking();
    }

    public void Leader_Board_Button_Exit()
    {
        Leader_Board_Canvas.SetActive(false);
    }
    //--------

    #endregion Buttons
}
