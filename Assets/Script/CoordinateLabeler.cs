using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteAlways] // Runs in the editor
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    void Awake() {
        label = GetComponent<TextMeshPro>();
        TextUpdates();
    }

    void Update()
    {
        if(!Application.isPlaying) { // ONLY run the code when the game isn't running
            TextUpdates();
        }
    }

    void TextUpdates() {
        DisplayCoordinates();
        UpdateName();
    }

    void DisplayCoordinates() {
        float snapDistance = UnityEditor.EditorSnapSettings.move.x;
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / snapDistance);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / snapDistance);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateName() {
        transform.parent.name = coordinates.ToString();
    }
}
