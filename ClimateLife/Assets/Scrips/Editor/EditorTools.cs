using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public static class EditorTools
{
    [MenuItem("Tools/Map/Generate Tile Types")]
    private static void GenerateTileTypes()
    {
        GameObject _base = Resources.Load<GameObject>("Prefabs/Map/Tiles/SimpleTile");
        GameObject[] _obstacles = Resources.LoadAll<GameObject>("Prefabs/Map/Obstacles");

        GenerateSimpleTiles(_base, _obstacles);
    }

    private static void GenerateSimpleTiles(GameObject baseTile, GameObject[] obstacles)
    {
        foreach(GameObject obs in obstacles)
        {
            int count = 0;
            foreach(Transform t in baseTile.transform.GetChild(0))
            {
                GameObject newTile = Object.Instantiate(baseTile);
                GameObject o = Object.Instantiate(obs);
                o.transform.SetParent(newTile.transform);
                o.transform.position = t.position + o.GetComponent<Obstacle>().Offset;

                string localPath = "Assets/Resources/Prefabs/Map/Tiles/" + newTile.name + count + ".prefab";
                localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

                PrefabUtility.SaveAsPrefabAssetAndConnect(newTile, localPath, InteractionMode.UserAction);
                ++count;

                Object.DestroyImmediate(newTile);
            }
        }
    }

    private static void GenerateComplexTiles(GameObject baseTile, GameObject[] obstacles)
    {
        foreach (GameObject obs in obstacles)
        {
            
        }
    }


    private static GameObject[] GetVericalHorizontal(GameObject baseTile, int position, ObstacleSize size, ObstacleType type)
    {
        GameObject[] neightbours = null;

        switch (size)
        {
            case ObstacleSize.SMALL:
                neightbours = new GameObject[2];
                int child1 = position - 3;
                int child2 = position - 3;

                break;
            case ObstacleSize.MEDIUM:
                neightbours = new GameObject[1];
                break;
            case ObstacleSize.LARGE:
                return null;
                break;
        }

        return neightbours;
    }
}
