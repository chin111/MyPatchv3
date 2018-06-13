namespace MyPatchV3.SAL
{
    public interface IAPIService
    {
        IMyPatchV3API Speculative { get; }
        IMyPatchV3API UserInitiated { get; }
        IMyPatchV3API Background { get; }
    }
}
