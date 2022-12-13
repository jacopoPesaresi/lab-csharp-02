using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        ISet<User> followers = new HashSet<User>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            //throw new NotImplementedException("TODO is there anything to do here?");
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            throw new NotImplementedException("TODO add user to the provided group. Return false if the user was already in the group");
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                throw new NotImplementedException("TODO construct and return the list of all users followed by the current users, in all groups");
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            throw new NotImplementedException("TODO construct and return a collection containing of all users followed by the current users, in group");
        }
    }
}
