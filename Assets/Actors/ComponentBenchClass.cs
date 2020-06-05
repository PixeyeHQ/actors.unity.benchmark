using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
  public class ComponentBenchClass
  {
    public Transform transform;
    public Vector3 position;
  }

  #region HELPERS

  static partial class Component
  {
    public const string BenchClass = "Game.Source.ComponentBenchClass";

    public static ref ComponentBenchClass ComponentBenchClass(in this ent entity) =>
      ref Storage<ComponentBenchClass>.components[entity.id];
  }

  sealed class StorageComponentBenchClass : Storage<ComponentBenchClass>
  {
    public override ComponentBenchClass Create() => new ComponentBenchClass();

    // Use for cleaning components that were removed at the current frame.
    public override void Dispose(indexes disposed)
    {
      foreach (var id in disposed)
      {
        ref var component = ref components[id];
      }
    }
  }

  #endregion
}