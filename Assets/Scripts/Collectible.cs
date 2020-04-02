using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Collectible : MonoBehaviour
{
    private static float spinDuration = 3.0f;

    private bool isCollected = false;
    private Vector3 startingPosition;

    private void Awake()
    {
        startingPosition = transform.position;
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
        isCollected = true;

        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(1.6f, 0.3f).SetEase(Ease.InOutCubic));
        seq.AppendInterval(0.3f);
        seq.Append(transform.DOScale(0.0f, 0.3f).SetEase(Ease.InOutCubic).OnComplete(() => this.gameObject.SetActive(false)));

        transform.DOLocalMove(transform.position + Vector3.up * 6.0f, 0.5f).SetEase(Ease.InOutCubic);

        AudioManager.Instance.PlaySoundVaried("Pickup Can");
        StartCoroutine(PlayShakeSound());
    }

    private IEnumerator PlayShakeSound()
    {
        yield return new WaitForSeconds(0.3f);
        AudioManager.Instance.PlaySoundVaried("Shake Can");
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    public void Initialise()
    {
        if (!isCollected) { return; }

        isCollected = false;
        transform.localScale = Vector3.one;
        transform.position = startingPosition;

        PlayerScore player = GameObject.FindObjectOfType<PlayerScore>();
        if (player)
        {
            player.CollectibleReset();
        }
    }
}

