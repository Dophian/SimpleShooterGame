using UnityEngine;
using UnityEngine.Events;

// 플레이어의 발사를 제어하는 스크립트.
public class PlayerShoot : MonoBehaviour
{
    // 탄약 발사 - 게임 로직.
    // 자동으로 발사되도록 기능을 구현.
    // 탄약이 발사되는 간격.
    [SerializeField] private float shootInterval = 0.2f;
    
    // 플레이어 탄약 프리팹.
    [SerializeField] private GameObject bulletPrefab;

    // 탄약 발사 위치 트랜스폼.
    [SerializeField] private Transform fireposition;

    // 탄약을 발사할 때 발생시킬 이벤트 (타입: 유니티 이벤트).
    public UnityEvent OnShoot;

    // 초 계산 변수 (누적 시간 계산).
    private float elapsedTime = 0f;

    private void Awake()
    {
        
        // 자동으로 반복 실행되도록 예약.
        //InvokeRepeating("Shoot", 0f, shootInterval);

        //CancelInvoke("Shooot");
    }

    private void Update()
    {
        // 타이머 업데이트.
        elapsedTime += Time.deltaTime;

        // 타이머가 발사 간격 시간만큼 지났으면,
        if (elapsedTime > shootInterval)
        {
            // 발사하고,
            Shoot();

            // 타이머 초기화.
            elapsedTime = 0f;
        }
    }

    // 발사 함수.
    private void Shoot()
    {
        // 탄약 발사 이벤트 발행.
        OnShoot?.Invoke();

        //
        //
        //
        //

        // 탄약 발사.
        if (bulletPrefab != null)
        {
            Instantiate(bulletPrefab, fireposition.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("<color=red> bulletPrefab 변수가 설정되지 않았습니다. </color>");
        }
    }
}