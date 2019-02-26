using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour {

    private Button btn_Pause;
    private Button btn_Play;
    private Text txt_Scroe;
    private Text txt_DiamondCount;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        EventCenter.AddListener(EventDefine.ShowGamePanel, Show);
        btn_Pause = GameObject.Find("btn_Pause").GetComponent<Button>();
        btn_Pause.onClick.AddListener(OnPauseButtonClick);
        btn_Play = GameObject.Find("btn_Play").GetComponent<Button>();
        btn_Play.onClick.AddListener(OnPlayButtonClick);
        txt_DiamondCount = GameObject.Find("Diamond/txt_DiamondCount").GetComponent<Text>();
        txt_Scroe = GameObject.Find("txt_Score").GetComponent<Text>();
        gameObject.SetActive(false);
        btn_Play.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.ShowGamePanel, Show);
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void OnPauseButtonClick() {
        btn_Pause.gameObject.SetActive(false);
        btn_Play.gameObject.SetActive(true);
    }

    private void OnPlayButtonClick() {
        btn_Pause.gameObject.SetActive(true);
        btn_Play.gameObject.SetActive(false);
    }

}
