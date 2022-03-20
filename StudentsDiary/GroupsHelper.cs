using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDiary
{
    public class GroupsHelper
    {
        public static List<Group> GetGroups(string defaultName)
        {
            return new List<Group>
            {
                new Group { Id = 0 , GroupName = defaultName },
                new Group { Id = 1 , GroupName = "Grupa A"},
                new Group { Id = 2 , GroupName = "Grupa B"},
                new Group { Id = 3 , GroupName = "Grupa C"}
            };
        }
    }
}
