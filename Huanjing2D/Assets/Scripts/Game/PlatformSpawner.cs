using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformGroupType {
    grass,
    winter
}

public class PlatformSpawner : MonoBehaviour {
    public Vector3 startSpawnPos;
    private int spawPlatformCount;

    private Vector3 platformSpawnPosition;
    private ManagerVars vars;
    private bool isLeftSpawn;
    private Sprite selectPlatformSprite;
    private PlatformGroupType groupType;

    private void Awake()
    {
        EventCenter.AddListener(EventDefine.DecidePath,DecidePath);
        vars = ManagerVars.GetManagerVars();
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventDefine.DecidePath, DecidePath);
    }
    private void Start()
    {
        RamdomPlatformTheme();
        platformSpawnPosition = startSpawnPos;
        for (int i = 0; i < 5; i++)
        {
            spawPlatformCount=5;
            DecidePath();
        }

        GameObject go = Instantiate(vars.normalPlatformPre);
        go.transform.position = new Vector3(0, -1.8f, 0);
    }

    private void RamdomPlatformTheme()
    {
        int ram = Random.Range(0, vars.platformThemeSpriteList.Count);
        selectPlatformSprite = vars.platformThemeSpriteList[ram];
        if (ram == 2)
        {
            groupType = PlatformGroupType.winter;
        }
        else {
            groupType = PlatformGroupType.grass;
        }
    }

    public void DecidePath() {
        if (spawPlatformCount > 0)
        {

            spawPlatformCount--;
            SpawnPlatform();
        }
        else {
            isLeftSpawn = !isLeftSpawn;
            spawPlatformCount = Random.Range(1, 4);
            SpawnPlatform();
        }
    }

    //生成平台
    private void SpawnPlatform() {
        SpawnNormalPlatform();
        if (isLeftSpawn)
        {
            platformSpawnPosition = new Vector3(platformSpawnPosition.x - vars.nextXpos, platformSpawnPosition.y + vars.nextYpos, 0);
        }
        else {
            platformSpawnPosition = new Vector3(platformSpawnPosition.x + vars.nextXpos, platformSpawnPosition.y + vars.nextYpos, 0);
        }
    }

    /// <summary>
    /// 生成单个普通平台
    /// </summary>
    private void SpawnNormalPlatform() {
        GameObject go = Instantiate(vars.normalPlatform, transform);
        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectPlatformSprite);
    }
}
