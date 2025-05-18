using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//문제 해결을 위한 코드 : 알고리즘

public class Enemy : MonoBehaviour
{
    private int wayPointCount; //웨이포인트의 개수
    private Transform[] wayPoints; //웨이포인트를 관리하는 배열
    private int currentIndex; //현재 웨이포인트의 인덱스
    private Movement movement; //방향을 지정해야 하기 떄문에
    private Rigidbody2D rigidbody;

    float timer;

    public void Setup(Transform[] way)
    {
        movement = GetComponent<Movement>();
        rigidbody = GetComponent<Rigidbody2D>();

        //적의 경로 설정
        wayPointCount = way.Length;
        wayPoints = new Transform[wayPointCount];
        wayPoints = way;

        //적의 최초 위치를 첫번쨰 웨이포인트 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        StartCoroutine(Move());
    }

    //이동 코우틴
    private IEnumerator Move()
    {
        //방향을 설정한다.
        SetDirection();

        while (true)
        {
            //거속시 이용해서 풀기
            timer -= Time.deltaTime;
            
            //다음 웨이포인트에 도착하였다면
            if(timer <= 0)
            {
                //Debug.Log("새 디렉션 설정");
                //새 방향 설정
                SetDirection();
            }
            yield return null;
        }
    }

    //방향 설정
    private void SetDirection()
    {
        //아직 이동할 수 있는 웨이포인트가 남아있다면
        if (currentIndex < wayPointCount - 1)
        {
            float distance = Vector2.Distance(transform.position, wayPoints[currentIndex + 1].position);
            timer = distance / movement.MoveSpeed;

            //다음 웨이 포인트로 향하는 방향 구해서
            //목표지점을 향하는 벡터 : 목표지점 - 현재위치
            Vector2 direction = (wayPoints[currentIndex + 1].position - transform.position).normalized;

            currentIndex++;
            //무브먼트에 방향 전달
            movement.MoveDirection = direction;
        }
        else //끝에 도달한다면
        {
            Destroy(gameObject);
        }
    }
    //벡터는 방향과 크기를 모두 가지고 있다
    //벡터의 정규화 : 크기가 1인 벡터로 만들어서 방향만을 가르키도록 한다.
}
