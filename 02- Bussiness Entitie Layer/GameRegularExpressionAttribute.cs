using System.ComponentModel.DataAnnotations;

namespace Match_Memory_Game
{
    internal class GameRegularExpressionAttribute : RegularExpressionAttribute
    {
        public GameRegularExpressionAttribute(string pattern) : base(pattern)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return "The" +" "+ name + " is invalid";
        }
    }
}