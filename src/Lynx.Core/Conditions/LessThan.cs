using System;

namespace Lynx.Core.Conditions
{
    /// <summary>
    /// Class representing a less than (or equals) 
    /// </summary>
    public class LessThan : Condition
    {
        /// <summary>
        /// Creates a new instance of the LessThan class
        /// </summary>
        /// <param name="toEvaluate">The number that should be less or equal</param>
        /// <param name="evaulateAgainst">The number the first number should be less or equal to</param>
        /// <param name="allowEquals">If true this less than becomes a less than or equals, defaults to false</param>
        /// <exception cref="ArgumentNullException">Thrown if either of the numbers are null</exception>
        public LessThan(Number toEvaluate, Number evaulateAgainst, bool allowEquals = false)
        {
            if (toEvaluate == null)
                throw new ArgumentNullException(nameof(toEvaluate), "Numbers can't be null");
            else if (evaulateAgainst == null)
                throw new ArgumentNullException(nameof(evaulateAgainst), "Numbers can't be null");

            ToEvaluate = toEvaluate;
            EvaluateAgainst = evaulateAgainst;
            AllowEqual = allowEquals; 
        }

        /// <summary>
        /// Get flag that idincates if it allows equal numbers as true
        /// </summary>
        public bool AllowEqual { get; private set; }

        /// <summary>
        /// Get the number that is evaluated to be less than the EvaluateAgainst number
        /// </summary>
        public Number ToEvaluate { get; private set; }

        /// <summary>
        /// Get the number that is evaluated against, thus the ToEvaluate number should be less than this
        /// </summary>
        public Number EvaluateAgainst { get; private set; }

        /// <summary>
        /// Get flag to indicate if the condition the object represnt is fullfilled 
        /// </summary>
        public bool ConditionMeet
        {
            get
            {
                if (AllowEqual)
                    return ToEvaluate.GetRealNumber().Value <= EvaluateAgainst.GetRealNumber().Value;
                else
                    return ToEvaluate.GetRealNumber().Value < EvaluateAgainst.GetRealNumber().Value;
            }
        }
    }
}