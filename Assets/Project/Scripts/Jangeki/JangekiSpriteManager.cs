using System;
using UnityEngine;

// じゃん撃のSpriteを管理
// 高速化とメモリ効率を考慮して、Dictionaryやforeachを使わず、シンプルにswitchで

// TODO: Effectなどを追加する場合、ScriptableObjectの使用を検討

[Serializable]
public class JangekiSpriteManager 
{
    [SerializeField] Sprite none;
    [SerializeField] Sprite rock;
    [SerializeField] Sprite scissors;
    [SerializeField] Sprite paper;

    public Sprite Get(Jangeki.Type type)
    {
        switch(type)
        {
            case Jangeki.Type.None:
                return none;

            case Jangeki.Type.Rock:
                return rock;

            case Jangeki.Type.Scissors:
                return scissors;

            case Jangeki.Type.Paper:
                return paper;
        }
        return none;
    }
}
