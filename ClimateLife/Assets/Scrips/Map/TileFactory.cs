using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum ClimateStation { SPRING, SUMMER, AUTUM, WINTER }


public class TileFactory : MonoBehaviour
{
    [Header("Climate Station Stup")]
    public TileSetup SpringSetup;
    public TileSetup SummerSetup;
    public TileSetup AutumSetup;
    public TileSetup WinterSetup;

    public ClimateStation DesiredStation;
    public int Level;


    [Header("Tile Creation X3")]
    public ObstacleType Top;
    public ObstacleType Mid;
    public ObstacleType Bot;

    [Header("Tile Creation X12")]
    public int TileCreationaAmount;



    #region TILEX3
    public GameObject CreateTileX3(out string stationFolder)
    {
        switch (DesiredStation)
        {
            case ClimateStation.SPRING:
                stationFolder = "Spring/";
                return GetSingleTiles(SpringSetup);
            case ClimateStation.SUMMER:
                stationFolder = "Summer/";
                return GetSingleTiles(SummerSetup);
            case ClimateStation.AUTUM:
                stationFolder = "Autum/";
                return GetSingleTiles(AutumSetup);
            case ClimateStation.WINTER:
                stationFolder = "Winter/";
                return GetSingleTiles(WinterSetup);
        }

        Debug.LogError("Could not Create a Tile 3x3");
        stationFolder = "";
        return null;
    }

    private GameObject GetSingleTiles(TileSetup station)
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


        GameObject parent = new GameObject(DesiredStation.ToString() + "_Level_" + Level);

        Tile = new TileMapX3(parent, top, mid, bot, Level);

        TileX3 tilex3 = parent.AddComponent<TileX3>();
        tilex3.DificultyLevel = Level;
        tilex3.station = DesiredStation;
        tilex3.TileMap = Tile;

        return parent;
    }

    #endregion

    #region TILEX12
    public GameObject[] CreateTileX12Group(out string stationFolder)
    {
        GameObject[] tiles = new GameObject[TileCreationaAmount];
        stationFolder = "";

        for ( int i = 0; i < TileCreationaAmount; i++)
        {
            tiles[i] = CreateTileX12(out stationFolder);
            tiles[i].GetComponent<TileX12>().RellocateTiles();
        }

        return tiles;
    }

    public GameObject CreateTileX12(out string stationFolder)
    {
        switch (DesiredStation)
        {
            case ClimateStation.SPRING:
                stationFolder = "Spring/";
                return GetTilesX12("Prefabs/Map/Spring/TilesX3");
            case ClimateStation.SUMMER:
                stationFolder = "Summer/";
                return GetTilesX12("Prefabs/Map/Summer/TilesX3");
            case ClimateStation.AUTUM:
                stationFolder = "Autum/";
                return GetTilesX12("Prefabs/Map/Autum/TilesX3");
            case ClimateStation.WINTER:
                stationFolder = "Winter/";
                return GetTilesX12("Prefabs/Map/Winter/TilesX3");
        }

        Debug.LogError("Could not Create a Tile x12");
        stationFolder = "";
        return null;
    }

    private GameObject GetTilesX12(string path)
    {
        GameObject parent = new GameObject(DesiredStation.ToString() + "_Level_" + Level);

        TileX3[] tiles = GetTilesOfLevel(Resources.LoadAll<TileX3>(path), Level);
        

        TileX3[] randomTiles = new TileX3[4];

        for(int i = 0; i < 4; ++i)
        {
            int rand = Random.Range(0, tiles.Length - 1);
            randomTiles[i] = tiles[rand];
            Instantiate(randomTiles[i], parent.transform);
        }


        TileMapX12 tilex12 = new TileMapX12(randomTiles[0], randomTiles[1], randomTiles[2], randomTiles[3], parent);

        TileX12 tile = parent.AddComponent<TileX12>();
        tile.DificultyLevel = Level;
        tile.TileMap = tilex12;
        tile.station = DesiredStation;

        return parent;
    }

    private TileX3[] GetTilesOfLevel(TileX3[] tiles, int level)
    {
        List<TileX3> tmp = new List<TileX3>();
        foreach(TileX3 t in tiles)
        {
            if (t.DificultyLevel == level)
                tmp.Add(t);
        }

        return tmp.ToArray();
    }
    #endregion

}


