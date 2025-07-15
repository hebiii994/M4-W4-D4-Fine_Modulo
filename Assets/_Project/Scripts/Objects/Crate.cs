using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    

    public void DestroyCrate()
    {
        GameManager.Instance.CrateDestroyed();
        //animazione distruzione o altro
        gameObject.SetActive(false);
    }
}
