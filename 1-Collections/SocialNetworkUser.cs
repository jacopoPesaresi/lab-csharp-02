using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        IDictionary<string, ISet<TUser>> social = new Dictionary<string, ISet<TUser>>();
        //ISet<User> followers = new HashSet<User>();
        IUser myUser;
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            myUser = new User(fullName, username, age);
            //throw new NotImplementedException("TODO is there anything to do here?");
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (!social.Keys.Contains(group)){
                social[group] = new HashSet<TUser>();
            }
            return social[group].Add(user);
            //throw new NotImplementedException("TODO add user to the provided group. Return false if the user was already in the group");
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                IList<TUser> tmp = new List<TUser>();
                foreach (var item in social)
                {
                    foreach (TUser us in item.Value)
                    {
                        tmp.Add(us);
                    }
                }
                return tmp;
                //throw new NotImplementedException("TODO construct and return the list of all users followed by the current users, in all groups");
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (!social.Keys.Contains(group)) return new HashSet<TUser>();
            return social[group];
            //throw new NotImplementedException("TODO construct and return a collection containing of all users followed by the current users, in group");
        }
    }
}
