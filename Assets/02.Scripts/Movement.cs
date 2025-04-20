using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 moveDirection;

    //������Ƽ : ������ ���м� = ������ ������Ѵ�.
    //���� ������ �ܺο� �����ؾ� �Ѵٸ� [SerializeField], ������Ƽ, �Լ� ������ �����ؾ� �Ѵ�.
    public float MoveSpeed { get { return moveSpeed; } } //get : ���� �������⸸ �Ѵ�. = getter
    //public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } } : ���� ���� �����ϴ�. = setter
    
    //�Լ��� ����ϴ� setter
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
