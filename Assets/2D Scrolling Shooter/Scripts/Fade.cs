using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Fade In/Out을 처리하는 스트립트.
[RequireComponent(typeof(Image))]
public class Fade : MonoBehaviour
{
    // 필드.
    // 이벤트 - 페이드 애니메이션이 모두 재생되면 발행할 이벤트.
    public UnityEvent OnAnimationEnd;

    // 페이드 애니메이션 시간 (단위: 초).
    [SerializeField] private float animationTime = 2f;

    // 한프레임에 더하기(또는 빼기)를 할 간격.
    private float animationDifference = 0f;

    // 알파 값 조정에 사용할 값 (RGB-A) - float/float/float/float.
    private float alpha = 0f;

    // UI 이미지 컴포넌트 참조 변수.
    private Image image;

    private void Awake()
    {
        // 초기화.
        image = GetComponent<Image>();


        // 시작할 때 Alpha 값 저장.
        alpha = image.color.a;

        // 한 프레임에 적용할 간격 계산.
        animationDifference = 1f / animationTime;

        // Fade 애니메이션 재생.
        StartCoroutine(PlayFade());
    }

    // Update에서 처리.
    //private void Update()
    //{
    //    if (alpha > 0f)
    //    {
    //        // 시간에 따른 알파 값 조정.
    //        alpha -= (1.0f / animationTime) * Time.deltaTime;

    //        // Image 컴포넌트에서 Color 속성 값을 가져오기.
    //        Color color = image.color;

    //        //image.color.a = alpha;

    //        // 위에서 조정한 Alpha 값을 설정.
    //        color.a = alpha;

    //        // 조정한 색상 값을 Image 컴포넌트에 다시 설정.
    //        image.color = color;
    //    }
    //}

    // 코루틴에서 처리.
    IEnumerator PlayFade()
    {
        while (alpha >= 0f)
        {
            // 한프레임 동안 대기.
            yield return null;

            // 선형 보간 (Linear).
            alpha -= animationDifference * Time.deltaTime;

            float sinAlpha = Mathf.Sin(alpha);
            Debug.Log($"sinAlpha: { sinAlpha}");

            Color color = image.color;
            color.a = sinAlpha;
            image.color = color;
        }

        // 애니메이션 종료 이벤트 발행.
        OnAnimationEnd?.Invoke();
    }
}
