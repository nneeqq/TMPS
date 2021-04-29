using System.Collections;
using System.Collections.Generic;

namespace TMPS_LAB4.Data
{
    public class UserService : IUser, IEnumerable<IUser>
    {
        private readonly List<IUser> _subordinates = new List<IUser>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public IUser IUser
        {
            get => default;
            set
            {
            }
        }

        public void AddSubordinate(IUser subordinate)
        {
            _subordinates.Add(subordinate);
        }

        public void RemoveSubordinate(IUser subordinate)
        {
            _subordinates.Remove(subordinate);
        }

        public IUser GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IUser> GetEnumerator()
        {
            foreach (IUser subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
