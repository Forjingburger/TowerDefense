using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3EX : MonoBehaviour
{
    //���ʹ� ������ �� ��ü�� �ǹ��Ѵ�.
    //���ʹ� ����� ũ�⸦ ������ �ִ�.

    private Vector3 targetPosition = new Vector3(100, 100, 100);
    
    private void Start()
    {
        //��ǥ�� ���ϴ� ���� ���ϴ� ��
        Vector3 dir = targetPosition - transform.position;
    }
}
