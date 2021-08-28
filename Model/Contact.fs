namespace PhoneBook.Model

open System.ComponentModel.DataAnnotations

  [<CLIMutable>]
  type Contact =
    {
      [<Key>]
      Id : int
      [<Required>]
      Name : string
      PhoneNumbers : List<PhoneNumber>
    }
