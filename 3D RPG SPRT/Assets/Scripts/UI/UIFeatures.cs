using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// UI의 버튼 기능들을 모아둔 곳 -> 상점은 미구현...
public class UIFeatures : MonoBehaviour
{
    [SerializeField] List<Enemy> enemyList;
    private Player player;
    public GameObject StartButton;
    public GameObject StorageButton;
    public GameObject Stage1Btn;
    public GameObject Stage2Btn;
    public GameObject Stage3Btn;
    public GameObject SettingBtn;
    public TextMeshProUGUI StageTxt;
    private int stagenum = 1;
    void Start()
    {
        Time.timeScale = 0f;
        enemyList = new List<Enemy>(FindObjectsOfType<Enemy>(true));
        player = FindObjectOfType<Player>();
        SettingBtn.SetActive(false);
        StageTxt.text = "";
    }

    public void Stage1()
    {
        foreach(Enemy enemy in enemyList)
        {
            enemy.Data.HealthData.BaseHealth = 20;
            enemy.Data.GoldData.BaseGold = 5;
            enemy.Health = enemy.Data.HealthData.BaseHealth;
        }
        stagenum = 1;
    }

    public void Stage2()
    {
        foreach (Enemy enemy in enemyList)
        {
            enemy.Data.HealthData.BaseHealth = 40;
            enemy.Data.GoldData.BaseGold = 10;
            enemy.Health = enemy.Data.HealthData.BaseHealth;
        }
        stagenum = 2;
    }

    public void Stage3()
    {
        foreach (Enemy enemy in enemyList)
        {
            enemy.Data.HealthData.BaseHealth = 100;
            enemy.Data.GoldData.BaseGold = 20;
            enemy.Health = enemy.Data.HealthData.BaseHealth;
        }
        stagenum = 3;
    }

    public void GameStart()
    {
        Time.timeScale = 1.0f;
        StartButton.SetActive(false);
        StorageButton.SetActive(false);
        Stage1Btn.SetActive(false);
        Stage2Btn.SetActive(false);
        Stage3Btn.SetActive(false);
        SettingBtn.SetActive(true);
        StageTxt.text = $"Stage {stagenum}";
    }

    public void SettingOpen()
    {
        Time.timeScale = 0f;
        StartButton.SetActive(true);
        StorageButton.SetActive(true);
        Stage1Btn.SetActive(true);
        Stage2Btn.SetActive(true);
        Stage3Btn.SetActive(true);
        SettingBtn.SetActive(false);
        StageTxt.text = "";
    }

}
