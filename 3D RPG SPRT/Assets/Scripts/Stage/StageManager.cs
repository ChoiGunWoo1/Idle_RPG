using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager instance; //������ �̱��� ���
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

    [SerializeField] public GameObject[] stages = new GameObject[5]; // 5������ ����� stage�� ����
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
        if(len < 5) // 5�� ������ �׳� ����
        {
            stages[len] = stage;
            len++;
            stageposition += new Vector3(0, 0, 10);
            return;
        }
        // �� �̻��� �ȴٸ� ���� ���� ����� �ͺ��� ������ ��ġ�� �ű�(��� ��� �ݺ� ����)
        Enemy enemy = stages[len % 5].GetComponentInChildren<Enemy>(true);
        enemy.gameObject.SetActive(true);

        enemy.Revive(); // enemy�� ��Ȱ��Ŵ -> ���⼭ idlestate�� ��ȯ

        stages[len%5].transform.position = stageposition;
        stages[len % 5] = stage;

        stageposition += new Vector3(0, 0, 10);
        len++;
    }
}
