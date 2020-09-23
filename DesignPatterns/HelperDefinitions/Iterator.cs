using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.HelperDefinitions
{
    public class Iterator
    {
        private int _currentIndex;
        private object[] _objects;

        public Iterator(int length)
        {
            this._currentIndex = 0;
            this._objects = new object[length];
        }

        public object this[int index]
        {
            get { return this._objects[index]; }
            set { this._objects[index] = value; }
        }

        public object GetNext() => this._objects[this._currentIndex++];
        public bool IsDone() => this._currentIndex >= this._objects.Length;
    }
}
