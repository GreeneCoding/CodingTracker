using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class CodingSession
    {
        int Id { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        String ?Duration { get; set; }
    }
}
