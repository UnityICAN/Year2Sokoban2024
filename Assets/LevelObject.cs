using UnityEngine;

[CreateAssetMenu]
public class LevelObject : ScriptableObject {
    [TextArea(minLines: 10, maxLines: 10)] public string content;
}