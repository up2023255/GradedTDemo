using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkGenerator : AbstractGenerator
{
    [SerializeField]
    protected RandomWalkData randomWalkParamiters;


    protected override void RunProceduralGeneration()
    {
        HashSet<Vector2Int> floorPosition = RunRandomWalk(randomWalkParamiters, startPos);
        tileMapVisualiser.Clear();
        tileMapVisualiser.paintFloorTile(floorPosition);
        WallGenerator.CreateWalls(floorPosition, tileMapVisualiser);
    }

    protected HashSet<Vector2Int> RunRandomWalk(RandomWalkData Parameters, Vector2Int position)
    {
        var currentPos = position;
        HashSet<Vector2Int> floorPosition = new HashSet<Vector2Int>();
        for (int i = 0; i < randomWalkParamiters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithm.SimpleRandomWalk(currentPos, randomWalkParamiters.walkLength);
            floorPosition.UnionWith(path);
            if (randomWalkParamiters.statrtRandomlyEachIteration)
                currentPos = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
        }
        return floorPosition;
    }

    private void Start()
    {
        // RunProceduralGeneration();
    }

}
