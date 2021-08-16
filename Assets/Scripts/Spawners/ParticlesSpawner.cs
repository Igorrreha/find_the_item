using UnityEngine;

public class ParticlesSpawner : Spawner<ParticleSystem>
{
    public void SpawnInLastTouchPosition()
    {
        Vector3 touchToWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        base.Spawn(new Vector3(touchToWorldPosition.x, touchToWorldPosition.y, 0));
    }
}
