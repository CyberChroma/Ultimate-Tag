using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[ExecuteInEditMode]
[CustomEditor(typeof(PathfindingEditorTools))]
public class PathfindingEditorToolsCustomEditor : Editor
{
    private PathfindingEditorTools pathfindingEditorTools;

    // Start is called before the first frame update
    void OnEnable()
    {
        pathfindingEditorTools = FindObjectOfType<PathfindingEditorTools>();
        SceneView.duringSceneGui += this.OnSceneGUI;
    }

    void OnDisable()
    {
    }

    private void OnSceneGUI(SceneView sceneView)
    {
        if (pathfindingEditorTools != null &&pathfindingEditorTools.drawConnections) {
            pathfindingEditorTools.DrawConnections();
        }
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        if (GUILayout.Button("Make New Connection")) {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects.Length > 1) {
                PathfindingObject[] selectedPathfindingObjects = new PathfindingObject[selectedObjects.Length];
                for (int i = 0; i < selectedObjects.Length; i++) {
                    selectedPathfindingObjects[i] = selectedObjects[i].GetComponent<PathfindingObject>();
                }
                pathfindingEditorTools.MakeNewConnection(selectedPathfindingObjects);
                EditorSceneManager.MarkSceneDirty(pathfindingEditorTools.gameObject.scene);
            }
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("Make Connections")) {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects.Length > 1) {
                PathfindingObject[] selectedPathfindingObjects = new PathfindingObject[selectedObjects.Length];
                for (int i = 0; i < selectedObjects.Length; i++) {
                    selectedPathfindingObjects[i] = selectedObjects[i].GetComponent<PathfindingObject>();
                }
                pathfindingEditorTools.MakeConnections(selectedPathfindingObjects);
                EditorSceneManager.MarkSceneDirty(pathfindingEditorTools.gameObject.scene);
            }
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("Remove Connections")) {
            GameObject[] selectedObjects = Selection.gameObjects;
            if (selectedObjects.Length > 1) {
                PathfindingObject[] selectedPathfindingObjects = new PathfindingObject[selectedObjects.Length];
                for (int i = 0; i < selectedObjects.Length; i++) {
                    selectedPathfindingObjects[i] = selectedObjects[i].GetComponent<PathfindingObject>();
                }
                pathfindingEditorTools.RemoveConnections(selectedPathfindingObjects);
                EditorSceneManager.MarkSceneDirty(pathfindingEditorTools.gameObject.scene);
            }
        }
        EditorGUILayout.Space();
        if (GUILayout.Button("Clean Up Empty Connections")) {
            pathfindingEditorTools.CleanUp();
            EditorSceneManager.MarkSceneDirty(pathfindingEditorTools.gameObject.scene);
        }
    }
}
