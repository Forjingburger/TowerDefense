using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //Ÿ�� �Ǽ� �Լ��� �����, Detector���� �Ǽ� �Լ� ȣ���Ͽ� Ÿ�� ��ġ

    [SerializeField] private GameObject towerObj;
    [SerializeField] private GameObject enemySpawnerObj;
    
    private Detector detector;

    private void Start()
    {
        detector = GetComponent<Detector>();
    }

    public void TowerBuild(Vector3 buildPos, TileGround clickedPlace)
    {
        if (!clickedPlace.IsBuildedPlace)
        {
            GameObject builtTower = Instantiate(towerObj, buildPos, Quaternion.identity);
            clickedPlace.IsBuildedPlace = true;
            Tower tower = builtTower.GetComponent<Tower>();
            EnemySpawner enemySpawner = enemySpawnerObj.GetComponent<EnemySpawner>();
            tower.Setup(enemySpawner);
            
        }
        else
        {
            return;
        }
    }
}

 