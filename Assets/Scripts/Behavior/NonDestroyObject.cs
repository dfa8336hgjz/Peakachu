using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDestroyObject : MonoBehaviour
{
    public static NonDestroyObject Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        Destroy(gameObject);
    }
}

