using Pixeye.Actors;
using Pixeye.Source;

public class LayerBenchSimple : Layer<LayerBenchSimple>
{
  protected override void Setup()
  {
    Add<ProcessorBench>();
  }
}