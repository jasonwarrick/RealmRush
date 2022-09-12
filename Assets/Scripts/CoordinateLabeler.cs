using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways] // Runs in the editor
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoint waypoint;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        waypoint = GetComponentInParent<Waypoint>();
        TextUpdates();
        label.enabled = false;
    }

    void Update() {
        if(!Application.isPlaying) { // ONLY run the code when the game isn't running
            TextUpdates();
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels() {
        if (Input.GetKeyDown(KeyCode.C)) {
            label.enabled = !label.IsActive();
        }
    }

    void SetLabelColor() {
        if (waypoint.IsPlacable) {
            label.color = defaultColor;
        } else {
            label.color = blockedColor;
        }
    }

    void TextUpdates() {
        DisplayCoordinates();
        UpdateName();
    }

    void DisplayCoordinates() {
        float snapDistance = UnityEditor.EditorSnapSettings.move.x; // Using editor settings in code creates errors in the build, put this script in the editor folder before building
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / snapDistance);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / snapDistance);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateName() {
        transform.parent.name = coordinates.ToString();
    }
}
