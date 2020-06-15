using System;
using Game.Source;
using Pixeye.Actors;
using UnityEngine;

namespace Pixeye.Source
{
  public class ProcessorBenchThreaded : Processor, ITick
  {
    static readonly Vector3 moveVector = Vector3.one;
    Group<ComponentBench> gBench = default;

    public ProcessorBenchThreaded()
    {
      gBench.MakeConcurrent(50000, Math.Min(Environment.ProcessorCount - 1, 8), HandleCalculation);
      LayerApp.CreateObjects(Layer);
    }

    public void Tick(float delta)
    {
      for (var i = 0; i < gBench.length; i++)
      {
        ref var cBench = ref gBench.entities[i].ComponentBench();
        cBench.transform.position = cBench.position;
      }

      gBench.Execute();
      Ecs.Update();
    }

    static void HandleCalculation(SegmentGroup segment)
    {
      for (int i = segment.indexFrom; i < segment.indexTo; i++)
      {
        var     entityID = segment.source.entities[i].id;
        ref var cBench   = ref StorageComponentBench.components[entityID];
        for (int j = 0; j < LayerApp.STEPS; j++)
        {
          cBench.position.x += moveVector.x;
          cBench.position.y += moveVector.y;
          cBench.position.z += moveVector.z;
        }
      }
    }
  }
}