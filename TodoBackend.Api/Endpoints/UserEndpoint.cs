using TodoBackend.Abstraction;
using TodoBackend.Application.Users.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoBackend.Application.Users.Create;
using TodoBackend.Application.Users.Delete;
using TodoBackend.Application.Users.GetAll;
using TodoBackend.Application.Users.Update;


namespace TodoBackend.Endpoints;

public class UserEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var routeGroup = app
            .MapGroup("Todo")
            .WithTags("Todo");

        MapV1(routeGroup);
    }

    private static void MapV1(IEndpointRouteBuilder routeGroup)
    {
        routeGroup.MapGet("users", async (IMediator mediator, [AsParameters] GetUserByIdQueryRequest request) =>
        {
            var response = await mediator.Send(request);
            return response.User == null ? Results.NotFound() : Results.Ok(response);
        })
        .MapToApiVersion(1);
        
        routeGroup.MapGet("/api/users/getAllUsers", async (IMediator mediator, [AsParameters] GetAllUsersQueryRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .MapToApiVersion(1);
        
        
        routeGroup.MapPost("/api/users/createUser", async (IMediator mediator, [FromBody] CreateUserCommandRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .MapToApiVersion(1);
        
        routeGroup.MapPut("/api/users/updateUser", async (IMediator mediator, [FromBody] UpdateUserCommandRequest request) =>
        {
            var response = await mediator.Send(request);
            return response.User == null ? Results.NotFound() : Results.Ok(response);
        })
        .MapToApiVersion(1);

        routeGroup.MapDelete("/api/users/deleteUser/{id:guid}", async (IMediator mediator, Guid id) =>
        {
            var request = new DeleteUserCommandRequest { Id = id };
            var response = await mediator.Send(request);
            return !response.Success ? Results.NotFound(response.Message) : Results.Ok(response.Message);
        }).MapToApiVersion(1);
    }
}