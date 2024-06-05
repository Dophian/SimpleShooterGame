using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Fade In/Out�� ó���ϴ� ��Ʈ��Ʈ.
[RequireComponent(typeof(Image))]
public class Fade : MonoBehaviour
{
    // �ʵ�.
    // �̺�Ʈ - ���̵� �ִϸ��̼��� ��� ����Ǹ� ������ �̺�Ʈ.
    public UnityEvent OnAnimationEnd;

    // ���̵� �ִϸ��̼� �ð� (����: ��).
    [SerializeField] private float animationTime = 2f;

    // �������ӿ� ���ϱ�(�Ǵ� ����)�� �� ����.
    private float animationDifference = 0f;

    // ���� �� ������ ����� �� (RGB-A) - float/float/float/float.
    private float alpha = 0f;

    // UI �̹��� ������Ʈ ���� ����.
    private Image image;

    private void Awake()
    {
        // �ʱ�ȭ.
        image = GetComponent<Image>();


        // ������ �� Alpha �� ����.
        alpha = image.color.a;

        // �� �����ӿ� ������ ���� ���.
        animationDifference = 1f / animationTime;

        // Fade �ִϸ��̼� ���.
        StartCoroutine(PlayFade());
    }

    // Update���� ó��.
    //private void Update()
    //{
    //    if (alpha > 0f)
    //    {
    //        // �ð��� ���� ���� �� ����.
    //        alpha -= (1.0f / animationTime) * Time.deltaTime;

    //        // Image ������Ʈ���� Color �Ӽ� ���� ��������.
    //        Color color = image.color;

    //        //image.color.a = alpha;

    //        // ������ ������ Alpha ���� ����.
    //        color.a = alpha;

    //        // ������ ���� ���� Image ������Ʈ�� �ٽ� ����.
    //        image.color = color;
    //    }
    //}

    // �ڷ�ƾ���� ó��.
    IEnumerator PlayFade()
    {
        while (alpha >= 0f)
        {
            // �������� ���� ���.
            yield return null;

            // ���� ���� (Linear).
            alpha -= animationDifference * Time.deltaTime;

            float sinAlpha = Mathf.Sin(alpha);
            Debug.Log($"sinAlpha: { sinAlpha}");

            Color color = image.color;
            color.a = sinAlpha;
            image.color = color;
        }

        // �ִϸ��̼� ���� �̺�Ʈ ����.
        OnAnimationEnd?.Invoke();
    }
}
