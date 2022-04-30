using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    
    [Header("World Parameters")]
    public int width;
    public int height;
    public float smoothness;
    public TileBase[] tiles;
    public Tilemap worldTilemap;
    int[,] world;
    float seed;

    [Header("Cave Parameters")]
    public int minCaveWidth;
    public int maxCaveWidth;
    public int maxCaveChange;
    public int roughness;
    public int curvyness;
    
    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(1,10000000);
        world = generateArray(width, height, true);
        world = terrainGenerator(world);
        world = verticalTunnel(world, minCaveWidth, maxCaveWidth, maxCaveChange, roughness, curvyness, width/2);
        world = verticalTunnel(world, minCaveWidth, maxCaveWidth, maxCaveChange, roughness, curvyness, width/4);
        world = verticalTunnel(world, minCaveWidth, maxCaveWidth, maxCaveChange, roughness, curvyness, 3*width/4);
        world = horizontalTunnel(world);
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1) {
                    world[x,y] = 3;
                }
                if (((x > 0 && x < 5) || (x < width - 1 && x > width - 6)) && y > height/15 - 4) {
                    world[x,y] = 0;
                }
            }
        }
        renderWorld(world, worldTilemap);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public int[,] generateArray(int width, int height, bool empty) {
        int[,] world = new int[width, height];
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                if (empty) {
                    world[x,y] = 0;
                }
                else {
                    world[x,y] = 1; 
                }
            }
        }
        return world;
    }

    public void renderWorld(int[,] world, Tilemap groundTilemap) {
        for (int x = 0; x < width; x++){
            for (int y = 0; y < height; y++){
                if (world[x,y] == 1) {
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), tiles[0]);
                }
                if (world[x,y] == 2) {
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), tiles[1]);
                }
                if (world[x,y] == 3) {
                    groundTilemap.SetTile(new Vector3Int(x, y, 0), tiles[2]);
                }
            }
        }
    }

    public int[,] terrainGenerator(int[,] world) {
        int perlinHeight;
        for (int x = 0; x < width; x++){
            perlinHeight = Mathf.RoundToInt(Mathf.PerlinNoise(x/smoothness, seed) * height/3);
            for (int y = 0; y < perlinHeight; y++){
                if (y < perlinHeight - 3) {
                    world[x,y] = 3;
                }
                else if (y == perlinHeight - 1) {
                    world[x,y] = 1;
                }
                else {
                    world[x,y] = 2;
                }
            }
        }
        return world;
    }

    public int[,] verticalTunnel(int[,] world, int minPathWidth, int maxPathWidth, int maxPathChange, int roughness, int curvyness, int x) {
        int tunnelWidth = 1;
        System.Random rand = new System.Random(seed.GetHashCode());

        for (int i = -tunnelWidth; i <= tunnelWidth; i++) {
            world[x + i, 0] = 0;
        }
        for (int y = 1; y < height; y++) {
            if (rand.Next(0, 100) > roughness) {
                int widthChange = Random.Range(-maxPathWidth, maxPathWidth);
                tunnelWidth += widthChange;
                if (tunnelWidth < minPathWidth) {
                    tunnelWidth = minPathWidth;
                }
                if (tunnelWidth > maxPathWidth) {
                    tunnelWidth = maxPathWidth;
                }
            }
            if (rand.Next(0, 100) > curvyness) {
                int xChange = Random.Range(-maxPathChange, maxPathChange);
                x += xChange;
                if (x < maxPathWidth) {
                    x = maxPathWidth;
                }
                if (x > width - maxPathWidth) {
                    x = width - maxPathWidth;
                }
            }
            for (int i = -tunnelWidth; i <= tunnelWidth; i++) {
                world[x + i, y] = 0;
            }
        }
        return world;
    }

    public int[,] horizontalTunnel(int[,] world) {
        int y = height/15;
        int tunnelHeight = 8;
        for (int i = -tunnelHeight; i <= tunnelHeight; i++) {
            world[0, y + i] = 0;
        }
        for (int x = 1; x < width; x++) {
            tunnelHeight += Random.Range(-2, 3);
            if (tunnelHeight > 11) {
                tunnelHeight = 11;
            }
            else if (tunnelHeight < 5) {
                tunnelHeight = 5;
            }
            for (int i = -tunnelHeight; i <= tunnelHeight; i++) {
               world[x, y + i] = 0;
            }
        }
        return world;
    }

}
