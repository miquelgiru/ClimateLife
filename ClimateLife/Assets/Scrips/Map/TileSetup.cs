using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct TileSetupObject
{
    public string Name;
    public GameObject Tile;
    public int Level;
    public ObstacleType ObstacleType;
    public Vector3 position;
}

[CreateAssetMenu(fileName = "TileSetup", menuName = "Map/TileSetup", order = 1)]
public class TileSetup : ScriptableObject
{
    public List<TileSetupObject> TopTiles;
    public List<TileSetupObject> MidTiles;
    public List<TileSetupObject> BotTiles;

}
