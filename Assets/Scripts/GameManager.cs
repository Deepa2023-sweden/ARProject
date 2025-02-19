using UnityEngine;
using System;




public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    public GameObject selectedModel;    // Store the selected prefab

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

