using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount; //��������Ʈ�� ����
    private Transform[] wayPoints; //��������Ʈ�� �����ϴ� �迭
    private int currentIndex; //���� ��������Ʈ�� �ε���
    private Movement movement; //������ �����ؾ� �ϱ� ������
}
