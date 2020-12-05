using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI
{
    class GroupWrapper
    {
        public Group Group { get; private set; }
        public GroupWrapper(Group group)
        {
            Group = group;
        }
        public override string ToString()
        {
            return $"{Group.Id} : {Group.Specialty.Index}";
        }
    }
}
