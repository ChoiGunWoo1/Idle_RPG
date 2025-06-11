using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance; //간단한 싱글톤 사용
    public static StageManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new StageManager();
            }
            return instance;
        }
    }

    [SerializeField] public GameObject[] stages = new GameObject[5]; // 5개까지 사용한 stage를 저장
    [SerializeField] private int len = 0;
    private Vector3 stageposition = new Vector3(0, 0, 60);

    void Start()
    {
        if(Instance == null)
        {
            instance = this;
        }
    }

    public void UsedStageAdd(GameObject stage)
    {
        if(len < 5) // 5개 까지는 그냥 저장
        {
            stages[len] = stage;
            len++;
            stageposition += new Vector3(0, 0, 10);
            return;
        }
        // 그 이상이 된다면 가장 먼저 저장된 것부터 적당한 위치로 옮김(배경 계속 반복 원리)
        Enemy enemy = stages[len % 5].GetComponentInChildren<Enemy>(true);
        enemy.gameObject.SetActive(true);

        enemy.Revive(); // enemy를 부활시킴 -> 여기서 idlestate로 전환

        stages[len%5].transform.position = stageposition;
        stages[len % 5] = stage;

        stageposition += new Vector3(0, 0, 10);
        len++;
    }
}
