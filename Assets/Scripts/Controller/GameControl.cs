using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject LoseScene;
    [SerializeField] private GameObject PauseScene;
    [SerializeField] private AudioClip audioClip;
    public static GameControl instance;
    private int MAX_SKILL_POINT = 25;
    private float skillPoint = 0;
    private float totalPoint = 0f;
    public float gameSpeed = 1;
    public float spdIncreaseAmount = 0;
    private float accelerationFactor = 0.001f; // Acceleration factor (k)
    private float exponent = 2.0f; // Exponent (n)
    private float maxSpeed = 50.0f; // Maximum speed limit
    private float upSpeedTime = 1.0f;
    private bool isPause = false;
    private bool isUsingSkill = false;
    private bool isPlayingSound = false;

    private void Awake()
    {
        instance = this;
        InvokeRepeating("upSpeed", 1f, 1f);
    }

    private void Update()
    {
        if (!isPause)
        {
            totalPoint += Time.deltaTime * gameSpeed;
            if(!isUsingSkill) increasePoint(Time.deltaTime * gameSpeed, false);
        }
    }

    private void upSpeed()
    {
        spdIncreaseAmount = gameSpeed * Mathf.Pow(1 + accelerationFactor * upSpeedTime, exponent) - gameSpeed;
        Debug.Log(spdIncreaseAmount);
        upSpeedTime++;
    }

    public void increasePoint(float additional, bool addBoth = true)
    {
        if (!isUsingSkill)
        {
            skillPoint += additional;
            if(addBoth) totalPoint += additional;
            if(skillPoint > MAX_SKILL_POINT && !PlayerInput.instance.checkJumping())
            {
                StartCoroutine(triggerSkill());
            }

        }
    }

    private IEnumerator triggerSkill()
    {
        float randomWaitTime1 = Random.Range(1f, 3f);
        if (!isPlayingSound)
        {
            isPlayingSound = true;
            AudioController.Instance.PlaySoundEffect(audioClip);
        }
        yield return new WaitForSeconds(randomWaitTime1);
        isUsingSkill = true;
        PlayerInput.instance.setSkillActivate(true);
        gameSpeed = spdIncreaseAmount + 5;
        yield return new WaitForSeconds(6f);
        gameSpeed = spdIncreaseAmount + 1;
        skillPoint = 0;
        isPlayingSound = false;
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
