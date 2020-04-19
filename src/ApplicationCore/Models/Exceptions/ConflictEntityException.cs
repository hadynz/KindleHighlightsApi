using System;

namespace ApplicationCore.Models.Exceptions
{
    public class ConflictEntityException : Exception
    {
        public Guid ReferenceId { get; set; }

        public ConflictEntityException(string message, Guid referenceId)
            : base(message)
        {
            ReferenceId = referenceId;
        }
    }
}
