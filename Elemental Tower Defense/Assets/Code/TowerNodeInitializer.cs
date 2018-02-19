﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerNodePlace
{
    public int StartX { get; set; }
    public int StartY { get; set; }
    public int LengthX { get; set; }
    public int LengthY { get; set; }
    public TowerNodePlace(int startX, int startY, int lengthX, int lengthY)
    {
        this.LengthY = lengthY;
        this.LengthX = lengthX;
        this.StartY = startY;
        this.StartX = startX;
    }
}

public enum WallRotation
{
    VERTICAL,
    HORIZONTAL
}
public class Wall
{
	public int StartX { get; set; }
    public int StartY { get; set; }
    public int Length { get; set; }
    public WallRotation Rotation { get; set; }

    public Wall(int startX, int startY, int length, WallRotation rotation)
    {
		this.StartX = startX;
		this.StartY = startY;
        this.Rotation = rotation;
        this.Length = length;
    }
}

public class TowerNodeInitializer : MonoBehaviour
{
    public Transform TowerNode;
    public Transform Wall;
    public List<TowerNodePlace> TowerNodePlaces { get; set; }
    public List<Wall> Walls { get; set; }
    void Start()
    {
        InitializeWalls();
        RenderWalls();
        InitializeTowerNodePlaces();
        RenderTowerNodePlaces();
    }

    private void InitializeTowerNodePlaces()
    {
        TowerNodePlaces = new List<TowerNodePlace>();
        TowerNodePlaces.Add(new TowerNodePlace(1, 1, 4, 4));
        TowerNodePlaces.Add(new TowerNodePlace(13, 1, 4, 16));
        TowerNodePlaces.Add(new TowerNodePlace(7, 13, 4, 10));
        TowerNodePlaces.Add(new TowerNodePlace(11, 13, 2, 4));
        TowerNodePlaces.Add(new TowerNodePlace(25, 1, 16, 4));
        TowerNodePlaces.Add(new TowerNodePlace(17, 13, 18, 4));
        TowerNodePlaces.Add(new TowerNodePlace(19, 25, 4, 10));
        TowerNodePlaces.Add(new TowerNodePlace(1, 31, 18, 4));
        TowerNodePlaces.Add(new TowerNodePlace(31, 17, 4, 30));
        TowerNodePlaces.Add(new TowerNodePlace(6, 43, 25, 4));
    }

    private void InitializeWalls()
    {
        Walls = new List<Wall>();
        Walls.Add(new Wall(21, 0, 42, WallRotation.HORIZONTAL));
		Walls.Add(new Wall(0,27,54, WallRotation.VERTICAL));
		Walls.Add(new Wall(21, 54, 42, WallRotation.HORIZONTAL));
		Walls.Add(new Wall(42,27,54, WallRotation.VERTICAL));

    }

    private void RenderTowerNodePlaces()
    {
        foreach (var towerNodePlace in TowerNodePlaces)
        {
            var startX = towerNodePlace.StartX;
            var startY = towerNodePlace.StartY;
            for (var x = 0; x < towerNodePlace.LengthX; x++)
            {
                for (var y = 0; y < towerNodePlace.LengthY; y++)
                {
                    var newNodePlace = Instantiate(TowerNode, new Vector3(startY + y, 0, startX + x), Quaternion.identity);
                    newNodePlace.name = "TowerNode" + x + "_" + y;
                    newNodePlace.parent = GameObject.FindGameObjectWithTag("TowerNodes").transform;
					newNodePlace.localScale = new Vector3(0.97F, 0.1F, 0.97F);
                }
            }
        }
    }

    private void RenderWalls()
    {
        foreach (var wall in Walls)
        {
            var newWall = Instantiate(Wall, new Vector3(wall.StartY, 0.75F, wall.StartX), Quaternion.identity);
            newWall.name = "Wall" + wall.StartX + wall.StartY + wall.Rotation.ToString();
            newWall.parent = GameObject.FindGameObjectWithTag("Walls").transform;
            newWall.localScale = new Vector3(0.25F, 2F, wall.Length);
            switch (wall.Rotation)
            {
                case WallRotation.HORIZONTAL:
                    newWall.Rotate(new Vector3(0, 0, 0));
                    break;
                case WallRotation.VERTICAL:
                    newWall.Rotate(new Vector3(0, 90, 0));
                    break;
            }
        }
    }
}
