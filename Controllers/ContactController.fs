namespace phoneBookAPI.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open phoneBookAPI
open Microsoft.EntityFrameworkCore
open PhoneBook.Model
open PhoneBook.Data.Context

[<ApiController>]
[<Route("[controller]")>]
type ContactController (logger : ILogger<ContactController>) =
    inherit ControllerBase()
    //new (context: DatabaseContext) as this =
    //    ContactController () then
    //    this._Context <- context

    //[<DefaultValue>]
    //val mutable _Context : DatabaseContext 

    [<HttpGet>]
    member _.Get() =
        Ok("Hello, world")
