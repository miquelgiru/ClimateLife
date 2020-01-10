using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileFactory))]
public class TileFactoryEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TileFactory factory = (TileFactory)target;
        if(GUILayout.Button("Create Tile x3"))
        {
            GameObject root = factory.CreateTile3x3().TileMapX3Parent;
            string localPath = "Assets/Prefabs/" + root.name + ".prefab";

            bool error = false;
            PrefabUtility.SaveAsPrefabAsset(root, localPath, out error);

            if (error)
                Debug.LogError("Could not save as prefab");
            else
                Debug.LogError("Tile x3 saved as prefab succesfully");

        }
    }
}
