using DG.Tweening;
using SO;
using SO.Events;
using UnityEngine;

public class Gem : MonoBehaviour
{
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

        transform.DOMove(target.position, randomDuration).OnComplete(() => {
            gemsNumber.Value++;
            Destroy(gameObject);
        });
    }
}
