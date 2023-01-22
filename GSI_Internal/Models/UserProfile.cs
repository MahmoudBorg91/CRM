using System.Collections.Generic;

namespace GSI_Internal.Models
{
    public class UserProfile
    {
        public IEnumerable<TaskMain_VM> TaskMain_VM { get; set; }

        public IEnumerable<RequestAction_VM> RequestAction_VM { get; set; }
    }
}
