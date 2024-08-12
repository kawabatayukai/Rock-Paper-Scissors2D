using System;
using System.Collections.Generic;
using UnityEngine;

// じゃん撃の種類とSprite管理

[CreateAssetMenu(menuName = "ScriptableObject/JangekiList")]
public class JangekiList : ScriptableObject
{
    [Serializable]
    public class Param
    {
        [SerializeField]
        Jangeki.Type type;
        [SerializeField]
        Sprite sprite;
    }

    [SerializeField]
    List<Param> jangekiList = new List<Param>();
}
