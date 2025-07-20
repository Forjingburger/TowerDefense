using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //����ĳ��Ʈ�� ���콺 ���� Ŭ���� �� ��ǥ�� ����׷α׷� ���
    //3���� ���� -> 3���� �ݶ��̴��� ������.

    private TowerBuilder towerbuilder;

    private void Start()
    {
        towerbuilder = GetComponent<TowerBuilder>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.collider.CompareTag("Ground"))
                {
                    TileGround tempTileGround = hit.transform.GetComponent<TileGround>();
                    towerbuilder.TowerBuild(hit.transform.position, tempTileGround);
                }
            }
        }
    }
}
