using System;
using UnityEngine;

[Serializable]
public class JangekiPool
{
    [SerializeField] Jangeki jangekiBasePrefab;
    [SerializeField] int initializeMaxCount = 10;

    ObjectPool<Jangeki> pool;


    public JangekiPool()
    {
    }

    public void Create()
    {
        pool = new ObjectPool<Jangeki>(jangekiBasePrefab, initializeMaxCount);
        Debug.Log("<color=#90ee90>" + GetType().ToString() + ": Create pool is sucess." + "</color>");
    }

    public Jangeki Get()
    {
        try
        {
            return pool.GetObject();
        }
        catch(System.Exception e)
        {
            Debug.LogError(e.Message);
        }
        return null;
    }
}
