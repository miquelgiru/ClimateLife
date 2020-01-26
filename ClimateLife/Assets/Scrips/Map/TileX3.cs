using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TileMapX3
{
    public TileSetupObject top, mid, bot;
    public GameObject TileMapX3Parent;
    public int level;

    public TileMapX3(GameObject parent, TileSetupObject _top, TileSetupObject _mid, TileSetupObject _bot, int _level)
    {
        top = _top;
        mid = _mid;
        bot = _bot;
        TileMapX3Parent = parent;
        level = _level;

        top.Tile = GameObject.Instantiate(top.Tile, TileMapX3Parent.transform);
        mid.Tile = GameObject.Instantiate(mid.Tile, TileMapX3Parent.transform);
        bot.Tile = GameObject.Instantiate(bot.Tile, TileMapX3Parent.transform);


        RelocateTiles();
    }

    public void RelocateTiles()
    {
        top.Tile.transform.localPosition = new Vector3(1, 0, 0);
        mid.Tile.transform.localPosition = new Vector3(0, 0, 0);
        bot.Tile.transform.localPosition = new Vector3(-1, 0, 0);

    }
}

public class TileX3 : MonoBehaviour
{
    public ClimateStation station;
    public int DificultyLevel = 0;
    public TileMapX3 TileMap;


    public TileX3(ClimateStation st, int level, TileMapX3 tile)
    {
        station = st;
        DificultyLevel = level;
        TileMap = tile;
    }

    public void RelocateTiles()
    {
        transform.GetChild(0).localPosition = new Vector3(1, 0, 0);
        transform.GetChild(1).localPosition = new Vector3(0, 0, 0);
        transform.GetChild(2).localPosition = new Vector3(-1, 0, 0);
    }
}
