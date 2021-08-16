// ������������ ��� ����������� ������� ���������� ������������ ��������
// ��� ����������� ������������ ������ �������� C# Event-�
// (UnityEvent-� ��� ����� �� ��������, ��� ��� �� ����� �������� �� ������ �����, ��� ��� �������� (��� ����� ������ ���������������))

using UnityEngine;


public class EventsConnector : MonoBehaviour
{
    [Header("External components")]
    [SerializeField] private GameStarter _gameStarter;
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private ParticlesSpawner _particlesSpawner;


    public void Connect(Item item)
    {
        item.OnTargetPressedAction += _levelChanger.ChangeLevelToNextWithDelay;
        item.OnTargetPressedAction += _particlesSpawner.SpawnInLastTouchPosition;
    }


    public void Connect(GridCell gridCell)
    {
        _gameStarter.OnStartedAction += gridCell.EnterAnimationEffect.Play;

        // ��� ����������� �� ������� ������� ����������� ��� �������� ��������
        gridCell.OnDestroying += Disconnect;
    }


    public void Disconnect(GridCell gridCell)
    {
        _gameStarter.OnStartedAction -= gridCell.EnterAnimationEffect.Play;
    }


}
