using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Hover : MonoBehaviour
{
    private static float hoverAmplitude = 0.5f;
    private static float hoverDuration = 4.0f;
    private float phasor = 0.0f;

    private void Awake()
    {
        // Hover
        DOTween.To(
            () => phasor,
            v =>
            {
                phasor = v;
                transform.localPosition = new Vector3(0.0f, hoverAmplitude * Mathf.Sin(phasor * Mathf.Deg2Rad), 0.0f);
            },
            360.0f,
            hoverDuration)
            .SetEase(Ease.Linear)
            .SetLoops(-1);
    }
}
