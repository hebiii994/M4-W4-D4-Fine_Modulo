using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int maxShields = 3;
    public int CurrentShields { get; private set; }
    private bool isAlive = true;

    public UnityEvent<int> OnShieldsChanged;

    void Start()
    {
        CurrentShields = 0;
        OnShieldsChanged?.Invoke(CurrentShields);
    }

    public void TakeDamage()
    {
        if (!isAlive) return;
        if (CurrentShields > 0)
        {
            CurrentShields--;
            OnShieldsChanged?.Invoke(CurrentShields);
            Debug.Log($"Sei stato colpito, Scudi rimasti: {CurrentShields}");
        }
        else
        {
            Die();
        }
    }
    public void AddShield()
    {
        if (!isAlive) return;
        if (CurrentShields < maxShields)
        {
            CurrentShields++;
            OnShieldsChanged?.Invoke(CurrentShields);
            Debug.Log($"Boody GA o qualsiasi altra cosa dicesse UKA UKA, Scudi totali: {CurrentShields}");
            // se ho tempo cerco il suono di UKA UKA xD
        }
        else
        {
            //vedremo se farlo o meno più avanti

            Debug.Log("invincibilità?");
        }
    }

    private void Die()
    {
        isAlive = false;
        Debug.LogError("Sei morto!");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraController>().enabled = false;
        //logica di game Over da implementare
    }
}
