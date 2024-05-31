using System;
using UnityEngine;

// 적 캐릭터 그룹을 지정한 시간 간격마다 생성하는 적 스포터 스크립트.
public class EnemySpawner : MonoBehaviour
{
    // 적 캐릭터 스폰(실행 중에 생성) 정보.
    [Serializable]
    public class EnemySpawnInfo
    {
        // 생성할 적 캐릭터 그룹 프리팹.
        [SerializeField] private GameObject prefab;

        // 생성하기까지 대기할 생성 시간(단위: 초).
        [SerializeField] private float spawnTime;

        // Getter.
        public GameObject Prefab { get { return prefab; } }
        public float SpwanTime { get { return spawnTime; } }
    }

    // 적 캐릭터 스폰 정보 배열 선언.
    [SerializeField] private EnemySpawnInfo[] spawnInfo;

    // 적 생성 시 사용할 배열 인덱스.
    private int currentIndex = 0;

    private void Awake()
    {
        Invoke("Spawn", spawnInfo[currentIndex].SpwanTime);
    }

    // 실제로 적 그룹을 생성하는 함수.
    private void Spawn()
    {
        // 프리팹을 씬에 생성.
        Instantiate(spawnInfo[currentIndex].Prefab, transform.position, Quaternion.identity);

        // 배열 인덱스 업데이트.
        currentIndex = (currentIndex + 1) % spawnInfo.Length;

        // 다음 Spawn 함수 호출 대기.
        Invoke("Spawn", spawnInfo[currentIndex].SpwanTime);
    }
}