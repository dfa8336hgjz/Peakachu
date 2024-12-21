using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillProgressBar : MonoBehaviour
{
    [SerializeField] private Image progressBarFill;
    private void Update()
    {
        int skillpoint = GameControl.instance.getSkillPoint();
        updateProgress(skillpoint);
    }

    public void updateProgress(int point)
    {
        progressBarFill.fillAmount = point / 25f;
    }
}
