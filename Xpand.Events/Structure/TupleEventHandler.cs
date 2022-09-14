using System;
using System.Collections;

namespace Xpand.Events {
    public delegate void TupleEventHandler<in TTupleArgs>(TTupleArgs args) where TTupleArgs : IStructuralEquatable, IStructuralComparable, IComparable;
}