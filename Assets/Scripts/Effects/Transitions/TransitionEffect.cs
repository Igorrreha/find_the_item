using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;

abstract public class TransitionEffect<T, U> : Effect where T : class
{
    [Header("External components")]
    [SerializeField] protected T _animatingComponent;

    [Header("Properties")]
    [SerializeField] protected float _duration = 1f;
    [SerializeField] protected U _valueTo;

    [SerializeField] protected Ease _easeType = Ease.Linear;
    protected Tweener _tweener;

    [Header("Events")]
    [SerializeField] protected UnityEvent OnPlayEnded;


    protected abstract U ValueFrom { get; }


    protected abstract void SetValue(U value);


    protected abstract Tweener GetTweener();


    public sealed override void Play()
    {
        if (_tweener.IsActive())
            BreakPlaying();

        StartCoroutine(nameof(Playing));
    }


    protected IEnumerator Playing()
    {
        SetValue(ValueFrom);

        _tweener = GetTweener();
        yield return _tweener.WaitForCompletion();

        OnPlayEnded?.Invoke();
    }


    protected void BreakPlaying()
    {
        StopCoroutine(nameof(Playing));
        _tweener.Kill(true);
    }


    private void OnDestroy()
    {
        if (_tweener.IsActive())
            BreakPlaying();
    }

}
