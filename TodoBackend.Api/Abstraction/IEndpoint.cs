namespace TodoBackend.Abstraction;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}