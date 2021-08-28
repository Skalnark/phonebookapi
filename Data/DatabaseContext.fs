namespace PhoneBook.Data 

open PhoneBook.Model
open Microsoft.EntityFrameworkCore
open System.Linq

module Context =

    type DatabaseContext(options : DbContextOptions<DatabaseContext>) = 
        inherit DbContext(options)
    
        [<DefaultValue>]
        val mutable phoneNumbers : DbSet<PhoneNumber>
        member this.PhoneNumbers with get() = this.phoneNumbers and set v = this.phoneNumbers <- v
        [<DefaultValue>]
        val mutable contacts : DbSet<Contact>
        member this.Contacts with get() = this.contacts and set v = this.contacts <- v

    let Initialize (context : DatabaseContext) =
        context.Database.EnsureCreated() |> ignore