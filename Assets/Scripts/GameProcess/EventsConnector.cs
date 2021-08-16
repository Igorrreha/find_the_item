// Используется для подключения событий процедурно генерируемых объектов
// Для подключения используются только нативные C# Event-ы
// (UnityEvent-ы для этого не подходят, так как их можно вызывать из любого места, где они доступны (они менее строго инкапсулированы))

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

        // все подключения ко внешним службам отключаются при удалении объектов
        gridCell.OnDestroying += Disconnect;
    }


    public void Disconnect(GridCell gridCell)
    {
        _gameStarter.OnStartedAction -= gridCell.EnterAnimationEffect.Play;
    }


}
