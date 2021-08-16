using UnityEngine;
using DG.Tweening;


abstract public class TransformScaleTransitionEffect : TransitionEffect<Transform, Vector3>
{
    protected override Tweener GetTweener()
    {
        return _animatingComponent.DOScale(_valueTo, _duration).SetEase(_easeType);
    }


    protected override void SetValue(Vector3 value)
    {
        _animatingComponent.localScale = value;
    }
}
