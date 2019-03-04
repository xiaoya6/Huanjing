using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgTheme : MonoBehaviour {

    private SpriteRenderer m_spriteRenderer;
    private ManagerVars vars;
	// Use this for initialization
	void Awake () {
        vars = ManagerVars.GetManagerVars();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_spriteRenderer.sprite = vars.bgThemeSpriteList[Random.Range(0, vars.bgThemeSpriteList.Count)];
	}
	
}
