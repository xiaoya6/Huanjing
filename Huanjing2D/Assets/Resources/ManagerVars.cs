using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="CreateManagerVarContrainer")]
public class ManagerVars : ScriptableObject {
    public static ManagerVars GetManagerVars() {
        return Resources.Load<ManagerVars>("ManagerVarsContainer");
    }

    public List<Sprite> bgThemeSpriteList = new List<Sprite>();
    public List<Sprite> platformThemeSpriteList = new List<Sprite>();
    public GameObject normalPlatform;
    public GameObject normalPlatformPre;

    public List<GameObject> commonPlatformGroup = new List<GameObject>();
    public List<GameObject> grassPlatformGroup = new List<GameObject>();
    public List<GameObject> winterPlatformGroup = new List<GameObject>();
    public GameObject spkitePlatformLeft;
    public GameObject spikePlatformRight;

    public float nextXpos = 0.554f;
    public float nextYpos = 0.645f;
}
