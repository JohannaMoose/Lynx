namespace Lynx.Core.Conditions
{
    /// <summary>
    /// Contract for all conditions
    /// </summary>
    public interface Condition
    {
        /// <summary>
        /// Get flag to indicate if the condition the object represnt is fullfilled 
        /// </summary>
         bool ConditionMeet { get; }
    }
}