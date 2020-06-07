using System;
using Game.Source;
using Pixeye.Actors;
using UnityEngine;
using Random = Pixeye.Actors.Random;

public class LayerApp : Layer<LayerApp>
{
  public static int SIZE = 100_000;
  public static int STEPS = 3;
  public static int CurrentBenchLayerID = -1;

  protected override void Setup()
  {
  }

  public void SetBench(int arg)
  {
    SceneSub.Remove(CurrentBenchLayerID);
    SceneSub.Add(arg);
    CurrentBenchLayerID = arg;
  }

  public void SetSize(string arg)
  {
    SIZE = Convert.ToInt32(arg);
  }

  public void SetCalculations(string arg)
  {
    STEPS = Convert.ToInt32(arg);
  }

  public static void CreateObjects(LayerCore Layer)
  {
    var prefab = Box.Load<GameObject>("MonoPoint");

    for (int i = 0, length = SIZE; i < length; i++)
    {
      var entity = Layer.Entity.Create(prefab);
      ref var eBench = ref entity.Set<ComponentBench>();
      eBench.transform = entity.transform;
      eBench.position = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
      entity.transform.position = eBench.position;
    }
  }
}