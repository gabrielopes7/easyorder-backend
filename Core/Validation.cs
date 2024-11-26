using System;
using System.Collections.Generic;

namespace Core
{
    public class Validation
    {

        private List<ValidationMessage> inconsistences;
        public Validation()
        {
            inconsistences = new List<ValidationMessage>();
        }
        public IReadOnlyList<ValidationMessage> Inconsistences
        {
            get
            {
                this.inconsistences ??= new List<ValidationMessage>();
                return inconsistences.AsReadOnly();
            }
        }

        public bool Validated => !HasInconsistence;

        public bool HasInconsistence => inconsistences.Count > 0;


        public virtual void AddInconsistence(ValidationMessage message)
        {
            if(message != null)
            {
                inconsistences.Add(message);
            }
        }
    }
}
