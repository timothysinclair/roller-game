using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Collectible : MonoBehaviour
{
    private static float spinDuration = 3.0f;

    private bool isCollected = false;

    private void Awake()
    {
        // Spin
        transform.DOLocalRotate(new Vector3(0.0f, 360.0f, 0.0f), spinDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected) { return; }

        PlayerScore playerScore = other.gameObject.GetComponent<PlayerScore>();

        if (playerScore)
        {
            playerScore.CollectCollectible();
            OnCollected();
        }
    }

    private void OnCollected()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.6f, 0.3f).SetEase(Ease.InOutCubic));
        seq.AppendInterval(0.3f);
        seq.Append(transform.DOScale(0.0f, 0.3f).SetEase(Ease.InOutCubic).OnComplete(() => Destroy(this.gameObject)));

        transform.DOLocalMove(transform.position + Vector3.up * 6.0f, 0.5f).SetEase(Ease.InOutCubic);

    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}

