using System;

namespace ElevaManageSchools.Infrastructure
{
    public class DatabaseException : Exception
    {
        public DatabaseException() : base()
        {
        }

        public DatabaseException(string message) : base(message)
        {
        }
    }

}
