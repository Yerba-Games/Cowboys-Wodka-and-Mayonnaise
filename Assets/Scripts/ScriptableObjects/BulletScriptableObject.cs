using UnityEngine;

[CreateAssetMenu(fileName ="BulletScriptableObject",menuName ="Bullets")]
public class BulletScriptableObject : ScriptableObject
{
    public float speed = 15f;
    [Range(1,100)] public int damage = 30;
    public bool isPlayersBullet=false;
}
