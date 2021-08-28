namespace PhoneBook

open System.Collections.Generic
open System.Linq
open Microsoft.AspNetCore.Mvc
open Microsoft.EntityFrameworkCore
open PhoneBook.Model
open PhoneBook.Data.Context

[<Route("api/[Controller]")>]
[<ApiController>]
type ContactController private () =
    inherit ControllerBase()
    new (context: DatabaseContext) as this =
        ContactController () then
        this._Context <- context

    [<DefaultValue>]
    val mutable _Context : DatabaseContext 

    [<HttpGet>]
    member this.Get() =
        Ok(this._Context.Contacts.ToList())