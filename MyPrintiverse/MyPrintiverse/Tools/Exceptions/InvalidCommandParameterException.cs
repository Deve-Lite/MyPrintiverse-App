﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrintiverse.Tools.Exceptions
{
    /// <summary>
	/// Represents errors that occur during IAsyncCommand execution.
	/// </summary>
	public class InvalidCommandParameterException : Exception
    {
        /// <summary>
        /// Initializes a new instance of theclass.
        /// </summary>
        /// <param name="expectedType">Expected parameter type for AsyncCommand.Execute.</param>
        /// <param name="actualType">Actual parameter type for AsyncCommand.Execute.</param>
        /// <param name="innerException">Inner Exception</param>
        public InvalidCommandParameterException(Type expectedType, Type actualType, Exception innerException) : base(CreateErrorMessage(expectedType, actualType), innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the  class.
        /// </summary>
        /// <param name="expectedType">Expected parameter type for AsyncCommand.Execute.</param>
        /// <param name="innerException">Inner Exception</param>
        public InvalidCommandParameterException(Type expectedType, Exception innerException) : base(CreateErrorMessage(expectedType), innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="expectedType">Expected parameter type for AsyncCommand.Execute.</param>
        /// <param name="actualType">Actual parameter type for AsyncCommand.Execute.</param>
        public InvalidCommandParameterException(Type expectedType, Type actualType) : base(CreateErrorMessage(expectedType, actualType))
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="expectedType">Expected parameter type for AsyncCommand.Execute.</param>
        public InvalidCommandParameterException(Type expectedType) : base(CreateErrorMessage(expectedType))
        {

        }

        static string CreateErrorMessage(Type expectedType, Type actualType) =>
            $"Invalid type for parameter. Expected Type: {expectedType}, but received Type: {actualType}";

        static string CreateErrorMessage(Type expectedType) =>
            $"Invalid type for parameter. Expected Type {expectedType}";
    }
}