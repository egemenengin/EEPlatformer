// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int coinValue = 5;
    [SerializeField] AudioClip coinPickUpSoundSFX;

    public int getCoinValue()
    {
        return coinValue;
    }
    public void setCoinValue(int val)
    {
        coinValue = val;
    }
    public void pickedUp()
    {
        AudioSource.PlayClipAtPoint(coinPickUpSoundSFX, Camera.main.transform.position);
    }
}
