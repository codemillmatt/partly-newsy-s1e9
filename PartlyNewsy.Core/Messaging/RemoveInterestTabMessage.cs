using System;
namespace PartlyNewsy.Core
{
    public class RemoveInterestTabMessage
    {
        public readonly static string RemoveTabMessage = "remove-tab-message";

        public string InterestName { get; set; }
    }
}
