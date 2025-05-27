using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //레이캐스트로 마우스 왼쪽 클릭한 곳 좌표를 디버그로그로 출력
    //3차원 광선 -> 3차원 콜라이더에 반응함.

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
