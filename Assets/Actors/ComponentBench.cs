using Pixeye.Actors;
using UnityEngine;


namespace Game.Source
{
  public struct ComponentBench
  {
    public Transform transform;
    public Vector3 position;
  }

  #region HELPERS

  static partial class Component
  {
    public const string Bench = "Game.Source.ComponentBench";

    public static ref ComponentBench ComponentBench(in this ent entity) =>
      ref Storage<ComponentBench>.components[entity.id];
  }

  sealed class StorageComponentBench : Storage<ComponentBench>
  {
    public override ComponentBench Create() => new ComponentBench();

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