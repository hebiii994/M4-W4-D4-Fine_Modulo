using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _keysToCompleteLevel = 1;
    public static GameManager Instance { get; private set; }
    
    public int CollectedKeys { get; private set; }

    public UnityEvent<int, int> OnKeysChanged;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        OnKeysChanged?.Invoke(CollectedKeys, _keysToCompleteLevel);
    }
    
    public void CollectKey()
    {
        CollectedKeys++;
        Debug.Log($"Chiave raccolta! Totale: {CollectedKeys}/{_keysToCompleteLevel}");
        OnKeysChanged?.Invoke(CollectedKeys, _keysToCompleteLevel);
        if (CollectedKeys >= _keysToCompleteLevel)
        {
            Debug.Log("Tutte le chiavi raccolte!");
        }
    }
}
