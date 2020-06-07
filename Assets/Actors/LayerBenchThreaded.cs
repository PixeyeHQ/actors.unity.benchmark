using Pixeye.Actors;
using Pixeye.Source;

public class LayerBenchThreaded : Layer<LayerBenchThreaded>
{
  protected override void Setup()
  {
    Add<ProcessorBenchThreaded>();
  }
}