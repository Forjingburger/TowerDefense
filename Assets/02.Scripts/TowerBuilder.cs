using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //Ÿ�� �Ǽ� �Լ��� �����, Detector���� �Ǽ� �Լ� ȣ���Ͽ� Ÿ�� ��ġ

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

 