using System;
using System.Collections.Generic;
using Value;

namespace Domain
{
    internal class RowNumber : ValueType<RowNumber>, IComparable<RowNumber>
    {
        private readonly int _rowNumber;

        private RowNumber(int rowNumber)
        {
            _rowNumber = rowNumber;
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new List<object> {_rowNumber};
        }

        public static implicit operator RowNumber(int rowNumber)
        {
            return new RowNumber(rowNumber);
        }

        public static implicit operator int(RowNumber rowNumber)
        {
            return rowNumber._rowNumber;
        }

        public int CompareTo(RowNumber other)
        {
            if (_rowNumber > other._rowNumber) return -1;
            
            return _rowNumber == other._rowNumber ? 0 : 1;
        }
    }
}