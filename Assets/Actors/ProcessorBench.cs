using Game.Source;
using Pixeye.Actors;
using UnityEngine;
using Random = Pixeye.Actors.Random;

namespace Pixeye.Source
{
  sealed class ProcessorBench : Processor, ITick
  {
    readonly Vector3 moveVector = Vector3.one;
    Group<ComponentBench> gBench = default;

    protected override void OnAwake()
    {
      var prefab = Box.Load<GameObject>("MonoPoint");

      for (int i = 0, length = 100_000; i < length; i++)
      {
        var entity = Entity.Create(prefab);
        ref var eBench = ref entity.Set<ComponentBench>();
        eBench.transform = entity.transform;
        eBench.position = new Vector3(Random.Range(-100f, 100f), Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        entity.transform.position = eBench.position;
      }
    }

    public void Tick(float delta)
    {
      for (var i = 0; i < gBench.length; i++)
      {
        ref var cBench = ref gBench.entities[i].ComponentBench();
        cBench.position.x         += moveVector.x;
        cBench.position.y         += moveVector.y;
        cBench.position.z         += moveVector.z;
        cBench.transform.position =  cBench.position;
      }

      Ecs.Update();
    }
  }
}