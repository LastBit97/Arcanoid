using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigjtningBall : MonoBehaviour
{
    [SerializeField] private ParticleSystem _lightningEffect;

    private void PlayEffect(bool isLightning)
    {
        _lightningEffect.gameObject.SetActive(isLightning);
    }

    private void OnEnable()
    {
        LightningBonus.OnLightning += PlayEffect;
    }

    private void OnDisable()
    {
        LightningBonus.OnLightning -= PlayEffect;
    }
}
