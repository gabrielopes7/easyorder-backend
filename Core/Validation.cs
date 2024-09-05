using System;
using System.Collections.Generic;

namespace Core
{
    public class Validation
    {
        public Validation(){}

        public List<ValidationMessage> inconsistences = new List<ValidationMessage>();
        public List<ValidationMessage> Inconsistences
        {
            get
            {
                this.inconsistences ??= new List<ValidationMessage>();
                return this.Inconsistences;
            }
        }

        public bool Validated
        {
            get
            {
                bool invalidated = this.HasInconsistence;
                return !invalidated;
            }
        }

        public bool HasInconsistence
        {
            get
            {
                return this.inconsistences.Count > 0;
            }
        }


        public virtual void AddInconsistence(ValidationMessage message)
        {
            this.Inconsistences.Add(message);
        }
    }
}
