namespace PhoneBook.Model

open System.ComponentModel.DataAnnotations

  [<CLIMutable>]
  type PhoneNumber =
    {
      [<Key>]
      Id     : int
      Type   : string 
      Number : string
    } 