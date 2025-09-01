using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3EX : MonoBehaviour
{
    //벡터는 움직임 그 자체를 의미한다.
    //벡터는 방향과 크기를 가지고 있다.

    private Vector3 targetPosition = new Vector3(100, 100, 100);
    
    private void Start()
    {
        //목표로 향하는 벡터 구하는 법
        Vector3 dir = targetPosition - transform.position;
    }
}
