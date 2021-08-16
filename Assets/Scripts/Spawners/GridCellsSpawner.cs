using UnityEngine;

public class GridCellsSpawner : Spawner<GridCell>
{
    [Header("Events")]
    [SerializeField] private EventsConnector _eventsConnector;


    public override GameObject Spawn()
    {
        GameObject createdObject = base.Spawn();

        GridCell gridCell = createdObject.GetComponent<GridCell>();

        _eventsConnector.Connect(gridCell.Item);
        _eventsConnector.Connect(gridCell);

        return createdObject;
    }
}
