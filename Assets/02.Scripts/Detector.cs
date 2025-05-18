using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    //레이캐스트로 마우스 왼쪽 클릭한 곳 좌표를 디버그로그로 출력
    //3차원 광선 -> 3차원 콜라이더에 반응함.

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
                    Debug.Log(hit.point);
                    Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 3f);

                    towerbuilder.TowerBuild(hit.transform.position);
                }
            }
        }
    }
}
