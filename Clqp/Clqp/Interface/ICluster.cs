namespace Clqp;

public interface ICluster<TFor>
{
    public void WorkWith(TFor router);
}