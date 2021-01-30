using DG.Tweening;
using SO;
using SO.Events;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] AudioClip gemClip;
    [SerializeField] AudioSource audioSource;
    [SerializeField] EventSO onGemCollected;
    [SerializeField] float minTweenDuration;
    [SerializeField] float maxTweenDuration;
    VariableSO<int> gemsNumber;
    private void Awake()
    {
        gemsNumber = (VariableSO<int>)onGemCollected.Value;
    }
    public void TweenTowards(Transform target)
    {
        float randomDuration = Random.Range(minTweenDuration, maxTweenDuration);

        transform.DOMove(target.position, randomDuration).SetEase(Ease.InOutExpo).OnComplete(() => {

            PlayGemSound();
            transform.DOMove(Camera.main.WorldToScreenPoint(Vector3.zero), randomDuration).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                gemsNumber.Value++;
                PlayGemSound();

                Destroy(gameObject);
            });
        });
    }
    void PlayGemSound()
    {
        audioSource.clip = gemClip;
        audioSource.Play();
    }
}
