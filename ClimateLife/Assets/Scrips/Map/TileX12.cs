using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TileMapX12
{
    public TileX3 first, second, third, fourth;
    public GameObject TileMapX12Parent;

    public TileMapX12(TileX3 _first, TileX3 _second, TileX3 _third, TileX3 _fourth, GameObject parent)
    {
        first = _first;
        second = _second;
        third = _third;
        fourth = _fourth;
        TileMapX12Parent = parent;
    }
}

public class TileX12 : MonoBehaviour
{
    public ClimateStation station;
    public int DificultyLevel = 0;
    public TileMapX12 TileMap;


    public TileX12(ClimateStation st, int level, TileMapX12 tile)
    {
        station = st;
        DificultyLevel = level;
        TileMap = tile;
    }

    public void RellocateTiles()
    {
        transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
        transform.GetChild(1).localPosition = new Vector3(0, 0, 1);
        transform.GetChild(2).localPosition = new Vector3(0, 0, 2);
        transform.GetChild(3).localPosition = new Vector3(0, 0, 3);


        TileMap.first.RelocateTiles();
        TileMap.second.RelocateTiles();
        TileMap.third.RelocateTiles();
        TileMap.fourth.RelocateTiles();
    }
}
