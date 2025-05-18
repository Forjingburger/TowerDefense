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
    private Rigidbody2D rigidbody;

    float timer;

    public void Setup(Transform[] way)
    { 
        movement = GetComponent<Movement>();
        rigidbody = GetComponent<Rigidbody2D>();

        //���� ��� ����
        wayPointCount = way.Length;
        wayPoints = new Transform[wayPointCount];
        wayPoints = way;

        //���� ���� ��ġ�� ù���� ��������Ʈ ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(Move());
    }

    void SetDistance()
    {
        float distance = Vector2.Distance(wayPoints[currentIndex].position, wayPoints[currentIndex + 1].position);
        timer = distance / 1;
    }

    //�̵� �ڿ�ƾ
    private IEnumerator Move()
    {
        //������ �����Ѵ�
        SetDistance();
        SetDirection();

        while (true)
        {
            //�żӽ� �̿��ؼ� Ǯ��
            timer -= Time.deltaTime;

            Debug.Log(timer);   
            //���� ��������Ʈ�� �����Ͽ��ٸ�
            if(timer <= 0)
            {
                Debug.Log("�� �𷺼� ����");
                //�� ���� ����
                SetDistance();
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
