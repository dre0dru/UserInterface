namespace Dre0Dru.Screens
{
    public interface IPayloadedScreen<in TPayload>
    {
        void SetPayload(TPayload payload);
    }
}
