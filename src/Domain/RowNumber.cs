using System.Collections.Generic;
using Value;

namespace Domain
{
    internal class RowNumber : ValueType<RowNumber>
    {
        private readonly int _rowNumber;

        private RowNumber(int rowNumber)
        {
            _rowNumber = rowNumber;
        }

        public static implicit operator RowNumber(int rowNumber)
        {
            return new RowNumber(rowNumber);
        }

        protected override IEnumerable<object> GetAllAttributesToBeUsedForEquality()
        {
            return new List<object> {_rowNumber};
        }
    }
}