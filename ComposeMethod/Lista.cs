using System;

namespace RefactoringToPatterns.ComposeMethod
{
    public class Lista
    {
        private readonly bool _readOnly;
        private int _size;
        private Object[] _elements;

        public Lista(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new Object[_size];
        }

        public void Add(Object element)
        {
            if (!_readOnly)
            {
                EnsureCapacity();
                AddElement(element);
            }
        }

        private void EnsureCapacity()
        {
            int newSize = _size + 1;

            if (newSize > _elements.Length)
            {
                Object[] newElements = ExpandElementsArray();

                for (int i = 0; i < _size; i++)
                    newElements[i] = _elements[i];

                _elements = newElements;
            }
        }

        private Object[] ExpandElementsArray()
        {
            return new Object[_elements.Length + 10];
        }

        private void AddElement(Object element)
        {
            _elements[_size++] = element;
        }

        public object[] Elements()
        {
            return _elements;
        }
    }
}
