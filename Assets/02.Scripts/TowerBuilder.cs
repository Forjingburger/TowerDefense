using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //타워 건설 함수를 만들고, Detector에서 건설 함수 호출하여 타워 설치

    [SerializeField] private GameObject towerObj;
    EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();
    }

    public void TowerBuild(Vector3 buildPos, TileGround clickedPlace)
    {
        if (!clickedPlace.IsBuildedPlace)
        {
            GameObject builtTower = Instantiate(towerObj, buildPos, Quaternion.identity);
            clickedPlace.IsBuildedPlace = true;
            Tower tower = builtTower.GetComponent<Tower>();
            tower.Setup(enemySpawner);
            
        }
    }
}

 