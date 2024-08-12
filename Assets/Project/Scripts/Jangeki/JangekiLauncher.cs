using UnityEngine;

// プールもっちゃえ
// パラメータ設定もやっちゃえ

public class JangekiLauncher : MonoBehaviour
{
    [SerializeField] JangekiSpriteManager spriteManager;
    [SerializeField] JangekiPool jangekiPool;
    [SerializeField] Transform launchPosition;


    private void Start()
    {
        jangekiPool.Create();
    }

    public Jangeki Launch(Jangeki.Type type)
    {
        Jangeki jangeki = jangekiPool.Get();
        jangeki.SetSprite(spriteManager.Get(type));
        jangeki.gameObject.transform.position = launchPosition.position;
        return jangeki;
    }
}
