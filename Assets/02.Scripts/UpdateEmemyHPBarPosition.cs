using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����̴��� ui, ���ʹ̴� ���� ������Ʈ�̴�.
//����Ƽ ������ ���� Ư¡ : ���ӿ�����Ʈ�� ���� �����̽�, ui�� ��ũ�� �����̽��� ����

public class UpdateEmemyHPBarPosition : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 2, 0);
    private Transform targetTransform;
    private RectTransform rectTransform;
    //private Slider slider;

    public void Setup(Transform target)
    {
        targetTransform = target;
        rectTransform = GetComponent<RectTransform>();
        //slider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        // ���⿡ ����
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint + offset;

        //if(slider.value <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }
}
