using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 moveDirection;

    //프로퍼티 : 정보의 은닉성 = 변수는 비공개한다.
    //만약 변수를 외부에 공개해야 한다면 [SerializeField], 프로퍼티, 함수 등으로 공개해야 한다.
    public float MoveSpeed { get { return moveSpeed; } } //get : 값을 가져가기만 한다. = getter
    //public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } } : 값도 수정 가능하다. = setter
    
    //함수로 사용하는 setter
    //public void SetDirection(Vector3 direction)
    //{
    //    moveDirection = direction;
    //}

    public Vector3 MoveDirection { set { moveDirection = value; } }

    void Update()
    {
        transform.position += moveDirection * Time.deltaTime * moveSpeed;
    }
}
