namespace CQRS.CQRSWriteServive.Commands.Response
{
    public class CreateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public Guid Id { get; set; }
    }
}
