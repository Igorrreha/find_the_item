using UnityEngine;

abstract public class Spawner<T> : MonoBehaviour where T: class, new()
{
    [Header("External components")]
    [SerializeField] protected GameObject _objectTemplate;
    [SerializeField] protected Transform _parent;


    private void Start()
    {
        if (_objectTemplate == null)
        {
            throw new UnassignedReferenceException();
        }
        else if (_objectTemplate.GetComponent<T>() == null)
        {
            throw new MissingReferenceException();
        }
    }


    public virtual GameObject Spawn()
    {
        if (_parent == null)
        {
            throw new UnassignedReferenceException();
        }

        return Instantiate(_objectTemplate, _parent);
    }


    public virtual GameObject Spawn(Vector3 position)
    {
        GameObject gameObject = Spawn();
        gameObject.transform.position = position;

        return gameObject;
    }
}
