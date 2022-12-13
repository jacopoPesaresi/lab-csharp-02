using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        IDictionary<string, ISet<TUser>> social = new Dictionary<string, ISet<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (!social.Keys.Contains(group)){
                social[group] = new HashSet<TUser>();
            }
            return social[group].Add(user);
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
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (!social.Keys.Contains(group)) return new HashSet<TUser>();
            return social[group];
        }
    }
}
