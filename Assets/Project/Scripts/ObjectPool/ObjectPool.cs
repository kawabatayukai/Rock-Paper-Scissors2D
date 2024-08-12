using System.Collections.Generic;
using UnityEngine;


// positionをはじめとするパラメータはObjectPoolインスタンスの所有者が行う
// activeSelf == true　にして返すだけ



//オブジェクトのリセット: GetObject メソッドでオブジェクトを取得した際、オブジェクトの状態をリセットするロジックがあれば追加します。これにより、再利用されたオブジェクトが前回の状態を引き継がないようにすることができます。

//オブジェクトの戻し: プールに戻すためのメソッド（例えば ReturnObject）を追加すると、再利用可能なオブジェクトを管理しやすくなります。このメソッドでは、オブジェクトを SetActive(false) にして非表示にし、プールに戻す処理を行います。

//非同期の生成: オブジェクトの生成が重たい処理の場合、非同期に生成する方法を検討することもできます。これは、例えば多くのオブジェクトを一度に生成する場合に有用

public class ObjectPool<T> where T : MonoBehaviour
{
    T prefab;
    List<T> pool;
    bool enableAutoAdd = true;

    public bool EnableAutoAdd { get { return enableAutoAdd; } set { enableAutoAdd = value; } }
    public int currentMaxCount { get { return pool.Count; } }

    public ObjectPool(T prefab)
    {
        if (!prefab)
        {
            throw new System.ArgumentNullException("prefab is null!");
        }
        this.prefab = prefab;
    }
    public ObjectPool(T prefab, int maxCount)
    {
        if (!prefab)
        {
            throw new System.ArgumentNullException("prefab is null!");
        }
        this.prefab = prefab;
        CreatePool(maxCount);
    }
    public ObjectPool(T prefab, List<T> pool)
    {
        if (!prefab)
        {
            throw new System.ArgumentNullException("prefab is null!");
        }
        this.prefab = prefab;
        this.pool = pool ?? new List<T>();
    }
    
    public void CreatePool(int maxCount)
    {
        pool = new List<T>();
        for (int i = 0; i < maxCount; i++) 
        {
            T obj = GameObject.Instantiate(prefab);
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }
    public void DestructionPool()
    {
        if(pool == null) { return; }
        pool.Clear();
    }

    public T GetObject()
    {
        if (pool == null) { return null; }

        foreach (T obj in pool) 
        {
            if (obj.gameObject.activeSelf) continue;
            obj.gameObject.SetActive(true);
            return obj;
        }

        // ない場合は追加
        if (!enableAutoAdd) { return null; }
        T newObj = GameObject.Instantiate(prefab);

        if(newObj is null)
        {
            throw new System.Exception("ObjectPool: Failed to create new prefab object!" + "Current pooling count is " + currentMaxCount.ToString());
        }

        pool.Add(newObj);
        return newObj;
    }
    public void RemoveObject(T obj)
    {
        if (pool == null) { return; }
        pool.Remove(obj);
    }
}
