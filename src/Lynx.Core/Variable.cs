﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lynx.Core.Conditions;
using Lynx.Core.Numbers;

namespace Lynx.Core
{
    /// <summary>
    /// Class representing a mathematical variable
    /// </summary>
    public class Variable : Number
    {
        private List<Condition> _conditions;

        /// <summary>
        /// Creates a new instance of the Variable class
        /// </summary>
        protected Variable() { }

        /// <summary>
        /// Creates a new instance of the Variable class
        /// </summary>
        /// <param name="designation">The designation of the variable</param>
        /// <param name="value">The value the variable should hold</param>
        /// <exception cref="ArgumentNullException">Thrown if the designation is null, empty or just whitespace</exception>
        /// 
        public Variable(string designation, Number value)
        {
            if (string.IsNullOrWhiteSpace(designation))
                throw new ArgumentNullException(nameof(designation), "The designation was null, empty or just white space and that is not allowd");
            if(value == null)
                throw new ArgumentNullException(nameof(value), "The value was null and that is not allowd");

          
            Designation = designation;
            Value = value;
            Conditions = new List<Condition>();
        }

        /// <summary>
        /// Get the designation of the variable 
        /// </summary>
        public string Designation { get; private set; }

        /// <summary>
        /// The value the variable represents
        /// </summary>
        public Number Value { get; private set; }

        /// <summary>
        /// Get the conditions of the variable for what values it can take
        /// </summary>
        public IEnumerable<Condition> Conditions
        {
            get { return _conditions; }
            private set { _conditions = value.ToList(); }
        }

        /// <summary>
        /// Get the number that is represented by the number 
        /// </summary>
        /// <returns>
        /// The real number
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the number can't be represented as a real number
        /// </exception>
        /// <exception cref="ArgumentException">Thrown if the variable doesn't have a value set</exception>
        public RealNumber GetRealNumber()
        {
            return Value.GetRealNumber();
        }

        /// <summary>
        /// Regenerates the number if it isn't fixed
        /// </summary>
        public void Regenerate()
        {
            if (Value == null)
                return;

            getNewAllowedNbr();
        }

        private int getNewAllowedNbr()
        {
            var counter = 0;

            do
            {
                Value.Regenerate();
                counter++;
            } while (_conditions.Any() && !Conditions.Any(x => x.ConditionMeet)&& counter < 100);

            return counter;
        }

        /// <summary>
        /// Set the conditions of the variable if they aren't set already
        /// </summary>
        /// <param name="conditions">The conditions to assign the variable, must be at least one</param>
        /// <returns>
        /// True if the conditions are set to the ones given when called the method, 
        /// false if the conditions were already set and thus not updated
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if the value can't take a number that meets the conditions</exception>
        public bool SetConditions(params Condition[] conditions)
        {
            if (Conditions.Any())
                return false;

            Conditions = conditions;
            if (_conditions.Any() && !_conditions.Any(x => x.ConditionMeet))
            {
                var tries = getNewAllowedNbr();
                if (tries >= 100)
                    throw new ArgumentException("Value can't take a number that is accepted by the conditions", nameof(conditions));
            }
            return true;
        }
    }
}