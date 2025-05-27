using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //타워 건설 함수를 만들고, Detector에서 건설 함수 호출하여 타워 설치

    [SerializeField] private GameObject towerObj;
    private Detector detector;

    private void Start()
    {
        detector = GetComponent<Detector>();
    }

    public void TowerBuild(Vector3 buildPos, TileGround clickedPlace)
    {
        if (!clickedPlace.IsBuildedPlace)
        {
            Instantiate(towerObj, buildPos, Quaternion.identity);
            clickedPlace.DetectTower();
        }
        else
        {
            return;
        }
    }
}

 