fun-eve

A collection of useful utility functions, API integrations, and other .net related support code for other software that I develop for Eve Online.

The project is setup to accomodate F#'s linear compilation. With domain driven design using discriminated unions, rather than using class heirarchy, you use a tree structure of discriminated unions. The most granular nodes are either discriminated unions that are single case and wrap primitive types, or discriminated unions that represent a set of choices and do not wrap any types.

A typical heirarchy might look like this:

    type Name = Name of string
    type Phone = Phone of int
    type Color = 
    | Brown
    | Blond
    | Black
    | Blue
    | Green
    
    type PersonalData = 
    | FirstName of Name
    | LastName of Name
    | PhoneNumber of Phone
    | HairColor of Color
    | EyeColor of Color

Personal data is the union type of subtypes Name, Phone, Color, etc. 

This requires that subtypes have their implementation prior to the implementation of other types that use them. This project is organized to compile in this order:

- Utility
- Geography
- Product
- Ice
- Ore
- Collections
- Market
- Industry
- Interop


