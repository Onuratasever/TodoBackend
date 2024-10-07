using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoBackend.Abstraction;
using TodoBackend.Application.TodoLists.Create;
using TodoBackend.Application.TodoLists.Delete;
using TodoBackend.Application.TodoLists.GetByTodoListId;
using TodoBackend.Application.TodoLists.GetByUserId;
using TodoBackend.Application.TodoLists.Update;

namespace TodoBackend.Endpoints;

public class TodoListsEndpoint: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var routeGroup = app
            .MapGroup("TodoLists")
            .WithTags("TodoLists");

        MapV1(routeGroup);
    }
    
    private static void MapV1(IEndpointRouteBuilder routeGroup)
    {
        routeGroup.MapGet("{userId:guid}/{id:guid}", async (IMediator mediator, Guid userId,Guid id) =>
        {
            var request = new GetTodoListByTodoListIdQueryRequest {TodoListId = id, UserId = userId};
            var response = await mediator.Send(request);
            if (!response.Success && response.Message == "TodoList not found")
            {
                return Results.NotFound();
            }
            if (!response.Success && response.Message == "Unauthorized")
            {
                return Results.Unauthorized();
            }
            return Results.Ok(response);
        })
        .MapToApiVersion(1);
        
        routeGroup.MapGet("getAllTodoLists", async (IMediator mediator, [AsParameters] GetTodoListByUserIdQueryRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .MapToApiVersion(1);
        
        
        routeGroup.MapPost("createTodoList", async (IMediator mediator, [FromBody] CreateTodoListCommandRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .MapToApiVersion(1);
        
        routeGroup.MapPut("updateTodoList", async (IMediator mediator, [FromBody] UpdateTodoListCommandRequest request) =>
        {
            var response = await mediator.Send(request);
            if (!response.Success && response.Message == "TodoList not found")
            {
                return Results.NotFound();
            }
        
            if (!response.Success && response.Message == "Unauthorized")
            {
                return Results.Unauthorized();
            }
        
            return Results.Ok(response.TodoList);
        })
        .MapToApiVersion(1);
        
        routeGroup.MapDelete("delete", async (IMediator mediator, [AsParameters] DeleteTodoListCommandRequest request) =>
        {
            var response = await mediator.Send(request);
            if (!response.Success && response.Message == "TodoList not found")
            {
                return Results.NotFound();
            }
        
            if (!response.Success && response.Message == "Unauthorized")
            {
                return Results.Unauthorized();
            }
        
            return Results.Ok();
        }).MapToApiVersion(1);
    }
}