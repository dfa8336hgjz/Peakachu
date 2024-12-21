using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialFlowController : MonoBehaviour
{
    [SerializeField] private GameObject[] slides;
    private int currentSlide = 0;

    public void nextSlide()
    {
        if(currentSlide < slides.Length-1)
            currentSlide += 1;
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == currentSlide);
        }
    }

    public void prevSlide()
    {
        if(currentSlide > 0)
        {
            currentSlide -= 1;
        }
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == currentSlide);
        }
    }
}
