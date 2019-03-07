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
    private Vector3 spikeDirPlatformPos;
    private bool spikeSpawnLeft = false;
    private int afterSpawnSpikeSpawnCount;
    private bool isSpawnSpike;
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
        if (isSpawnSpike)
        {
            AfterSpawnSpike();
            return;
        }
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
        int ranObstacleDir = Random.Range(0, 2);
        //生成单个平台
        if (spawPlatformCount >= 1)
        {
            SpawnNormalPlatform(ranObstacleDir);
        }
        //生成组合平台
        else if(spawPlatformCount ==0){
            int ram = Random.Range(0, 3);
            if (ram == 0)
            {
                SpawnCommonPlatformGroup(ranObstacleDir);
            }
            else if (ram == 1) {
                switch (groupType)
                {
                    case PlatformGroupType.grass:
                        SpawnGrassPlatformGroup(ranObstacleDir);
                        break;
                    case PlatformGroupType.winter:
                        SpawnWinterPlatformGroup(ranObstacleDir);
                        break;
                    default:
                        break;
                }
            } else{
                int value = -1;
                if (isLeftSpawn)
                {
                    value = 0;//生成右边方向的钉子
                }
                else {
                    value = 1;//生成左边方向的钉子
                }
                SpawnSpikePlatform(value);
                isSpawnSpike = true;
                afterSpawnSpikeSpawnCount = 4;
                if (spikeSpawnLeft)
                {//钉子在左边
                    spikeDirPlatformPos = new Vector3(platformSpawnPosition.x - 1.65f, platformSpawnPosition.y + vars.nextYpos, 0);
                }
                else {
                    spikeDirPlatformPos = new Vector3(platformSpawnPosition.x + 1.65f, platformSpawnPosition.y + vars.nextYpos, 0);
                }
            }
        }
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
    private void SpawnNormalPlatform(int ranObstacleDir) {
        GameObject go = Instantiate(vars.normalPlatform, transform);
        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectPlatformSprite, ranObstacleDir);
    }

    private void SpawnCommonPlatformGroup(int ranObstacleDir) {
        int ran = Random.Range(0, vars.commonPlatformGroup.Count);
        GameObject go = Instantiate(vars.commonPlatformGroup[ran], transform);
        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectPlatformSprite, ranObstacleDir);
    }

    private void SpawnGrassPlatformGroup(int ranObstacleDir)
    {
        int ran = Random.Range(0, vars.grassPlatformGroup.Count);
        GameObject go = Instantiate(vars.grassPlatformGroup[ran], transform);
        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectPlatformSprite, ranObstacleDir);
    }

    private void SpawnWinterPlatformGroup(int ranObstacleDir)
    {
        int ran = Random.Range(0, vars.winterPlatformGroup.Count);
        GameObject go = Instantiate(vars.winterPlatformGroup[ran], transform);
        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectPlatformSprite, ranObstacleDir);
    }

    private void SpawnSpikePlatform(int dir) {
        GameObject go;
        if (dir == 0)
        {
            spikeSpawnLeft = false;
          go = Instantiate(vars.spikePlatformRight, transform);
            
        }
        else {
            spikeSpawnLeft = true;
            go = Instantiate(vars.spkitePlatformLeft, transform);
            
        }

        go.transform.position = platformSpawnPosition;
        go.GetComponent<PlatformScript>().Init(selectPlatformSprite, 0);
    }

    /// <summary>
    /// 生成钉子平台
    /// </summary>
    private void AfterSpawnSpike() {
        if (afterSpawnSpikeSpawnCount > 0)
        {
            afterSpawnSpikeSpawnCount--;
            for (int i = 0; i < 2; i++)
            {

            }
        }
        else {
            isSpawnSpike = false;
            DecidePath();
        }
    }
}
