using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    //Ÿ�� �Ǽ� �Լ��� �����, Detector���� �Ǽ� �Լ� ȣ���Ͽ� Ÿ�� ��ġ

    [SerializeField] private GameObject towerObj;
    [SerializeField] private List<GameObject> tileGroup = new List<GameObject>();
    TileGround tileGround;

    public List<GameObject> TileGroup {  get { return tileGroup; } }


    public void TowerBuild(Vector3 buildPos)
    {
        for(int i = 0; i < tileGroup.Count; i++)
        {
            Debug.Log(i);
            tileGround = tileGroup[i].GetComponent<TileGround>();

            //if(tileGroup[i].transform.position == buildPos)
            //{
            //    Instantiate(towerObj, buildPos, Quaternion.identity);
            //}
        }

        

        //if (!tileGround.IsBuildedPlace)
        //{
        //    Instantiate(towerObj, buildPos, Quaternion.identity);
        //    tileGround.DetectTower();
        //}
    }
}
