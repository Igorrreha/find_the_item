using UnityEngine;
using DG.Tweening;


public class TransformPunchPositionTransitionEffect : TransitionEffect<Transform, Vector3>
{

    protected override Vector3 ValueFrom => Vector3.zero;


    protected override Tweener GetTweener()
    {
        return _animatingComponent.DOPunchPosition(_valueTo, _duration, 7, 0.5f).SetEase(_easeType);
    }


    protected override void SetValue(Vector3 value)
    {
        _animatingComponent.localPosition = value;
    }
}
