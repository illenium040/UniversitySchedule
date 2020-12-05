using DataAccess.Entities;

using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsUI
{
    class SpecialtyWrapper
    {
        public Specialty Specialty { get; private set; }
        public SpecialtyWrapper(Specialty specialty)
        {
            Specialty = specialty;
        }

        public override string ToString()
        {
            return Specialty.Index;
        }
    }
}
