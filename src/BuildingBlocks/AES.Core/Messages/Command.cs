using System;
using System.Collections.Generic;
using System.Text;

namespace AES.Core.Messages
{
    public abstract class Command
    {
        public DateTime Timestamp { get; private set; }
    }
}
