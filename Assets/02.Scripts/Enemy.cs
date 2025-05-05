using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� �ذ��� ���� �ڵ� : �˰���

public class Enemy : MonoBehaviour
{
    private int wayPointCount; //��������Ʈ�� ����
    private Transform[] wayPoints; //��������Ʈ�� �����ϴ� �迭
    private int currentIndex; //���� ��������Ʈ�� �ε���
    private Movement movement; //������ �����ؾ� �ϱ� ������

    public void Setup(Transform[] way)
    {
        Debug.Log("�¾� ȣ��");

        movement = GetComponent<Movement>();

        //���� ��� ����
        wayPointCount = way.Length;
        wayPoints = new Transform[wayPointCount];
        wayPoints = way;

        //���� ���� ��ġ�� ù���� ��������Ʈ ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(Move());
    }

    //�̵� �ڿ�ƾ
    private IEnumerator Move()
    {
        //������ �����Ѵ�
        SetDirection();

        while (true)
        {
            //���� ��������Ʈ�� �����Ͽ��ٸ�
            if(transform.position == wayPoints[currentIndex].position)
            {
                //�� ���� ����
                SetDirection();
            }
            yield return null;
        }
    }

    //���� ����
    private void SetDirection()
    {
        //���� �̵��� �� �ִ� ��������Ʈ�� �����ִٸ�
        if(currentIndex < wayPointCount - 1)
        {
            currentIndex++;
            //���� ���� ����Ʈ�� ���ϴ� ���� ���ؼ�
            //��ǥ������ ���ϴ� ���� : ��ǥ���� - ������ġ
            Vector2 direction = (wayPoints[currentIndex].position - transform.position).normalized;

            //�����Ʈ�� ���� ����
            movement.MoveDirection = direction;
        }
        else //���� �����Ѵٸ�
        {
            Destroy(gameObject);
        }
    }
    //���ʹ� ����� ũ�⸦ ��� ������ �ִ�
    //������ ����ȭ : ũ�Ⱑ 1�� ���ͷ� ���� ���⸸�� ����Ű���� �Ѵ�.
}
