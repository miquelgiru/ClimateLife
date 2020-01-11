using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum ClimateStation { SPRING, SUMMER, AUTUM, WINTER }

public class TileMapX3
{
    public TileSetupObject top, mid, bot;
    public GameObject TileMapX3Parent;
    public int level;

    public TileMapX3() { Debug.LogError("Undefined Tile"); }

    public TileMapX3(GameObject parent, TileSetupObject _top, TileSetupObject _mid, TileSetupObject _bot, int _level)
    {
        top = _top;
        mid = _mid;
        bot = _bot;
        TileMapX3Parent = parent;
        level = _level;

        RelocateTiles();
    }

    public void RelocateTiles()
    {
        top.Tile.transform.localPosition = new Vector3(1, 0, 0);
        mid.Tile.transform.localPosition = new Vector3(0, 0, 0);
        top.Tile.transform.localPosition = new Vector3(-1, 0, 0);
    }
}

public struct TileMapX9
{
    TileMapX3 left, mid, right;
    Vector3 topPos, midPos, botPos;
    GameObject TileMapX9Parent;
}

public class TileFactory : MonoBehaviour
{
    [Header("Climate Station Stup")]
    public TileSetup SpringSetup;
    public TileSetup SummerSetup;
    public TileSetup AutumSetup;
    public TileSetup WinterSetup;

    [Header("Tile Creation")]
    public ClimateStation DesiredStation;
    public ObstacleType Top;
    public ObstacleType Mid;
    public ObstacleType Bot;
    public int Level;

    private TileMapX3 tileToCreate;


    public TileMapX3 CreateTile3x3()
    {
        switch (DesiredStation)
        {
            case ClimateStation.SPRING:
                return GetTiles(SpringSetup);
            case ClimateStation.SUMMER:
                return GetTiles(SummerSetup);
            case ClimateStation.AUTUM:
                return GetTiles(AutumSetup);
            case ClimateStation.WINTER:
                return GetTiles(WinterSetup);
        }

        Debug.LogError("Could not Create a Tile 3x3");
        return new TileMapX3();
    }

    private TileMapX3 GetTiles(TileSetup station)
    {
        TileMapX3 Tile;

        //Top
        TileSetupObject top = new TileSetupObject();
        foreach (TileSetupObject tile in station.TopTiles)
        {
            if(tile.ObstacleType == Top)
            {
                top = tile;
            }
        }

        if(top.Tile == null) { Debug.LogError("Could not find a top Tile with the ObstacleType: " + Top.ToString());}

        //Mid
        TileSetupObject mid = new TileSetupObject();
        foreach (TileSetupObject tile in station.MidTiles)
        {
            if (tile.ObstacleType == Mid)
            {
                mid = tile;
            }
        }

        if (mid.Tile == null) { Debug.LogError("Could not find a mid Tile with the ObstacleType: " + Mid.ToString()); }


        //Top
        TileSetupObject bot = new TileSetupObject();
        foreach (TileSetupObject tile in station.BotTiles)
        {
            if (tile.ObstacleType == Bot)
            {
                bot = tile;
            }
        }

        if (mid.Tile == null) { Debug.LogError("Could not find a bot Tile with the ObstacleType: " + Bot.ToString()); }


        GameObject parent = new GameObject(DesiredStation.ToString() + "_Level" + Level);

        Tile = new TileMapX3(parent, top, mid, bot, Level);

        return Tile;
    }
}


