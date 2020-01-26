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
            string stationFolder;
            GameObject root = factory.CreateTileX3(out stationFolder);
            string localPath = "Assets/Prefabs/Map/" + stationFolder + "TilesX3/" + root.name + "_" + root.GetInstanceID() + ".prefab";

            bool succes = false;
            PrefabUtility.SaveAsPrefabAsset(root, localPath, out succes);

            if (!succes)
                Debug.LogError("Could not save as prefab");
            else
                Debug.Log("Tile x3 saved as prefab succesfully");

            DestroyImmediate(root);

        }

        if (GUILayout.Button("Create Tile x12"))
        {
            string stationFolder;

            GameObject[] tiles = factory.CreateTileX12Group(out stationFolder);

            foreach (GameObject t in tiles)
            {
                GameObject root = t;
                string localPath = "Assets/Prefabs/Map/" + stationFolder + "TilesX12/" + root.name + root.GetInstanceID() + ".prefab";

                bool succes = false;
                PrefabUtility.SaveAsPrefabAsset(root, localPath, out succes);

                if (!succes)
                    Debug.LogError("Could not save as prefab");
                else
                {
                    Debug.Log("Tile x12 saved as prefab succesfully");
                }

                DestroyImmediate(root);
            }
        }
    }
}
