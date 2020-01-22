using System;
using System.Collections.Generic;

namespace PartlyNewsy.Core
{
    public class AddInterestTabMessage
    {
        public readonly static string AddTabMessage = "add-new-tab-message";

        public InterestSubMessage InterestInfo { get; set; }
    }

    public class InterestSubMessage
    {
        public string Category { get; set; }
        public string Title { get; set; }
    }
}
