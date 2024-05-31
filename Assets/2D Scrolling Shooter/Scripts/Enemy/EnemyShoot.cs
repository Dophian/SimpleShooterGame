using UnityEngine;

// 적 우주선의 탄약 발사를 처리하는 스크립트.
public class EnemyShoot : MonoBehaviour
{
    // 필드.
    // 발사 간격 (딜레이, 단위:초).
    [SerializeField] private float shootInterval = 1.5f;

    // 탄약의 속력 (빠르기, 단위:초).
    [SerializeField] private float bulletSpeed = 3f;

    // 탄약의 발사를 제한하는 Y 높이 값.
    [SerializeField] private float shootStopYPosition = -2f;

    // 탄약 프리팹.
    [SerializeField] private GameObject bulletPrefab;

    // 플레이어의 트랜스폼을 참조하는 변수.
    private Transform refPlayer;

    // 경과 시간을 계산하는 변수.
    private float elapsedTime = 0f;

    private void Awake()
    {
        // 플레이어 게임 오브젝트를 검색한 뒤에 refPlayer에 트랜스폼 저장.
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            refPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        // 타이머 업데이트.
        elapsedTime += Time.deltaTime;

        // 반사 간격 시간 만큼 지났으면 탄약 발사.
        if (elapsedTime > shootInterval)
        {
            // 탄약 발사.
            Shoot();

            // 타이머 초기화.
            elapsedTime = 0f;
        }
    }

    // 발사 메소드.
    private void Shoot()
    {
        // 검증.
        if (refPlayer == null)
        {
            return;
        }

        if (transform.position.y < shootStopYPosition )
        {
            return;
        }

        // 플레이어의 위치를 향하는 방향 구하기
        Vector3 direction = refPlayer.position - transform.position;

        //// 플레이어가 적 캐릭터 앞에 있는지 뒤에 있는지 확인 후 앞에 있으면 발사.
        //if (Vector3.Dot(-transform.up, direction.normalized) < 0f)
        //{
        //    return;
        //}

        // 프리팹을 이용해 탄약을 생성하고,
        var newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // rigidbody2d 컴포넌트에 속도(빠르기/방향) 설정.
        float speed = Random.Range(bulletSpeed * 0.2f, bulletSpeed * 1.8f);
        newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}