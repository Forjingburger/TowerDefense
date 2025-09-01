using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//슬라이더는 ui, 에너미는 게임 오브젝트이다.
//유니티 엔진의 공간 특징 : 게임오브젝트는 월드 스페이스, ui는 스크린 스페이스에 존재

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

        // 여기에 구현
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(targetTransform.position);
        rectTransform.position = screenPoint + offset;

        //if(slider.value <= 0)
        //{
        //    Destroy(gameObject);
        //}
    }
}
