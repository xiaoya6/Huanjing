using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainPanel : MonoBehaviour {

    private Button btn_Start;
    private Button btn_Shop;
    private Button btn_Rank;
    private Button btn_Sound;

    private void Awake()
    {
        Init();
    }

    private void Init() {
        btn_Start = GameObject.Find("Btn_start").GetComponent<Button>();
        btn_Start.onClick.AddListener(OnStartButtonCilck);
        btn_Rank = GameObject.Find("Btns/Btn_rank").GetComponent<Button>();
        btn_Rank.onClick.AddListener(OnRankButtonClick);
        btn_Sound = GameObject.Find("Btns/Btn_sound").GetComponent<Button>();
        btn_Sound.onClick.AddListener(OnSoundButtonClick);
        btn_Shop = GameObject.Find("Btns/Btn_shop").GetComponent<Button>();
        btn_Shop.onClick.AddListener(OnShopButtonClick);
    }

    private void OnStartButtonCilck() {
        GameManager.Instance.IsGameStart = true;
        EventCenter.Broadcast(EventDefine.ShowGamePanel);
        gameObject.SetActive(false);
    }

    private void OnShopButtonClick() {

    }

    private void OnRankButtonClick()
    {

    }

    private void OnSoundButtonClick()
    {

    }
}
