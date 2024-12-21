using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject LoseScene;
    [SerializeField] private GameObject PauseScene;
    public static GameControl instance;
    private int MAX_SKILL_POINT = 20;
    private float skillPoint = 0;
    private float totalPoint = 0f;
    public float gameSpeed = 1;
    private bool isPause = false;
    private bool isUsingSkill = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (!isPause)
        {
            totalPoint += Time.deltaTime * gameSpeed;
            if(!isUsingSkill) skillPoint += Time.deltaTime * 0.4f;
        }
    }

    public void increasePoint(int additional)
    {
        if (!isUsingSkill)
        {
            skillPoint += additional;
            totalPoint += additional;
            if(skillPoint > MAX_SKILL_POINT)
            {
                StartCoroutine(triggerSkill());
            }

        }
    }

    private IEnumerator triggerSkill()
    {
        isUsingSkill = true;
        PlayerInput.instance.setSkillActivate(true);
        gameSpeed = 2;
        yield return new WaitForSeconds(8f);
        gameSpeed = 1;
        skillPoint = 0;
        PlayerInput.instance.setSkillActivate(false);
        isUsingSkill = false;
    }

    public bool isGamePaused()
    {
        return isPause;
    }

    public int getTotalPoint()
    {
        return (int)totalPoint;
    }

    public int getSkillPoint()
    {
        return (int)skillPoint;
    }

    public bool quickAttackActivated()
    {
        return isUsingSkill;
    }
    public void setPauseScene(bool active)
    {
        PauseScene.SetActive(active);
        isPause = active;
        Time.timeScale = active ? 0 : 1;
    }
    public void setLoseScene(bool active)
    {
        Time.timeScale = active ? 0 : 1;
        isPause = active;
        int currentHighScore = PlayerPrefs.GetInt("highScore");
        if (currentHighScore < (int)totalPoint)
        {
            PlayerPrefs.SetInt("highScore", (int)totalPoint);
        }

        LoseScene.SetActive(active);
    }
}
