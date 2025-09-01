using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //Ÿ�� �Ǽ� �Լ��� �����, Detector���� �Ǽ� �Լ� ȣ���Ͽ� Ÿ�� ��ġ

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

 