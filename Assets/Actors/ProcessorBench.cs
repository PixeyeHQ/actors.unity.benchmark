using Game.Source;
using Pixeye.Actors;
using UnityEngine;

namespace Pixeye.Source
{
  sealed class ProcessorBench : Processor, ITick
  {
    readonly Vector3 moveVector = Vector3.one;
    Group<ComponentBench> gBench = default;

    protected override void OnAwake()
    {
      LayerApp.CreateObjects(Layer);
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