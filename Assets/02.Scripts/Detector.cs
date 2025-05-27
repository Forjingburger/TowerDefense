using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //����ĳ��Ʈ�� ���콺 ���� Ŭ���� �� ��ǥ�� ����׷α׷� ���
    //3���� ���� -> 3���� �ݶ��̴��� ������.

    private TowerBuilder towerbuilder;

    [SerializeField] private List<GameObject> tileGroup = new List<GameObject>();

    private List<TileGround> tileGround = new List<TileGround>();

    public List<GameObject> TileGroup { get { return tileGroup; } }
    public List<TileGround> TileGround { get { return tileGround; } }

    private void Start()
    {
        towerbuilder = GetComponent<TowerBuilder>();

        for (int i = 0; i < tileGroup.Count; i++)
        {
            tileGround.Add(tileGroup[i].GetComponent<TileGround>());
        }

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
                    for(int i = 0; i < tileGroup.Count; i++)
                    {
                        if(hit.transform.position == tileGroup[i].transform.position)
                        {
                            TileGround tempTileGround = tileGround[i];
                            towerbuilder.TowerBuild(hit.transform.position, tempTileGround);
                        }
                    }
                }
            }
        }
    }
}
