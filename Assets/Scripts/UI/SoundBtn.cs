using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBtn : MonoBehaviour
{
    public Sprite muteSprite;
    public Sprite unmuteSprite;
    private Image thisBtn;

    void Start()
    {
        thisBtn = GetComponent<Image>();
        updateSprite();
    }

    public void updateSprite()
    {
        if (AudioController.Instance.IsMute())
        {
            thisBtn.sprite = muteSprite;
        }
        else
        {
            thisBtn.sprite = unmuteSprite;
        }
    }
}
