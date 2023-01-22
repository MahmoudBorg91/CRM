using Microsoft.EntityFrameworkCore;

namespace GSI_Internal.Entites
{
    [Keyless]
    public class TaskPriorityLevel
    {
        public int PriorityLevel_ID { get; set; }
        public string PriorityLevel_Name { get; set; }
    }
}
