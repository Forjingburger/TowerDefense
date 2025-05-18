using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //Ÿ�� �Ǽ� �Լ��� �����, Detector���� �Ǽ� �Լ� ȣ���Ͽ� Ÿ�� ��ġ

    [SerializeField] private GameObject towerObj;

    public void TowerBuild(Vector3 buildPos)
    {
        Instantiate(towerObj, buildPos, Quaternion.identity);
    }
}
