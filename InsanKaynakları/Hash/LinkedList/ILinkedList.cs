using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynakları.LinkedList
{
   public interface ILinkedList
    {
        void InsertFirst(object value);
        void InsertLast(object value);
        void InsertPos(int position, object value);
        void DeleteFirst();
        void DeleteLast();
        void DeletePos(int position);
        object GetElement(int position);
        string DisplayElements();
    }
}
