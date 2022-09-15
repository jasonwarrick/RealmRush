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
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f); // Orange

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    GridManager gridManager;

    void Awake() {
        label = GetComponent<TextMeshPro>();
        gridManager = GetComponent<GridManager>();
        label.enabled = true;

        UpdateText();
    }

    void Update() {
        if(!Application.isPlaying) { // ONLY run the code when the game isn't running
            UpdateText();
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
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        if (!node.isWalkable) {
            label.color = blockedColor;
        } else if (node.isPath) {
            label.color = pathColor;
        } else if (node.isExplored) {
            label.color = exploredColor;
        } else {
            label.color = defaultColor;
        }
    }

    void UpdateText() {
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
