using Pixeye.Actors;
using Pixeye.Source;

public class LayerBench : Layer<LayerBench>
{
  protected override void Setup()
  {
     Add<ProcessorBench>();
  }

  protected override void OnLayerDestroy()
  {
  }
}