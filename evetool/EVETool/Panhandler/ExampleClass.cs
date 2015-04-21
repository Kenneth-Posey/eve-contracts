// C# code

using System.Linq;

namespace ExampleUse 
{
    public class Example
    {
        public void ReadFromFsharp()
        {
            var bob = IntroDUs.IntroDUs.ExampleUse.somePeople.ToList()[0];
            // The "value" extension property allows us to directly
            // access the DU values easily from C#
            string bobsFirstName = bob.First.Value;
            string bobsLastName = bob.Last.Value;
        }
    }
}
