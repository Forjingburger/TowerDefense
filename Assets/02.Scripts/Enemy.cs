using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount; //웨이포인트의 개수
    private Transform[] wayPoints; //웨이포인트를 관리하는 배열
    private int currentIndex; //현재 웨이포인트의 인덱스
    private Movement movement; //방향을 지정해야 하기 떄문에
}
