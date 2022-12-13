using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            FullName = fullName;
            Username = username;
            Age = age;
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

       // public bool IsAgeDefined => throw new NotImplementedException("TODO check whether age is non-null or not");
        public bool IsAgeDefined => Age == null? false : true;
        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)
    }
}
