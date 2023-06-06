namespace GrillBackend.Models.Abstractions
{
    public interface IGrillable : ICloneable
    {
        public abstract void Feed();
    }
}
