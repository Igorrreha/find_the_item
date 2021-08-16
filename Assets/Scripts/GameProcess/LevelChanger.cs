using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private LevelData[] _levels;
    private int _currentLevelIndex = -1;

    [Header("Events")]
    [SerializeField] private UnityEvent<LevelData> OnLevelChanging;
    [SerializeField] private UnityEvent OnLastLevelEnded;

    // �������� ��� �������� �� ��������� �������, ����� ����� ����� ������ ��� ������ �� ���������
    // � ����������������� �������� ������� �������� ������������� �� ����
    [SerializeField] [Min(0)] private float _levelChangeDelay = 1f;

    private bool _isLevelChangingStarted = false;


    public void Initialize()
    {
        _currentLevelIndex = -1;
    }


    public void ChangeLevelToNext()
    {
        _currentLevelIndex++;

        if (_currentLevelIndex < _levels.Length)
        {
            OnLevelChanging?.Invoke(_levels[_currentLevelIndex]);
        }
        else
        {
            OnLastLevelEnded?.Invoke();
        }
    }


    public void ChangeLevelToNextWithDelay()
    {
        if (!_isLevelChangingStarted)
            _isLevelChangingStarted = true;
            StartCoroutine(nameof(ChangeLevelToNextWithDelayCoroutine));
    }


    IEnumerator ChangeLevelToNextWithDelayCoroutine()
    {
        yield return new WaitForSeconds(_levelChangeDelay);

        ChangeLevelToNext();

        _isLevelChangingStarted = false;
    }
}
