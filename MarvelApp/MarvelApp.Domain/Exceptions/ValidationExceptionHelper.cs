using System;

namespace MarvelApp.Domain.Exceptions
{
    public class ValidationExceptionHelper : Exception
    {
        public ValidationExceptionHelper(string message):base(message)
        {

        }
    }
}
